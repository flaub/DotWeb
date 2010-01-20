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
// 
using System;

#if HOSTED_MODE
namespace DotWeb.System.Collections.Generic
#else
namespace System.Collections.Generic
#endif
{
//	[TypeDependency("System.SZArrayHelper")]
	public interface ICollection<T> : IEnumerable<T>, IEnumerable
	{
		// Methods
		void Add(T item);
		void Clear();
		bool Contains(T item);
		void CopyTo(T[] array, int arrayIndex);
		bool Remove(T item);

		// Properties
		int Count { get; }
		bool IsReadOnly { get; }
	}
}
