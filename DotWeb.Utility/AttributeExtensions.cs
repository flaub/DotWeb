using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Utility
{
	public static class AttributeExtensions
	{
		public static R GetCustomAttribute<R>(this MemberInfo member) where R : Attribute {
			return Attribute.GetCustomAttribute(member, typeof(R)) as R;
		}

		public static R GetCustomAttribute<R>(this Type type) where R : Attribute {
			return Attribute.GetCustomAttribute(type, typeof(R)) as R;
		}
	}

}
