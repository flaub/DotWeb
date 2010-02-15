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
using System.Text;
using System.Reflection.Emit;
using Mono.Cecil;
using System.Reflection;
using System.Collections;

namespace DotWeb.Hosting.Weaver
{
	static class CustomAttributeProcessor
	{
		static CustomAttributeBuilder Process(IResolver resolver, CustomAttribute customAttribute, IGenericScope genericScope) {
			var ctor = (ConstructorInfo)resolver.ResolveMethodReference(customAttribute.Constructor, genericScope);
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

		public static void Process(IResolver resolver, PropertyDefinition def, PropertyBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, FieldDefinition def, FieldBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, MethodDefinition def, MethodBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, MethodDefinition def, ConstructorBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, TypeDefinition def, TypeBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, EventDefinition def, EventBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, AssemblyDefinition def, AssemblyBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}

		public static void Process(IResolver resolver, TypeDefinition def, EnumBuilder builder, IGenericScope genericScope) {
			foreach (CustomAttribute item in def.CustomAttributes) {
				if (item.Blob == null) {
					builder.SetCustomAttribute(CustomAttributeProcessor.Process(resolver, item, genericScope));
				}
				else {
					var ctor = (ConstructorInfo)resolver.ResolveMethodReference(item.Constructor, genericScope);
					builder.SetCustomAttribute(ctor, item.Blob);
				}
			}
		}
	}
}
