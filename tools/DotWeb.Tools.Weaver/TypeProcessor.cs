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
using Mono.Cecil.Metadata;

namespace DotWeb.Tools.Weaver
{
	class TypeProcessor : IType
	{
		public Type Type { get { return this.typeBuilder; } }
		public ModuleBuilder ModuleBuilder { get; private set; }

		private TypeDefinition typeDef;
		private AssemblyProcessor parent;
		private TypeBuilder typeBuilder;
		private Dictionary<MetadataToken, MethodBase> methods = new Dictionary<MetadataToken, MethodBase>();
		private Dictionary<FieldDefinition, FieldBuilder> fields = new Dictionary<FieldDefinition, FieldBuilder>();
		private IResolver resolver;
		private GenericTypeProcessor genericProc;
		private bool isClosing = false;
		private List<TypeProcessor> dependentTypes = new List<TypeProcessor>();
		private List<IType> nestedTypes = new List<IType>();

		public TypeProcessor(IResolver resolver, AssemblyProcessor parent, TypeDefinition typeDef, ModuleBuilder moduleBuilder, TypeBuilder outerBuilder) {
			this.resolver = resolver;
			this.parent = parent;
			this.typeDef = typeDef;
			this.ModuleBuilder = moduleBuilder;
			this.genericProc = new GenericTypeProcessor(this.resolver);

			var typeAttrs = (SR.TypeAttributes)this.typeDef.Attributes;
			this.typeBuilder = outerBuilder.DefineNestedType(this.typeDef.Name, typeAttrs);

			this.Init();
		}

		public TypeProcessor(IResolver resolver, AssemblyProcessor parent, TypeDefinition typeDef, ModuleBuilder moduleBuilder) {
			this.resolver = resolver;
			this.parent = parent;
			this.typeDef = typeDef;
			this.ModuleBuilder = moduleBuilder;
			this.genericProc = new GenericTypeProcessor(this.resolver);

			var typeAttrs = (SR.TypeAttributes)this.typeDef.Attributes;
			this.typeBuilder = moduleBuilder.DefineType(this.typeDef.FullName, typeAttrs);

			this.Init();
		}

		private void Init() {
			if (this.typeDef.HasGenericParameters) {
				this.genericProc.ProcessType(typeDef, typeBuilder);
			}

			if (this.typeDef.BaseType != null) {
				var baseType = ResolveTypeReference(typeDef.BaseType, true);
				this.typeBuilder.SetParent(baseType);
			}

			foreach (TypeReference item in this.typeDef.Interfaces) {
				var type = ResolveTypeReference(item, true);
				this.typeBuilder.AddInterfaceImplementation(type);
			}
		}

		public override string ToString() {
			return string.Format("TypeProcessor: {0}", this.typeBuilder.ToString());
		}

		public void Close() {
			if (this.isClosing)
				return;

			this.isClosing = true;

			foreach (var type in dependentTypes) {
				type.Close();
			}

			this.typeBuilder.CreateType();

			foreach (var type in nestedTypes) {
				type.Close();
			}
		}

		public GenericTypeParameterBuilder GetGenericParameter(string name) {
			return this.genericProc.GetGenericParameter(name);
		}

		public void Process() {
			if (this.typeDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, this.typeDef, this.typeBuilder);
			}

			foreach (FieldDefinition item in this.typeDef.Fields) {
				if (!this.fields.ContainsKey(item))
					ProcessField(item);
			}

			foreach (MethodDefinition item in this.typeDef.Constructors) {
				if (!this.methods.ContainsKey(item.MetadataToken))
					ProcessConstructor(item);
			}

			foreach (MethodDefinition item in this.typeDef.Methods) {
				if (!this.methods.ContainsKey(item.MetadataToken))
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
		}

		private void ProcessNestedType(TypeDefinition typeDef) {
			var nestedType = this.resolver.ResolveTypeReference(typeDef);
			this.nestedTypes.Add(nestedType);
		}

		private void ProcessEvent(EventDefinition eventDef) {
			var eventType = ResolveTypeReference(eventDef.EventType, false);
			var eventBuilder = this.typeBuilder.DefineEvent(eventDef.Name, (SR.EventAttributes)eventDef.Attributes, eventType);

			if (eventDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, eventDef, eventBuilder);
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
			var fieldType = ResolveTypeReference(fieldDef.FieldType, false);
			var fieldBuilder = this.typeBuilder.DefineField(fieldDef.Name, fieldType, (SR.FieldAttributes)fieldDef.Attributes);

			if (fieldDef.HasConstant) {
				if (fieldBuilder.FieldType.IsEnum) {
					object value = Enum.ToObject(fieldBuilder.FieldType, fieldDef.Constant);
					fieldBuilder.SetConstant(value);
				}
				else {
					fieldBuilder.SetConstant(fieldDef.Constant);
				}
			}

			if (fieldDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, fieldDef, fieldBuilder);
			}

			RegisterField(fieldDef, fieldBuilder);

			return fieldBuilder;
		}

		private void ProcessProperty(PropertyDefinition propertyDef) {
			var returnType = ResolveTypeReference(propertyDef.PropertyType, false);
			var argTypes = ResolveParameterTypes(propertyDef.Parameters);
			var propertyBuilder = this.typeBuilder.DefineProperty(propertyDef.Name, (SR.PropertyAttributes)propertyDef.Attributes, returnType, argTypes);

			if (propertyDef.HasConstant) {
				propertyBuilder.SetConstant(propertyDef.Constant);
			}

			if (propertyDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, propertyDef, propertyBuilder);
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

		public MethodBase ResolveMethod(MethodReference methodRef) {
			var methodDef = methodRef.Resolve();
			MethodBase method;
			if (!this.methods.TryGetValue(methodDef.MetadataToken, out method)) {
				method = ProcessMethod(methodDef);
			}

			return method;
		}

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			FieldBuilder field;
			if (!this.fields.TryGetValue(fieldDef, out field)) {
				field = ProcessField(fieldDef);
			}

			return field;
		}

		private void RegisterMethod(MethodDefinition methodDef, MethodBase method) {
			this.methods.Add(methodDef.MetadataToken, method);
		}

		private void RegisterField(FieldDefinition fieldDef, FieldBuilder field) {
			this.fields.Add(fieldDef, field);
		}

		private Type ResolveTypeReference(TypeReference typeRef, bool dependent) {
			if (typeRef is GenericParameter) {
				return this.genericProc.GetGenericParameter(typeRef.Name);
			}

			var type = this.resolver.ResolveTypeReference(typeRef);
			if (dependent) {
				var typeProc = type as TypeProcessor;
				if (typeProc != null)
					this.dependentTypes.Add(typeProc);
			}
			return type.Type;
		}

		private Type[] ResolveParameterTypes(ParameterDefinitionCollection parameters) {
			Type[] ret = new Type[parameters.Count];
			for (int i = 0; i < parameters.Count; i++) {
				var arg = parameters[i];
				var argType = arg.ParameterType;
				ret[i] = ResolveTypeReference(argType, false);
			}
			return ret;
		}
	}
}
