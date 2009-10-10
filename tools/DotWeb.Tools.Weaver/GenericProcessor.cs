using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using System.Reflection.Emit;
using SR = System.Reflection;

namespace DotWeb.Tools.Weaver
{
	class GenericProcessorBase
	{
		private IResolver resolver;
		private Dictionary<string, GenericTypeParameterBuilder> byName = new Dictionary<string, GenericTypeParameterBuilder>();

		protected GenericProcessorBase(IResolver resolver) {
			this.resolver = resolver;
		}

		public GenericTypeParameterBuilder GetGenericParameter(string name) {
			GenericTypeParameterBuilder ret = null;
			this.byName.TryGetValue(name, out ret);
			return ret;
		}

		protected void ProcessParameter(GenericParameter genericParameter, GenericTypeParameterBuilder genericBuilder) {
			genericBuilder.SetGenericParameterAttributes((SR.GenericParameterAttributes)genericParameter.Attributes);

			if (genericParameter.HasConstraints) {
				var interfaces = new List<Type>();
				Type baseTypeConstraint = null;

				foreach (TypeReference item in genericParameter.Constraints) {
					var constraint = item.Resolve();
					var type = resolver.ResolveTypeReference(constraint);
					if (constraint.IsInterface) {
						interfaces.Add(type);
					}
					else {
						baseTypeConstraint = type;
					}
				}

				if (baseTypeConstraint != null) {
					genericBuilder.SetBaseTypeConstraint(baseTypeConstraint);
				}

				if (interfaces.Any()) {
					genericBuilder.SetInterfaceConstraints(interfaces.ToArray());
				}
			}
		}

		protected void ProcessGenericParameters(GenericParameterCollection args, GenericTypeParameterBuilder[] builders) {
			foreach (var builder in builders) {
				byName.Add(builder.Name, builder);
			}

			foreach (GenericParameter arg in args) {
				var builder = byName[arg.Name];
				ProcessParameter(arg, builder);
			}
		}

	}

	class GenericTypeProcessor : GenericProcessorBase
	{
		public GenericTypeProcessor(IResolver resolver)
			: base(resolver) {
		}

		public void ProcessType(TypeDefinition typeDef, TypeBuilder typeBuilder) {
			var names = typeDef.GenericParameters.Cast<GenericParameter>().Select(x => x.Name);
			var builders = typeBuilder.DefineGenericParameters(names.ToArray());
			ProcessGenericParameters(typeDef.GenericParameters, builders);
		}
	}

	class GenericMethodProcessor : GenericProcessorBase
	{
		public GenericMethodProcessor(IResolver resolver)
			: base(resolver) {
		}

		public void ProcessMethod(MethodDefinition methodDef, MethodBuilder methodBuilder) {
			var names = methodDef.GenericParameters.Cast<GenericParameter>().Select(x => x.Name);
			var builders = methodBuilder.DefineGenericParameters(names.ToArray());
			ProcessGenericParameters(methodDef.GenericParameters, builders);
		}
	}
}
