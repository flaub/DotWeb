// Copyright 2010, Frank Laub
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

using System;
using Mono.Cecil;

namespace DotWeb.Utility.Cecil
{
	public static class ConstantTypeNames
	{
		public const string Object = "System.Object";
		public const string Boolean = "System.Boolean";
		public const string Int32 = "System.Int32";
		public const string Delegate = "System.Delegate";
		public const string Exception = "System.Exception";
	}

	public class TypeDefinitionCache
	{
		public TypeDefinitionCache(TypeSystem typeSystem) {
			this.Boolean = typeSystem.GetTypeDefinition(ConstantTypeNames.Boolean);
			this.Int32 = typeSystem.GetTypeDefinition(ConstantTypeNames.Int32);
		}

		public TypeDefinition Boolean { get; private set; }
		public TypeDefinition Int32 { get; private set; }
	}

}
