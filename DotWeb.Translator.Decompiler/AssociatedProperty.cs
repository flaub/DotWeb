using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Translator
{
	public class AssociatedProperty
	{
		public PropertyInfo Info { get; set; }
		public bool IsGetter { get; set; }
	}

	public static class MethodBaseExtensions
	{
		public static AssociatedProperty GetAssociatedProperty(this MethodBase method) {
			if (method.IsSpecialName) {
				if (method.Name.StartsWith("get_")) {
					string propName = method.Name.Substring("get_".Length);
					PropertyInfo pi = method.DeclaringType.GetProperty(propName);
					return new AssociatedProperty {
						Info = pi,
						IsGetter = true
					};
				}
				else if (method.Name.StartsWith("set_")) {
					string propName = method.Name.Substring("set_".Length);
					PropertyInfo pi = method.DeclaringType.GetProperty(propName);
					return new AssociatedProperty {
						Info = pi,
						IsGetter = false
					};
				}
			}

			return null;
		}
	}

}
