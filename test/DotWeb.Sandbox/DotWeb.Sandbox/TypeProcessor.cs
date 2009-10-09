using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Mono.Cecil.Cil;
using SR = System.Reflection;
using SRE = System.Reflection.Emit;
using System.Collections;

namespace DotWeb.Sandbox
{
	class TypeProcessor : IType
	{
		public Type Type { get { return this.typeBuilder; } }

		private TypeDefinition typeDef;
		public ModuleBuilder ModuleBuilder { get; private set; }
		private TypeBuilder typeBuilder;
		private Dictionary<MethodDefinition, MethodBase> methodsByDef = new Dictionary<MethodDefinition, MethodBase>();
		private Hoister hoister;

		public TypeProcessor(Hoister hoister, TypeReference typeRef, ModuleBuilder moduleBuilder) {
			this.hoister = hoister;
			this.typeDef = typeRef.Resolve();
			this.ModuleBuilder = moduleBuilder;

			var parent = this.hoister.ResolveTypeReference(typeDef.BaseType);
			this.typeBuilder = moduleBuilder.DefineType(this.typeDef.FullName, (SR.TypeAttributes)this.typeDef.Attributes, parent);
		}

		public void Close() {
			this.typeBuilder.CreateType();
		}

		public ConstructorInfo ProcessConstructor(bool isStatic, Type[] args) {
			var methodDef = this.typeDef.Constructors.GetConstructor(isStatic, args);
			return ProcessConstructor(methodDef);
		}

		public ConstructorInfo ProcessConstructor(MethodDefinition methodDef) {
			var realMethodDef = GetRedirectedMethod(methodDef);
			var argTypes = this.hoister.ResolveParameterTypes(realMethodDef.Parameters);
			var ctorBuilder = this.typeBuilder.DefineConstructor(
				(SR.MethodAttributes)realMethodDef.Attributes, 
				(SR.CallingConventions)realMethodDef.CallingConvention, 
				argTypes);

			// register this before processing the body to deal with circular or recursive references
			RegisterMethod(methodDef, ctorBuilder);

			var methodProc = new MethodProcessor(this.hoister, this, realMethodDef);
			methodProc.ProcessConstructor(ctorBuilder);
			return ctorBuilder;
		}

		public MethodBase ProcessMethod(MethodDefinition methodDef) {
			if (methodDef.IsConstructor)
				return ProcessConstructor(methodDef);

			var realMethodDef = GetRedirectedMethod(methodDef);
			var returnType = this.hoister.ResolveTypeReference(realMethodDef.ReturnType.ReturnType);
			var argTypes = this.hoister.ResolveParameterTypes(realMethodDef.Parameters);
			var methodBuilder = this.typeBuilder.DefineMethod(
				realMethodDef.Name, 
				(SR.MethodAttributes)realMethodDef.Attributes, 
				returnType, 
				argTypes);

			// insert this before processing the body to deal with circular or recursive references
			RegisterMethod(methodDef, methodBuilder);

			var methodProc = new MethodProcessor(this.hoister, this, realMethodDef);
			methodProc.ProcessMethod(methodBuilder);
			return methodBuilder;
		}

		private MethodDefinition GetRedirectedMethod(MethodDefinition methodDef) {
			var ns = methodDef.DeclaringType.Namespace;
			if (ns.StartsWith("System")) {
				return ResolveWithThisType(methodDef);
			}
			return methodDef;
		}

		private MethodDefinition ResolveWithThisType(MethodDefinition methodDef) {
			var methodRef = new MethodReference(
				methodDef.Name,
				this.typeDef,
				methodDef.ReturnType.ReturnType,
				methodDef.HasThis,
				methodDef.ExplicitThis,
				methodDef.CallingConvention);
		
			foreach (GenericParameter item in methodDef.GenericParameters) {
				methodRef.GenericParameters.Add(item);
			}
			
			foreach (ParameterDefinition item in methodDef.Parameters) {
				methodRef.Parameters.Add(item);
			}

			return methodRef.Resolve();
		}

		public MethodBase ResolveMethod(MethodDefinition methodDef) {
			MethodBase method;
			if (!this.methodsByDef.TryGetValue(methodDef, out method)) {
				method = ProcessMethod(methodDef);
			}

			return method;
		}

		private void RegisterMethod(MethodDefinition methodDef, MethodBase method) {
			this.methodsByDef.Add(methodDef, method);
		}
	}
}
