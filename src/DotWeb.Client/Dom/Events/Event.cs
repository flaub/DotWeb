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
	/// <summary>
	/// The Event interface is used to provide contextual information about an event 
	/// to the handler processing the event. An object which implements the Event interface 
	/// is generally passed as the first parameter to an event handler. 
	/// More specific context information is passed to event handlers by deriving additional 
	/// interfaces from Event which contain information directly relating to the 
	/// type of event they accompany. 
	/// These derived interfaces are also implemented by the object passed to the event listener.
	/// </summary>
	public interface Event
	{
		[JsIntrinsic]
		bool bubbles { get; }

		[JsIntrinsic]
		bool cancelable { get; }

		[JsIntrinsic]
		Window currentTarget { get; }

		[JsIntrinsic]
		Window target { get; }

		[JsIntrinsic]
		int eventPhase { get; }

		[JsIntrinsic]
		int timeStamp { get; }

		[JsIntrinsic]
		string type { get; }

		void stopPropagation();
		void preventDefault();

		void initEvent(string eventType, bool canBubble, bool cancelable);
	}
}
