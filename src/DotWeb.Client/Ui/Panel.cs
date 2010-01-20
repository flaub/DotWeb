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

namespace DotWeb.Client.Ui
{
	public abstract class Panel : Widget, IHasWidgets
	{
		#region IHasWidgets Members

		public virtual void Add(Widget widget) {
			throw new NotImplementedException();
		}

		public virtual void Clear() {
			throw new NotImplementedException();
		}

		public abstract bool Remove(Widget widget);

		#endregion

		protected void Adopt(Widget child) {
			//assert(child.getParent() == null);
			child.Parent = this;
		}

		protected void Orphan(Widget child) {
			//assert (child.getParent() == this);
			child.Parent = null;
		}
	}
}
