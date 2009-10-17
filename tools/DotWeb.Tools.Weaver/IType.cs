using System;
using System.Reflection;
using Mono.Cecil;

namespace DotWeb.Tools.Weaver
{
	public interface IType
	{
		Type Type { get; }
		MethodBase ResolveMethod(MethodReference methodRef);
		FieldInfo ResolveField(FieldDefinition fieldDef);
		void Close();

		void Process();
	}

}
