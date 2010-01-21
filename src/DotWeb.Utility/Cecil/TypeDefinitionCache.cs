using System;
using Mono.Cecil;

namespace DotWeb.Utility.Cecil
{
	public static class ConstantTypeNames
	{
		public const string Delegate = "System.Delegate";
		public const string JsObject = "System.DotWeb.JsObject";
	}

	public class TypeDefinitionCache
	{
		public TypeDefinitionCache(TypeSystem typeSystem) {
			this.Object = typeSystem.GetTypeDefinition(Constants.Object);
			this.JsObject = typeSystem.GetTypeDefinition(ConstantTypeNames.JsObject);
			this.Delegate = typeSystem.GetTypeDefinition(ConstantTypeNames.Delegate);
		}

		public TypeDefinition Object { get; private set; }
		public TypeDefinition JsObject { get; private set; }
		public TypeDefinition Delegate { get; private set; }
	}

}
