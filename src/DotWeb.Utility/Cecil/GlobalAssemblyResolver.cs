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
using System.Collections.Generic;
using Mono.Cecil;

namespace DotWeb.Utility.Cecil
{
	public class GlobalAssemblyResolver : BaseAssemblyResolver
	{
		private Dictionary<string, AssemblyDefinition> cache = new Dictionary<string, AssemblyDefinition>();

		public override AssemblyDefinition Resolve(AssemblyNameReference name) {
			AssemblyDefinition ret;
			if (!cache.TryGetValue(name.FullName, out ret)) {
				ret = base.Resolve(name);
				this.cache.Add(ret.Name.FullName, ret);
				if (ret.Name.FullName != name.FullName) {
					this.cache.Add(name.FullName, ret);
				}
				ret.Resolver = this;
			}
			return ret;
		}
	}

}
