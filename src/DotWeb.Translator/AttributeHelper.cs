using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using DotWeb.Utility.Cecil;

namespace DotWeb.Translator
{
	public static class AttributeHelper
	{
		public static string GetJsCode(MethodDefinition method) {
			foreach (CustomAttribute item in method.CustomAttributes) {
				if (item.Constructor.DeclaringType.FullName == JsCode) {
					var args = item.ConstructorParameters;
					return (string)args[0];
				}
			}
			return null;
		}

		public static string GetJsNamespace(TypeReference typeRef) {
			foreach (CustomAttribute item in typeRef.CustomAttributes) {
				if (item.Constructor.DeclaringType.FullName == JsNamespace) {
					var args = item.ConstructorParameters;
					if (args.Count == 1)
						return (string)args[0];
					return "";
				}
			}
			return null;
		}

		public static bool IsAnonymous(TypeReference type) {
			return TypeHelper.IsDefined(type, JsAnonymous);
		}

		public static bool IsIntrinsic(PropertyReference pi) {
			return
				TypeHelper.IsDefined(pi.Resolve(), JsInstrinsic) ||
				TypeHelper.IsDefined(pi.DeclaringType, JsInstrinsic);
		}

		private const string JsNamespace = "System.DotWeb.JsNamespaceAttribute";
		private const string JsCode = "System.DotWeb.JsCodeAttribute";
		private const string JsInstrinsic = "System.DotWeb.JsIntrinsicAttribute";
		private const string JsAnonymous = "System.DotWeb.JsAnonymousAttribute";
	}
}
