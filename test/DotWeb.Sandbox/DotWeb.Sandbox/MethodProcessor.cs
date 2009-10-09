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

namespace DotWeb.Sandbox
{
	public interface IExternalImpl
	{
		object InvokeExternal(object scope, MethodBase method, object[] args);
	}

	public static class ExternalCall
	{
		public static object Invoke(object scope, object[] args) {
			var frame = new StackFrame(1);
			var method = frame.GetMethod();
			return Impl.InvokeExternal(scope, method, args);
		}

		public static IExternalImpl Impl { get; set; }
	}

	class MethodProcessor
	{
		private TypeProcessor parent;
		private Hoister hoister;
		private MethodDefinition methodDef;
		private MethodBase method;
		private Dictionary<Instruction, Label> labels = new Dictionary<Instruction, Label>();
		private Dictionary<VariableDefinition, LocalBuilder> locals = new Dictionary<VariableDefinition, LocalBuilder>();

		public MethodProcessor(Hoister hoister, TypeProcessor parent, MethodDefinition methodDef) {
			this.hoister = hoister;
			this.parent = parent;
			this.methodDef = methodDef;
		}

		public void ProcessMethod(MethodBuilder methodBuilder) {
			Debug.Assert(this.method == null);
			this.method = methodBuilder;

			if (methodDef.HasParameters) {
				foreach (ParameterDefinition parameter in methodDef.Parameters) {
					methodBuilder.DefineParameter(parameter.Sequence, (SR.ParameterAttributes)parameter.Attributes, parameter.Name);
				}
			}

			if (methodDef.HasGenericParameters) {
				var genericNames = methodDef.GenericParameters.Cast<GenericParameter>().Select(x => x.Name);
				methodBuilder.DefineGenericParameters(genericNames.ToArray());
			}

			var generator = methodBuilder.GetILGenerator();
			ProcessMethodBody(generator);
		}

		public void ProcessConstructor(ConstructorBuilder ctorBuilder) {
			Debug.Assert(this.method == null);
			this.method = ctorBuilder;

			if (methodDef.HasParameters) {
				foreach (ParameterDefinition parameter in methodDef.Parameters) {
					ctorBuilder.DefineParameter(parameter.Sequence, (SR.ParameterAttributes)parameter.Attributes, parameter.Name);
				}
			}

			if (methodDef.HasGenericParameters) {
				throw new NotSupportedException();
			}

			var generator = ctorBuilder.GetILGenerator();
			ProcessMethodBody(generator);
		}

		public void DeclareLocals(ILGenerator generator, VariableDefinitionCollection variables) {
			foreach (VariableDefinition variable in variables) {
				var type = this.hoister.ResolveTypeReference(variable.VariableType);
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
			if (body.CodeSize == 0) {
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

		public object Test(string value1, string value2) {
			var args = new object[2];
			args[0] = value1;
			args[1] = value2;
			return ExternalCall.Invoke(this, args);
		}

		public void GenerateExternMethodBody(ILGenerator generator) {
			var implType = typeof(ExternalCall);
			var implMethod = implType.GetMethod("Invoke");

			bool needsReturn = (this.methodDef.ReturnType.ReturnType.FullName != Constants.Void);

			int indexOffset;
			if (this.methodDef.IsStatic)
				indexOffset = 0;
			else
				indexOffset = 1;

			var argCount = this.methodDef.Parameters.Count;
			var arrayType = typeof(object[]);
			var objType = typeof(object);
			var local = generator.DeclareLocal(arrayType);
			local.SetLocalSymInfo("__args");
			
			LocalBuilder ret = null;
			if (needsReturn) {
				ret = generator.DeclareLocal(objType);
				ret.SetLocalSymInfo("__ret");
			}

			generator.Emit(SRE.OpCodes.Ldc_I4, argCount);
			generator.Emit(SRE.OpCodes.Newarr, objType);
			generator.Emit(SRE.OpCodes.Stloc, local.LocalIndex);

			for (int i = 0; i < argCount; i++) {
				generator.Emit(SRE.OpCodes.Ldloc, local.LocalIndex);
				generator.Emit(SRE.OpCodes.Ldc_I4, i);
				generator.Emit(SRE.OpCodes.Ldarg, i + indexOffset);
				var arg = this.methodDef.Parameters[i];
				if (arg.ParameterType.IsValueType) {
					var argType = Type.GetType(arg.ParameterType.FullName);
					generator.Emit(SRE.OpCodes.Box, argType);
				}
				generator.Emit(SRE.OpCodes.Stelem_Ref);
			}

			if (this.methodDef.IsStatic)
				generator.Emit(SRE.OpCodes.Ldnull);
			else
				generator.Emit(SRE.OpCodes.Ldarg_0);

			generator.Emit(SRE.OpCodes.Ldloc, local.LocalIndex);
			generator.EmitCall(SRE.OpCodes.Call, implMethod, null);

			if (needsReturn) {
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
				default:
					throw new NotSupportedException(string.Format("OperandType: {0}", typeName));
			}
		}

		public void EmitMethod(ILGenerator generator, SRE.OpCode code, MethodReference methodRef) {
			var type = this.hoister.ResolveTypeReference(methodRef.DeclaringType);
			var argTypes = this.hoister.ResolveParameterTypes(methodRef.Parameters);

			var methodBase = this.hoister.ResolveMethodReference(methodRef);
			if (methodBase is ConstructorInfo)
				generator.Emit(code, (ConstructorInfo)methodBase);
			else
				generator.Emit(code, (MethodInfo)methodBase);
		}

		public void EmitType(ILGenerator generator, SRE.OpCode code, TypeReference typeRef) {
			var type = this.hoister.ResolveTypeReference(typeRef);
			generator.Emit(code, type);
		}

		public void EmitField(ILGenerator generator, SRE.OpCode code, FieldReference fieldRef) {
			var type = this.hoister.ResolveTypeReference(fieldRef.DeclaringType);
			var field = type.GetField(fieldRef.Name);
			generator.Emit(code, field);
		}

	}
}
