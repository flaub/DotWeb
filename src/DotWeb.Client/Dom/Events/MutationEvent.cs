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
	public enum AttrChangeType
	{
		MODIFICATION = 1,
		ADDITION = 2,
		REMOVAL = 3,
	}

	public interface MutationEvent : Event
	{
		Node relatedNode { get; }
		string prevValue { get; }
		string newValue { get; }
		string attrName { get; }
		AttrChangeType attrChange { get; }

		void initMutationEvent(
			string type,
			bool canBubble,
			bool cancelable,
			Node relatedNode,
			string prevValue,
			string newValue,
			string attrName,
			AttrChangeType attrChange);
	}

	public delegate void MutationEventHandler(MutationEvent evt);
}
