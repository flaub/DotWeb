using System;
using Mono.Cecil;
using System.Reflection;

namespace DotWeb.Tools.Weaver
{
	public interface ITypeResolver
	{
		IType ResolveTypeReference(TypeReference typeRef);
	}

	public interface IResolver : ITypeResolver
	{
		MethodBase ResolveMethodReference(MethodReference methodRef);
		FieldInfo ResolveFieldReference(FieldReference fieldRef);
	}
}
