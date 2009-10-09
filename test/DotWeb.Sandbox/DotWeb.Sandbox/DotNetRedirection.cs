using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;
using System.IO;
using System.Reflection;
using DotWeb.Decompiler.Core;

namespace DotWeb.Sandbox
{
	[Guid("809c652e-7396-11d2-9771-00a0c9b4d50c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	interface IMetaDataDispenser
	{
		// We need to be able to call OpenScope, which is the 2nd vtable slot.
		// Thus we need this one placeholder here to occupy the first slot..
		void DefineScope_Placeholder();

		//STDMETHOD(OpenScope)(                   // Return code.
		//LPCWSTR     szScope,                // [in] The scope to open.
		//  DWORD       dwOpenFlags,            // [in] Open mode flags.
		//  REFIID      riid,                   // [in] The interface desired.
		//  IUnknown    **ppIUnk) PURE;         // [out] Return interface on success.
		void OpenScope(
			[In, MarshalAs(UnmanagedType.LPWStr)] String szScope,
			[In] Int32 dwOpenFlags,
			[In] ref Guid riid,
			[Out, MarshalAs(UnmanagedType.IUnknown)] out Object punk);

		// Don't need any other methods.
	}

	// Since we're just blindly passing this interface through managed code to the Symbinder, we don't care about actually
	// importing the specific methods.
	// This needs to be public so that we can call Marshal.GetComInterfaceForObject() on it to get the
	// underlying metadata pointer.
	[Guid("7DAC8207-D3AE-4c75-9B67-92801A497D44"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface IMetadataImport
	{
		// Just need a single placeholder method so that it doesn't complain about an empty interface.
		void Placeholder();
	}

	[ComImport]
	[Guid("e5cb7a31-7512-11d2-89ce-0080c792e5d8")]
	[ClassInterface(ClassInterfaceType.None)]
	[TypeLibType(TypeLibTypeFlags.FCanCreate)]
	public class CorMetaDataDispenser : IMetaDataDispenser
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public extern void DefineScope_Placeholder();

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public extern void OpenScope(
			[In, MarshalAs(UnmanagedType.LPWStr)] String szScope,
			[In] Int32 dwOpenFlags,
			[In] ref Guid riid,
			[Out, MarshalAs(UnmanagedType.IUnknown)] out Object punk);
	}

	class SequencePoint
	{
		public int Offset { get; set; }
		public ISymbolDocument Document { get; set; }
		public int Line { get; set; }
		public int Column { get; set; }
		public int EndLine { get; set; }
		public int EndColumn { get; set; }
	}

	class SequencePointCollection
	{
		public int Count { get; private set; }
		public int[] Offsets { get; private set; }
		public int[] Lines { get; private set; }
		public int[] Columns { get; private set; }
		public int[] EndLines { get; private set; }
		public int[] EndColumns { get; private set; }
		public ISymbolDocument[] Documents { get; private set; }

		private Dictionary<int, int> indexByOffsets = new Dictionary<int, int>();

		public SequencePointCollection(ISymbolMethod method) {
			this.Count = method.SequencePointCount;
			this.Offsets = new int[Count];
			this.Lines = new int[Count];
			this.Columns = new int[Count];
			this.EndLines = new int[Count];
			this.EndColumns = new int[Count];
			this.Documents = new ISymbolDocument[Count];
			Populate(method);
		}

		private void Populate(ISymbolMethod method) {
			method.GetSequencePoints(Offsets, Documents, Lines, Columns, EndLines, EndColumns);
			for (int i = 0; i < Count; i++) {
				this.indexByOffsets.Add(Offsets[i], i);
			}
		}

		public SequencePoint GetSequencePointAtOffset(int offset) {
			int index;
			if (!this.indexByOffsets.TryGetValue(offset, out index)) {
				return null;
			}

			return new SequencePoint {
				Offset = offset,
				Document = Documents[index],
				Line = Lines[index],
				Column = Columns[index],
				EndLine = EndLines[index],
				EndColumn = EndColumns[index]
			};
		}
	}

	class DotNetRedirection
	{
		public DotNetRedirection() {
		}

		public void Run() {
			string path = @"F:\src\git\DotWeb\build\bin\Debug\DotWeb.Sample.Script.dll";

			var reader = GetReaderFor(path);

			var sourceType = Type.GetType("DotWeb.Sample.Script.Test.Sandbox, DotWeb.Sample.Script");
			var sourceMethod = sourceType.GetConstructor(Type.EmptyTypes);
			var token = new SymbolToken(sourceMethod.MetadataToken);

			var symMethod = reader.GetMethod(token);
			var points = new SequencePointCollection(symMethod);

			string fileName = "Test.dll";
			string outDir = @"F:\src\git\DotWeb\build\bin\Debug";
			string outPath = Path.Combine(outDir, fileName);

			var asmName = new AssemblyName("Test");
			var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, outDir);
			var moduleBuilder = asmBuilder.DefineDynamicModule(fileName, fileName, true);
			var typeBuilder = moduleBuilder.DefineType("Test", System.Reflection.TypeAttributes.Public | System.Reflection.TypeAttributes.Class);
			var ctorBuilder = typeBuilder.DefineConstructor(System.Reflection.MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
			var ilg = ctorBuilder.GetILGenerator();

			var methodReader = new MethodBodyReader(sourceMethod);

			foreach (var il in methodReader.Instructions) {
				var point = points.GetSequencePointAtOffset(il.Offset);
				if (point != null) {
					var doc = GetDocumentWriterFor(point.Document, moduleBuilder);
					ilg.MarkSequencePoint(doc, point.Line, point.Column, point.EndLine, point.EndColumn);
				}

				if (il.Operand is MethodInfo) {
					RedirectMethodInfo(il);
				}
				Emit(ilg, il);
			}

			typeBuilder.CreateType();
			asmBuilder.Save(fileName);

			var asm = Assembly.LoadFile(outPath);
			var types = asm.GetTypes();
			var type = asm.GetType("Test");
			var obj = Activator.CreateInstance(type);
		}

		ISymbolDocumentWriter GetDocumentWriterFor(ISymbolDocument doc, ModuleBuilder moduleBuilder) {
			return moduleBuilder.DefineDocument(doc.URL, doc.Language, doc.LanguageVendor, doc.DocumentType);
		}

		static void RedirectMethodInfo(ILInstruction il) {
			Type targetType = typeof(Console);
			var targetMethod = targetType.GetMethod("WriteLine", new Type[] { typeof(string) });

			var redirect = typeof(Program).GetMethod("WriteLine");

			var method = (MethodInfo)il.Operand;
			if (il.Operand.Equals(targetMethod)) {
				il.Operand = redirect;
			}
		}

		static ISymbolReader GetReaderFor(string path) {
			CorMetaDataDispenser dispenser = null;
			object objImporter = null;
			IntPtr pImporter = IntPtr.Zero;
			Guid iidImporter = typeof(IMetadataImport).GUID;

			try {
				dispenser = new CorMetaDataDispenser();
				dispenser.OpenScope(path, 0, ref iidImporter, out objImporter);

				pImporter = Marshal.GetComInterfaceForObject(objImporter, typeof(IMetadataImport));
				var binder = new SymBinder();
				return binder.GetReader(pImporter, path, null);
			}
			finally {
				if (pImporter != IntPtr.Zero)
					Marshal.Release(pImporter);
				if (objImporter != null)
					Marshal.ReleaseComObject(objImporter);
				if (dispenser != null)
					Marshal.ReleaseComObject(dispenser);
			}
		}

		class OperandTypeNames
		{
			public const string Byte = "Byte";
			public const string Double = "Double";
			public const string Float = "Single";
			public const string Int = "Int32";
			public const string Short = "Int16";
			public const string Long = "Int64";
			public const string String = "String";
			public const string Method = "RuntimeMethodInfo";
			public const string Constructor = "RuntimeConstructorInfo";
			public const string Field = "RuntimeFieldInfo";
			public const string Type = "Type";
			public const string Label = "Label";
		}

		public static void Emit(ILGenerator ilg, ILInstruction il) {
			if (il.Operand == null) {
				ilg.Emit(il.Code);
				return;
			}
			var typeName = il.Operand.GetType().Name;
			switch (typeName) {
				case OperandTypeNames.Byte:
					ilg.Emit(il.Code, (byte)il.Operand);
					break;
				case OperandTypeNames.Float:
					ilg.Emit(il.Code, (float)il.Operand);
					break;
				case OperandTypeNames.Double:
					ilg.Emit(il.Code, (double)il.Operand);
					break;
				case OperandTypeNames.Short:
					ilg.Emit(il.Code, (short)il.Operand);
					break;
				case OperandTypeNames.Int:
					ilg.Emit(il.Code, (int)il.Operand);
					break;
				case OperandTypeNames.Long:
					ilg.Emit(il.Code, (long)il.Operand);
					break;
				case OperandTypeNames.String:
					ilg.Emit(il.Code, (string)il.Operand);
					break;
				case OperandTypeNames.Method:
					ilg.Emit(il.Code, (MethodInfo)il.Operand);
					break;
				case OperandTypeNames.Constructor:
					ilg.Emit(il.Code, (ConstructorInfo)il.Operand);
					break;
				case OperandTypeNames.Field:
					ilg.Emit(il.Code, (FieldInfo)il.Operand);
					break;
				case OperandTypeNames.Label:
					ilg.Emit(il.Code, (Label)il.Operand);
					break;
				default:
					throw new NotSupportedException(string.Format("OperandType: {0}", typeName));
			}
		}
	}
}
