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

namespace DotWeb.Client.Dom.Events
{
	public class MouseEvent : UiEvent
	{
		public int screenX { get { return _<int>(); } }
		public int screenY { get { return _<int>(); } }
		public int clientX { get { return _<int>(); } }
		public int clientY { get { return _<int>(); } }
		public bool ctrlKey { get { return _<bool>(); } }
		public bool shiftKey { get { return _<bool>(); } }
		public bool altKey { get { return _<bool>(); } }
		public bool metaKey { get { return _<bool>(); } }
		public int button { get { return _<int>(); } }
		//public EventTarget relatedTarget;
	}
}
