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
		public const string Delegate = "System.Delegate";
		public const string Exception = "System.Exception";
		public const string JsObject = "System.DotWeb.JsObject";
	}

	public class TypeDefinitionCache
	{
		public TypeDefinitionCache(TypeSystem typeSystem) {
			this.Object = typeSystem.GetTypeDefinition(Constants.Object);
			this.JsObject = typeSystem.GetTypeDefinition(ConstantTypeNames.JsObject);
			this.Delegate = typeSystem.GetTypeDefinition(ConstantTypeNames.Delegate);
			this.Exception = typeSystem.GetTypeDefinition(ConstantTypeNames.Exception);
		}

		public TypeDefinition Object { get; private set; }
		public TypeDefinition JsObject { get; private set; }
		public TypeDefinition Delegate { get; private set; }
		public TypeDefinition Exception { get; private set; }
	}

}
