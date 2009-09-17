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

namespace DotWeb.Client.Dom
{
	public abstract class NamedNodeMap : JsNativeBase
	{
		public Node getNamedItem(string name) { return _<Node>(name); }
		public Node setNamedItem(Node node) { return _<Node>(node); }
		public Node removeNamedItem(string name) { return _<Node>(name); }

		[JsIntrinsic]
		public int length { get { return _<int>(); } }


		#region DOM Level 2
		public Node getNamedItemNS(string namespaceURI, string localName) { return _<Node>(namespaceURI, localName); }
		public Node setNamedItemNS(Node arg) { return _<Node>(arg); }
		public Node removeNamedItemNS(string namespaceURI, string localName) { return _<Node>(namespaceURI, localName); }
		#endregion
	}
}
