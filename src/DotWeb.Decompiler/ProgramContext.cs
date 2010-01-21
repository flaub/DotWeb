using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace DotWeb.Decompiler
{
	public class ProgramContext
	{
		public Dictionary<MethodDefinition, MethodContext> MethodContextMap { get; private set; }
	}

	public class MethodContext
	{
		public MethodDefinition Definition { get; set; }
		public Dictionary<ParameterDefinition, ParameterContext> Parameters { get; private set; }
		public List<InstanceContext> Instances { get; private set; }

		public MethodContext(MethodDefinition def) {
			this.Definition = def;
			this.Parameters = new Dictionary<ParameterDefinition, ParameterContext>();
			this.Instances = new List<InstanceContext>();
		}

		public void InitParameters() {
			foreach (ParameterDefinition def in this.Definition.Parameters) {
				var context = new ParameterContext(this.Definition, def);
				this.Parameters.Add(def, context);
			}
		}
	}

	public class ParameterContext
	{
		public MethodDefinition Method { get; set; }
		public ParameterDefinition Parameter { get; set; }
		public List<InstanceContext> Instances { get; private set; }

		public ParameterContext(MethodDefinition method, ParameterDefinition parameter) {
			this.Method = method;
			this.Parameter = parameter;
			this.Instances = new List<InstanceContext>();
		}
	}

	public class InstanceContext
	{
		public TypeReference DeclaredType { get; set; }
		public List<TypeReference> ConcreteTypes { get; private set; }
	}
}
