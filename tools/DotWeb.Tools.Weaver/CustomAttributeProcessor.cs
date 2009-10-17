using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using Mono.Cecil;
using System.Reflection;
using System.Collections;

namespace DotWeb.Tools.Weaver
{
	static class CustomAttributeProcessor
	{
		static CustomAttributeBuilder Process(IResolver resolver, CustomAttribute customAttribute) {
			var ctor = (ConstructorInfo)resolver.ResolveMethodReference(customAttribute.Constructor);
			var type = ctor.DeclaringType;

			var ctorArgs = customAttribute.ConstructorParameters.Cast<object>().ToArray();

			var namedProperties = new PropertyInfo[customAttribute.Properties.Count];
			var propertyValues = new object[customAttribute.Properties.Count];
			var namedFields = new FieldInfo[customAttribute.Fields.Count];
			var fieldValues = new object[customAttribute.Fields.Count];

			int i = 0;
			foreach (DictionaryEntry entry in customAttribute.Properties) {
				string name = (string)entry.Key;
				var property = type.GetProperty(name);
				namedProperties[i] = property;
				propertyValues[i] = entry.Value;
				++i;
			}

			i = 0;
			foreach (DictionaryEntry entry in customAttribute.Fields) {
				string name = (string)entry.Key;
				var field = type.GetField(name);
				namedFields[i] = field;
				fieldValues[i] = entry.Value;
				++i;
			}

			var builder = new CustomAttributeBuilder(ctor, ctorArgs, namedProperties, propertyValues, namedFields, fieldValues);
			return builder;
		}

		public static void Process(IResolver resolver, PropertyDefinition def, PropertyBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, FieldDefinition def, FieldBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, MethodDefinition def, MethodBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, MethodDefinition def, ConstructorBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, TypeDefinition def, TypeBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, EventDefinition def, EventBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, AssemblyDefinition def, AssemblyBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, TypeDefinition def, EnumBuilder builder) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}
	}
}
