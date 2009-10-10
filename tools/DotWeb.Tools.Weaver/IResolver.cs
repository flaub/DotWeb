using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using System.Reflection;

namespace DotWeb.Tools.Weaver
{
	interface IResolver
	{
		Type ResolveTypeReference(TypeReference typeRef);
		MethodBase ResolveMethodReference(MethodReference methodRef);
		FieldInfo ResolveFieldReference(FieldReference fieldRef);
//		Type[] ResolveParameterTypes(ParameterDefinitionCollection parameters);
	}
}
