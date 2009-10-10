using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Mono.Cecil;

namespace DotWeb.Tools.Weaver
{
	class ExternalType : IType
	{
		private IResolver resolver;

		private const BindingFlags Flags =
			BindingFlags.DeclaredOnly | 
			BindingFlags.Instance | 
			BindingFlags.Static |
			BindingFlags.Public | 
			BindingFlags.NonPublic;

		public ExternalType(IResolver resolver, Type type) {
			this.resolver = resolver;
			this.Type = type;
		}

		public Type Type { get; private set; }

		public MethodBase ResolveMethod(MethodDefinition methodDef) {
			var argDefs = methodDef.Parameters.Cast<ParameterDefinition>();
			var types = argDefs.Select(x => this.resolver.ResolveTypeReference(x.ParameterType)).ToArray();
			if (methodDef.IsConstructor) {
				return this.Type.GetConstructor(Flags, Type.DefaultBinder, types, null);
			}
			else {
				return this.Type.GetMethod(methodDef.Name, Flags, Type.DefaultBinder, types, null);
			}
		}

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			return this.Type.GetField(fieldDef.Name, Flags);
		}

		public void Close() {
		}
	}
}
