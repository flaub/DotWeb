using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using System.Diagnostics;
using System.IO;

namespace DotWeb.Utility.Cecil
{
	public static class TypeHelper
	{
		public static class Names
		{
			public const string Delegate = "System.Delegate";
			public const string DotWebSystem = "DotWeb.System";
			public const string DllSuffix = ".dll";
			public const string JsObject = "System.DotWeb.JsObject";
		}

		static TypeHelper() {
			var resolver = new DefaultAssemblyResolver();
			asmSystem = resolver.Resolve(Names.DotWebSystem);
			asmSystem.MainModule.LoadSymbols();
		}

		public static TypeDefinition GetTypeDefinition(Type type) {
			switch (type.FullName) {
				case Names.Delegate:
				case Constants.Boolean:
				case Constants.Byte:
				case Constants.Char:
				case Constants.Double:
				case Constants.Enum:
				case Constants.Int16:
				case Constants.Int32:
				case Constants.Int64:
				case Constants.IntPtr:
				case Constants.Object:
				case Constants.SByte:
				case Constants.Single:
				case Constants.String:
				case Constants.Type:
				case Constants.UInt16:
				case Constants.UInt64:
				case Constants.UIntPtr:
				case Constants.Void:
					return asmSystem.MainModule.Types[type.FullName];
				default:
					return null;
			}
		}

		public static Type GetReflectionType(TypeReference type) {
			switch (type.FullName) {
				case Constants.Boolean:
					return typeof(Boolean);
				case Constants.Byte:
					return typeof(Byte);
				case Constants.Char:
					return typeof(Char);
				case Constants.Double:
					return typeof(Double);
				case Constants.Enum:
					return typeof(Enum);
				case Constants.Int16:
					return typeof(Int16);
				case Constants.Int32:
					return typeof(Int32);
				case Constants.Int64:
					return typeof(Int64);
				case Constants.IntPtr:
					return typeof(IntPtr);
				case Constants.Object:
					return typeof(Object);
				case Constants.SByte:
					return typeof(SByte);
				case Constants.Single:
					return typeof(Single);
				case Constants.String:
					return typeof(String);
				case Constants.Type:
					return typeof(Type);
				case Constants.UInt16:
					return typeof(UInt16);
				case Constants.UInt32:
					return typeof(UInt32);
				case Constants.UInt64:
					return typeof(UInt64);
				case Constants.UIntPtr:
					return typeof(UIntPtr);
				case Constants.Void:
					return typeof(void);
				case Names.Delegate:
					return typeof(Delegate);
				default:
					return typeof(object);
			}
		}

		public static bool IsSubclassOf(TypeReference typeRef, string typeName) {
			TypeReference other = asmSystem.MainModule.Types[typeName];
			return IsSubclassOf(typeRef, other);
		}

		public static bool IsSubclassOf(TypeReference typeRef, TypeReference other) {
			TypeReference baseType = typeRef.Resolve().BaseType;
			while (baseType != null) {
				if (IsEquivalent(baseType, other))
					return true;

				baseType = baseType.Resolve().BaseType;
			}

			return false;
		}

		public static bool IsDefined(ICustomAttributeProvider provider, string attributeTypeName) {
			TypeReference attributeType = asmSystem.MainModule.Types[attributeTypeName];
			return IsDefined(provider, attributeType);
		}

		public static bool IsDefined(ICustomAttributeProvider provider, TypeReference attributeType) {
			foreach (CustomAttribute item in provider.CustomAttributes) {
				if (IsEquivalent(item.Constructor.DeclaringType, attributeType))
					return true;
			}
			return false;
		}

		public static string GetScopeName(IMetadataScope scope) {
			string name = scope.Name;
			if (name.EndsWith(Names.DllSuffix)) {
				var index = name.Length - Names.DllSuffix.Length;
				return name.Substring(0, index);
			}
			return name;
		}

		public static bool IsEquivalent(TypeReference typeRef, Type reflectionType) {
			if (typeRef == null)
				return false;

			var def = GetTypeDefinition(reflectionType);
			return IsEquivalent(typeRef, def);
		}

		public static bool IsEquivalent(TypeReference lhs, TypeReference rhs) {
			if (lhs == null || rhs == null)
				return false;

			var lhsDef = lhs.Resolve();
			var rhsDef = rhs.Resolve();

			string lhsScopeName = GetScopeName(lhsDef.Scope);
			string rhsScopeName = GetScopeName(rhsDef.Scope);
			return lhsScopeName == rhsScopeName && lhsDef.MetadataToken == rhsDef.MetadataToken;
		}

		public static bool IsEquivalent(TypeReference lhs, string typeName) {
			TypeReference rhs = asmSystem.MainModule.Types[typeName];
			if (lhs == null || rhs == null)
				return false;

			return IsEquivalent(lhs, rhs);
		}

		private static AssemblyDefinition asmSystem;
	}
}
