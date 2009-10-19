using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Mono.Cecil;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.Collections;
using SR = System.Reflection;
using SRE = System.Reflection.Emit;
using System.Diagnostics;
using DotWeb.Hosting;

namespace DotWeb.Tools.Weaver
{
	class MethodProcessor
	{
		private TypeProcessor parent;
		private IResolver resolver;
		private MethodDefinition methodDef;
		private MethodBase method;
		private Dictionary<Instruction, Label> labels = new Dictionary<Instruction, Label>();
		private Dictionary<VariableDefinition, LocalBuilder> locals = new Dictionary<VariableDefinition, LocalBuilder>();
		private GenericMethodProcessor genericProc;

		public MethodProcessor(IResolver resolver, TypeProcessor parent, MethodDefinition methodDef) {
			this.resolver = resolver;
			this.parent = parent;
			this.methodDef = methodDef;
			this.genericProc = new GenericMethodProcessor(this.resolver);
		}

		public void ProcessMethod(MethodBuilder methodBuilder) {
			Debug.Assert(this.method == null);
			this.method = methodBuilder;

			if (methodDef.HasGenericParameters) {
				this.genericProc.ProcessMethod(methodDef, methodBuilder);
			}

			var returnType = ResolveTypeReference(methodDef.ReturnType.ReturnType);
			methodBuilder.SetReturnType(returnType);

			if (methodDef.HasParameters) {
				var argTypes = ResolveParameterTypes(methodDef.Parameters);
				methodBuilder.SetParameters(argTypes);

				foreach (ParameterDefinition parameter in methodDef.Parameters) {
					methodBuilder.DefineParameter(parameter.Sequence, (SR.ParameterAttributes)parameter.Attributes, parameter.Name);
				}
			}

			if (methodDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, methodDef, methodBuilder);
			}

			methodBuilder.SetImplementationFlags((SR.MethodImplAttributes)methodDef.ImplAttributes);

			if (this.methodDef.HasBody) {
				var generator = methodBuilder.GetILGenerator();
				ProcessMethodBody(generator);
			}
		}

		public void ProcessConstructor(ConstructorBuilder ctorBuilder) {
			Debug.Assert(this.method == null);
			this.method = ctorBuilder;

			if (methodDef.HasGenericParameters) {
				throw new NotSupportedException();
			}

			if (methodDef.HasParameters) {
				foreach (ParameterDefinition parameter in methodDef.Parameters) {
					ctorBuilder.DefineParameter(parameter.Sequence, (SR.ParameterAttributes)parameter.Attributes, parameter.Name);
				}
			}

			if (methodDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, methodDef, ctorBuilder);
			}

			ctorBuilder.SetImplementationFlags((SR.MethodImplAttributes)methodDef.ImplAttributes);

			if (this.methodDef.HasBody) {
				var generator = ctorBuilder.GetILGenerator();
				ProcessMethodBody(generator);
			}
		}

		public void DeclareLocals(ILGenerator generator, VariableDefinitionCollection variables) {
			foreach (VariableDefinition variable in variables) {
				var type = ResolveTypeReference(variable.VariableType);
				var local = generator.DeclareLocal(type);
				local.SetLocalSymInfo(variable.Name);

				this.locals.Add(variable, local);
			}
		}

		private void DefineLabels(ILGenerator generator, InstructionCollection instructions) {
			foreach (Instruction cil in instructions) {
				if (cil.Operand is Instruction) {
					var key = (Instruction)cil.Operand;
					if (!labels.ContainsKey(key)) {
						var label = generator.DefineLabel();
						labels.Add(key, label);
					}
				}
			}
		}

		public void ProcessMethodBody(ILGenerator generator) {
			var body = methodDef.Body;
			if (body == null || body.CodeSize == 0) {
				GenerateExternMethodBody(generator);
				return;
			}

			DeclareLocals(generator, body.Variables);

			var scopeProc = new ScopeProcessor(this, generator);
			if (body.HasScopes)
				scopeProc.Push(body.Scopes);

			var exceptionProc = new ExceptionProcessor(this, generator);
			if (body.HasExceptionHandlers)
				exceptionProc.Start(body.ExceptionHandlers);

			DefineLabels(generator, body.Instructions);

			foreach (Instruction cil in body.Instructions) {
				if (body.HasScopes) {
					scopeProc.ProcessInstruction(cil);
				}

				if (body.HasExceptionHandlers) {
					exceptionProc.ProcessInstruction(cil);
				}

				Label label;
				if (labels.TryGetValue(cil, out label)) {
					generator.MarkLabel(label);
				}

				var point = cil.SequencePoint;
				if (point != null) {
					var doc = point.Document;
					var docWriter = this.parent.ModuleBuilder.DefineDocument(doc.Url, doc.Language, doc.LanguageVendor, doc.Type);
					generator.MarkSequencePoint(docWriter, point.StartLine, point.StartColumn, point.EndLine, point.EndColumn);
				}

				Emit(generator, cil);
			}
		}

		static class PredefinedTypes
		{
			public static readonly Type Arguments = typeof(object[]);
			public static readonly Type Object = typeof(object);
			public static readonly Type MethodBase = typeof(MethodBase);
			public static readonly Type IDotWebHost = typeof(IDotWebHost);
			public static readonly Type HostedMode = typeof(HostedMode);

			public static readonly MethodInfo HostedMode_get_Host;
			public static readonly MethodInfo IDotWebHost_Invoke;
			public static readonly MethodInfo IDotWebHost_Cast;
			public static readonly MethodInfo MethodBase_GetCurrentMethod;

			static PredefinedTypes() {
				HostedMode_get_Host = HostedMode.GetMethod("get_Host");
				IDotWebHost_Invoke = IDotWebHost.GetMethod("Invoke");
				IDotWebHost_Cast = IDotWebHost.GetMethod("Cast");
				MethodBase_GetCurrentMethod = MethodBase.GetMethod("GetCurrentMethod");
			}
		}

		public void GenerateExternMethodBody(ILGenerator generator) {
			bool needsReturn = (this.methodDef.ReturnType.ReturnType.FullName != Constants.Void);

			int indexOffset;
			if (this.methodDef.IsStatic)
				indexOffset = 0;
			else
				indexOffset = 1;

			var argCount = this.methodDef.Parameters.Count;

			var method = generator.DeclareLocal(PredefinedTypes.MethodBase);
			method.SetLocalSymInfo("__method");

			var args = generator.DeclareLocal(PredefinedTypes.Arguments);
			args.SetLocalSymInfo("__args");

			// __method = MethodBase.GetCurrentMethod();
			generator.EmitCall(SRE.OpCodes.Call, PredefinedTypes.MethodBase_GetCurrentMethod, Type.EmptyTypes);
			generator.Emit(SRE.OpCodes.Stloc, method.LocalIndex);
			
			LocalBuilder ret = null;
			if (needsReturn) {
				ret = generator.DeclareLocal(PredefinedTypes.Object);
				ret.SetLocalSymInfo("__ret");
			}

			// var args = new object[argCount];
			generator.Emit(SRE.OpCodes.Ldc_I4, argCount);
			generator.Emit(SRE.OpCodes.Newarr, PredefinedTypes.Object);
			generator.Emit(SRE.OpCodes.Stloc, args.LocalIndex);

			for (int i = 0; i < argCount; i++) {
				// __args[i] = <argument[i]>;
				generator.Emit(SRE.OpCodes.Ldloc, args.LocalIndex);
				generator.Emit(SRE.OpCodes.Ldc_I4, i);
				generator.Emit(SRE.OpCodes.Ldarg, i + indexOffset);
				var arg = this.methodDef.Parameters[i];
				if (arg.ParameterType.IsValueType) {
					var argType = Type.GetType(arg.ParameterType.FullName);
					generator.Emit(SRE.OpCodes.Box, argType);
				}
				generator.Emit(SRE.OpCodes.Stelem_Ref);
			}

			// __ret = HostedMode.Host.Invoke(this|null, __method, __args); 
			generator.EmitCall(SRE.OpCodes.Call, PredefinedTypes.HostedMode_get_Host, null);

			if (this.methodDef.IsStatic)
				generator.Emit(SRE.OpCodes.Ldnull);
			else
				generator.Emit(SRE.OpCodes.Ldarg_0);

			generator.Emit(SRE.OpCodes.Ldloc, method.LocalIndex);
			generator.Emit(SRE.OpCodes.Ldloc, args.LocalIndex);
			generator.EmitCall(SRE.OpCodes.Callvirt, PredefinedTypes.IDotWebHost_Invoke, null);

			if (needsReturn) {
				// return __ret;
				generator.Emit(SRE.OpCodes.Stloc, ret.LocalIndex);
				generator.Emit(SRE.OpCodes.Ldloc, ret.LocalIndex);

				generator.Emit(SRE.OpCodes.Ret);
			}
			else {
				generator.Emit(SRE.OpCodes.Pop);
			}
		}

		public void Emit(ILGenerator generator, Instruction cil) {
			SRE.OpCode code = OpCodeConverter.Convert(cil.OpCode);
			if (cil.Operand == null) {
				generator.Emit(code);
				return;
			}

			var typeName = cil.Operand.GetType().Name;
			switch (typeName) {
				case OperandTypeNames.Byte:
					generator.Emit(code, (byte)cil.Operand);
					break;
				case OperandTypeNames.SByte:
					generator.Emit(code, (sbyte)cil.Operand);
					break;
				case OperandTypeNames.Float:
					generator.Emit(code, (float)cil.Operand);
					break;
				case OperandTypeNames.Double:
					generator.Emit(code, (double)cil.Operand);
					break;
				case OperandTypeNames.Short:
					generator.Emit(code, (short)cil.Operand);
					break;
				case OperandTypeNames.Int:
					generator.Emit(code, (int)cil.Operand);
					break;
				case OperandTypeNames.Long:
					generator.Emit(code, (long)cil.Operand);
					break;
				case OperandTypeNames.String:
					generator.Emit(code, (string)cil.Operand);
					break;
				case OperandTypeNames.MethodReference:
				case OperandTypeNames.MethodDefinition:
					EmitMethod(generator, code, (MethodReference)cil.Operand);
					break;
				case OperandTypeNames.TypeReference:
				case OperandTypeNames.TypeDefinition:
					EmitType(generator, code, (TypeReference)cil.Operand);
					break;
				case OperandTypeNames.FieldReference:
				case OperandTypeNames.FieldDefinition:
					EmitField(generator, code, (FieldReference)cil.Operand);
					break;
				case OperandTypeNames.Instruction:
					generator.Emit(code, labels[(Instruction)cil.Operand]);
					break;
				case OperandTypeNames.VariableDefinition:
					generator.Emit(code, locals[(VariableDefinition)cil.Operand]);
					break;
				case OperandTypeNames.ParameterDefinition:
					EmitParameter(generator, code, (ParameterDefinition)cil.Operand);
					break;
				default:
					throw new NotSupportedException(string.Format("OperandType: {0}", typeName));
			}
		}

		private void EmitParameter(ILGenerator generator, SRE.OpCode code, ParameterDefinition parameterDef) {
			generator.Emit(code, parameterDef.Sequence);
		}

		public void EmitMethod(ILGenerator generator, SRE.OpCode code, MethodReference methodRef) {
			var methodBase = this.resolver.ResolveMethodReference(methodRef);
			if (methodBase is ConstructorInfo)
				generator.Emit(code, (ConstructorInfo)methodBase);
			else
				generator.Emit(code, (MethodInfo)methodBase);
		}

		public void EmitType(ILGenerator generator, SRE.OpCode code, TypeReference typeRef) {
			var type = ResolveTypeReference(typeRef);
			if (code == SRE.OpCodes.Castclass) {
				var cast = generator.DeclareLocal(PredefinedTypes.Object);
				generator.Emit(SRE.OpCodes.Stloc, cast.LocalIndex);

				generator.EmitCall(SRE.OpCodes.Call, PredefinedTypes.HostedMode_get_Host, null);

				generator.Emit(SRE.OpCodes.Ldloc, cast.LocalIndex);
				var castCall = PredefinedTypes.IDotWebHost_Cast.MakeGenericMethod(type);
				generator.EmitCall(SRE.OpCodes.Callvirt, castCall, null);
			}
			else if (code == SRE.OpCodes.Isinst) {
			}
			else {
				generator.Emit(code, type);
			}
		}

		public void EmitField(ILGenerator generator, SRE.OpCode code, FieldReference fieldRef) {
			var field = this.resolver.ResolveFieldReference(fieldRef);
			generator.Emit(code, field);
		}

		private Type ResolveTypeReference(TypeReference typeRef) {
			if (typeRef is GenericParameter) {
				var arg = this.genericProc.GetGenericParameter(typeRef.Name);
				if (arg != null)
					return arg;
				return this.parent.GetGenericParameter(typeRef.Name);
			}

			return this.resolver.ResolveTypeReference(typeRef).Type;
		}

		private Type[] ResolveParameterTypes(ParameterDefinitionCollection parameters) {
			Type[] ret = new Type[parameters.Count];
			for (int i = 0; i < parameters.Count; i++) {
				var arg = parameters[i];
				var argType = arg.ParameterType;
				ret[i] = ResolveTypeReference(argType);
			}
			return ret;
		}

	}
}
