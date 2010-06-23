// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

using System.Reflection;
using Mono.Cecil;
using System.Linq;

namespace DotWeb.Utility
{
	public class MonoAssociatedProperty
	{
		public PropertyDefinition Definition { get; set; }
		public bool IsGetter { get; set; }
	}

	public class ReflectedAssociatedProperty
	{
		public PropertyInfo Info { get; set; }
		public bool IsGetter { get; set; }
	}

	public static class AssociatedPropertyExtensions
	{
		public static PropertyDefinition GetProperty(this TypeDefinition type, string name) {
			return type.Properties.Where(x => x.Name == name).FirstOrDefault();
		}

		public static MonoAssociatedProperty GetMonoAssociatedProperty(this MethodDefinition method) {
			if (method.IsSpecialName) {
				var type = method.DeclaringType;

				if (method.Name.StartsWith("get_")) {
					string propName = method.Name.Substring("get_".Length);
					return new MonoAssociatedProperty {
						Definition = type.GetProperty(propName),
						IsGetter = true
					};
				}

				if (method.Name.StartsWith("set_")) {
					string propName = method.Name.Substring("set_".Length);
					return new MonoAssociatedProperty {
						Definition = type.GetProperty(propName),
						IsGetter = false
					};
				}
			}

			return null;
		}

		public static ReflectedAssociatedProperty GetReflectedAssociatedProperty(this MethodBase method) {
			if (!(method is MethodInfo))
				return null;

			if (method.IsSpecialName) {
				var type = method.DeclaringType;

				if (method.Name.StartsWith("get_")) {
					string propName = method.Name.Substring("get_".Length);
					return new ReflectedAssociatedProperty {
						Info = type.GetProperty(propName),
						IsGetter = true
					};
				}

				if (method.Name.StartsWith("set_")) {
					string propName = method.Name.Substring("set_".Length);
					return new ReflectedAssociatedProperty {
						Info = type.GetProperty(propName),
						IsGetter = false
					};
				}
			}

			return null;
		}
	}

}
