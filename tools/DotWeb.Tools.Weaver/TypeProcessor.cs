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

namespace DotWeb.Tools.Weaver
{
	class TypeProcessor : IType
	{
		public Type Type { get { return this.typeBuilder; } }

		private TypeDefinition typeDef;
		public ModuleBuilder ModuleBuilder { get; private set; }
		private TypeBuilder typeBuilder;
		private Dictionary<MethodDefinition, MethodBase> methodsByDef = new Dictionary<MethodDefinition, MethodBase>();
		private Dictionary<FieldDefinition, FieldBuilder> fieldsByDef = new Dictionary<FieldDefinition, FieldBuilder>();
		private IResolver resolver;
		private GenericTypeProcessor genericProc;

		public TypeProcessor(IResolver resolver, TypeReference typeRef, ModuleBuilder moduleBuilder) {
			this.resolver = resolver;
			this.typeDef = typeRef.Resolve();
			this.ModuleBuilder = moduleBuilder;
			this.genericProc = new GenericTypeProcessor(this.resolver);

			var typeAttrs = (SR.TypeAttributes)this.typeDef.Attributes;

			this.typeBuilder = moduleBuilder.DefineType(this.typeDef.FullName, typeAttrs);

			if (this.typeDef.HasGenericParameters) {
				this.genericProc.ProcessType(typeDef, typeBuilder);
			}

			if (this.typeDef.BaseType != null) {
				var baseType = ResolveTypeReference(typeDef.BaseType);
				this.typeBuilder.SetParent(baseType);
			}
		}

		public void Close() {
			this.typeBuilder.CreateType();
		}

		public GenericTypeParameterBuilder GetGenericParameter(string name) {
			return this.genericProc.GetGenericParameter(name);
		}

		public void ProcessAll() {
			foreach (CustomAttribute item in this.typeDef.CustomAttributes) {
				var ctor = ResolveCustomAttributeCtor(item);
				this.typeBuilder.SetCustomAttribute(ctor, item.Blob ?? new byte[0]);
			}

			foreach (FieldDefinition item in this.typeDef.Fields) {
				if (!this.fieldsByDef.ContainsKey(item))
					ProcessField(item);
			}

			foreach (MethodDefinition item in this.typeDef.Constructors) {
				if (!this.methodsByDef.ContainsKey(item))
					ProcessConstructor(item);
			}

			foreach (MethodDefinition item in this.typeDef.Methods) {
				if (!this.methodsByDef.ContainsKey(item))
					ProcessMethod(item);
			}

			foreach (EventDefinition item in this.typeDef.Events) {
				ProcessEvent(item);
			}

			foreach (PropertyDefinition item in this.typeDef.Properties) {
				ProcessProperty(item);
			}

			foreach (TypeDefinition item in this.typeDef.NestedTypes) {
				ProcessNestedType(item);
			}

			Close();
		}

		private ConstructorInfo ResolveCustomAttributeCtor(CustomAttribute attr) {
			var method = this.resolver.ResolveMethodReference(attr.Constructor);
			var ctor = (ConstructorInfo)method;
			return ctor;
		}

		private void ProcessNestedType(TypeDefinition typeDef) {
//			var nestedType = this.resolver.ResolveTypeReference(typeDef);
		}

		private void ProcessEvent(EventDefinition eventDef) {
			var eventType = ResolveTypeReference(eventDef.EventType);
			var eventBuilder = this.typeBuilder.DefineEvent(eventDef.Name, (SR.EventAttributes)eventDef.Attributes, eventType);

			if (eventDef.HasCustomAttributes) {
				foreach (CustomAttribute item in eventDef.CustomAttributes) {
					var ctor = ResolveCustomAttributeCtor(item);
					eventBuilder.SetCustomAttribute(ctor, item.Blob ?? new byte[0]);
				}
			}

			if (eventDef.AddMethod != null) {
				var method = (MethodBuilder)this.resolver.ResolveMethodReference(eventDef.AddMethod);
				eventBuilder.SetAddOnMethod(method);
			}

			if (eventDef.RemoveMethod != null) {
				var method = (MethodBuilder)this.resolver.ResolveMethodReference(eventDef.RemoveMethod);
				eventBuilder.SetRemoveOnMethod(method);
			}
		}

		private FieldBuilder ProcessField(FieldDefinition fieldDef) {
			var fieldType = ResolveTypeReference(fieldDef.FieldType);
			var fieldBuilder = this.typeBuilder.DefineField(fieldDef.Name, fieldType, (SR.FieldAttributes)fieldDef.Attributes);

			if (fieldDef.HasConstant) {
				fieldBuilder.SetConstant(fieldDef.Constant);
			}

			if (fieldDef.HasCustomAttributes) {
				foreach (CustomAttribute item in fieldDef.CustomAttributes) {
					var ctor = ResolveCustomAttributeCtor(item);
					fieldBuilder.SetCustomAttribute(ctor, item.Blob ?? new byte[0]);
				}
			}

			RegisterField(fieldDef, fieldBuilder);

			return fieldBuilder;
		}

		private void ProcessProperty(PropertyDefinition propertyDef) {
			var returnType = ResolveTypeReference(propertyDef.PropertyType);
			var argTypes = ResolveParameterTypes(propertyDef.Parameters);
			var propertyBuilder = this.typeBuilder.DefineProperty(propertyDef.Name, (SR.PropertyAttributes)propertyDef.Attributes, returnType, argTypes);

			if (propertyDef.HasConstant) {
				propertyBuilder.SetConstant(propertyDef.Constant);
			}

			if (propertyDef.HasCustomAttributes) {
				foreach (CustomAttribute item in propertyDef.CustomAttributes) {
					var ctor = ResolveCustomAttributeCtor(item);
					propertyBuilder.SetCustomAttribute(ctor, item.Blob ?? new byte[0]);
				}
			}

			if (propertyDef.GetMethod != null) {
				var method = this.resolver.ResolveMethodReference(propertyDef.GetMethod);
				propertyBuilder.SetGetMethod((MethodBuilder)method);
			}

			if (propertyDef.SetMethod != null) {
				var method = this.resolver.ResolveMethodReference(propertyDef.SetMethod);
				propertyBuilder.SetSetMethod((MethodBuilder)method);
			}
		}

		public ConstructorInfo ProcessConstructor(MethodDefinition methodDef) {
			var realMethodDef = GetRedirectedMethod(methodDef);
			var argTypes = ResolveParameterTypes(realMethodDef.Parameters);
			var ctorBuilder = this.typeBuilder.DefineConstructor(
				(SR.MethodAttributes)realMethodDef.Attributes, 
				(SR.CallingConventions)realMethodDef.CallingConvention, 
				argTypes);

			// register this before processing the body to deal with circular or recursive references
			RegisterMethod(methodDef, ctorBuilder);

			var methodProc = new MethodProcessor(this.resolver, this, realMethodDef);
			methodProc.ProcessConstructor(ctorBuilder);
			return ctorBuilder;
		}

		public MethodBase ProcessMethod(MethodDefinition methodDef) {
			if (methodDef.IsConstructor)
				return ProcessConstructor(methodDef);

			var realMethodDef = GetRedirectedMethod(methodDef);
			var methodAttrs = (SR.MethodAttributes)realMethodDef.Attributes;

			var methodBuilder = this.typeBuilder.DefineMethod(realMethodDef.Name, methodAttrs);

			// insert this before processing the body to deal with circular or recursive references
			RegisterMethod(methodDef, methodBuilder);

			var methodProc = new MethodProcessor(this.resolver, this, realMethodDef);
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

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			FieldBuilder field;
			if (!this.fieldsByDef.TryGetValue(fieldDef, out field)) {
				field = ProcessField(fieldDef);
			}

			return field;
		}

		private void RegisterMethod(MethodDefinition methodDef, MethodBase method) {
			this.methodsByDef.Add(methodDef, method);
		}

		private void RegisterField(FieldDefinition fieldDef, FieldBuilder field) {
			this.fieldsByDef.Add(fieldDef, field);
		}

		private Type ResolveTypeReference(TypeReference typeRef) {
			if (typeRef is GenericParameter) {
				return this.genericProc.GetGenericParameter(typeRef.Name);
			}

			return this.resolver.ResolveTypeReference(typeRef);
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
