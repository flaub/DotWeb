// Copyright 2009, Frank Laub
// 
// This file is part of DotWeb.
// 
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.
// 

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

namespace DotWeb.Hosting.Weaver
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
		private GenericProcessor genericProc;
		private bool isClosing = false;
		private bool isProcessed = false;
		private HashSet<TypeProcessor> dependentTypes = new HashSet<TypeProcessor>();
		private List<IType> nestedTypes = new List<IType>();

		class DependentTypeResolver : ITypeResolver
		{
			TypeProcessor typeProc;

			public DependentTypeResolver(TypeProcessor typeProc) {
				this.typeProc = typeProc;
			}

			public IType ResolveTypeReference(TypeReference typeRef) {
				return this.typeProc.ResolveTypeReferenceToProc(typeRef, true);
			}
		}

		public TypeProcessor(IResolver resolver, AssemblyProcessor parent, TypeDefinition typeDef, ModuleBuilder moduleBuilder, TypeBuilder outerBuilder) {
			this.resolver = resolver;
			this.parent = parent;
			this.typeDef = typeDef;
			this.ModuleBuilder = moduleBuilder;

			var dtr = new DependentTypeResolver(this);
			this.genericProc = new GenericProcessor(dtr);

			var typeAttrs = (SR.TypeAttributes)this.typeDef.Attributes;
			if (outerBuilder == null) {
				this.typeBuilder = moduleBuilder.DefineType(this.typeDef.FullName, typeAttrs);
			}
			else {
				this.typeBuilder = outerBuilder.DefineNestedType(this.typeDef.Name, typeAttrs);
			}

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

			// This is super super slow thanks to:
			// http://support.microsoft.com/kb/970924
			this.typeBuilder.CreateType();

			foreach (var type in nestedTypes) {
				type.Close();
			}
		}

		public Type GetGenericParameter(TypeReference typeRef) {
			return this.genericProc.GetGenericParameter(typeRef);
		}

		public void Process() {
			if (this.isProcessed)
				return;

			this.isProcessed = true;

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
				// FIXME: Not sure what this was doing here! I have not found a suitable test to make things break without it.
				//if (fieldType.IsEnum) {
				//    object value = Enum.ToObject(fieldType, fieldDef.Constant);
				//    fieldBuilder.SetConstant(value);
				//}
				//else {
					fieldBuilder.SetConstant(fieldDef.Constant);
				//}
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

			if (realMethodDef.HasOverrides) {
				foreach (MethodReference methodRef in realMethodDef.Overrides) {
					var methodDecl = this.resolver.ResolveMethodReference(methodRef);
					this.typeBuilder.DefineMethodOverride(methodBuilder, (MethodInfo)methodDecl);
				}
			}

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

		private IType ResolveTypeReferenceToProc(TypeReference typeRef, bool dependent) {
			var type = this.resolver.ResolveTypeReference(typeRef);
			var typeProc = type as TypeProcessor;
			if (typeProc != null && typeProc != this && (dependent || type.Type.IsEnum)) {
				this.dependentTypes.Add(typeProc);
			}
			return type;
		}

		private Type ResolveTypeReference(TypeReference typeRef, bool dependent) {
			if (typeRef is GenericParameter) {
				return this.genericProc.GetGenericParameter(typeRef);
			}

			return ResolveTypeReferenceToProc(typeRef, dependent).Type;
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
