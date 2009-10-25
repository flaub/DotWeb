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

namespace DotWeb.Decompiler
{
	public class AssociatedProperty
	{
		public PropertyDefinition Definition { get; set; }
		public bool IsGetter { get; set; }
	}

	public static class MethodDefinitionExtensions
	{
		public static AssociatedProperty GetAssociatedProperty(this MethodDefinition method) {
			if (method.IsSpecialName) {
				var type = method.DeclaringType;

				if (method.Name.StartsWith("get_")) {
					string propName = method.Name.Substring("get_".Length);
					var properties = type.Properties.GetProperties(propName);
					return new AssociatedProperty {
						Definition = properties[0],
						IsGetter = true
					};
				}

				if (method.Name.StartsWith("set_")) {
					string propName = method.Name.Substring("set_".Length);
					var properties = type.Properties.GetProperties(propName);
					return new AssociatedProperty {
						Definition = properties[0],
						IsGetter = false
					};
				}
			}

			return null;
		}
	}

}
