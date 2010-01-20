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
using DotWeb.Client.Dom.Events;

namespace DotWeb.Client.Ui
{
	public interface IHasWidgets
	{
		void Add(Widget widget);
		void Clear();
		bool Remove(Widget widget);
	}

	public abstract class Widget : UiObject, IEventListener
	{
		//protected Browser.EventFlags eventsToSink;
		private Widget parent;

		private MouseEventHandler onClick;

		public event MouseEventHandler Click {
			add {
				if(this.onClick == null)
					this.Element.onclick = Browser.DispatchEvent;
				this.onClick = value;
			}
			remove {
				this.onClick = value;
				if(this.onClick == null)
					this.Element.onclick = null;
			}
		}

		//public event MouseEventHandler MouseUp;
		//public event MouseEventHandler MouseDown;
		//public event MouseEventHandler MouseMove;

		public virtual void OnBrowserEvent(Event evt) {
			switch (evt.type) {
				case "click":
					this.onClick((MouseEvent)evt);
					break;
			}
			//    switch (DOM.eventGetType(evt)) {
			//        case Event.ONMOUSEOVER:
			//// Only fire the mouse over event if it's coming from outside this
			//// widget.
			//        case Event.ONMOUSEOUT:
			//// Only fire the mouse out event if it's leaving this
			//// widget.
			//            {		
			//Element related = evt.getRelatedTarget();
			//if (related != null && getElement().isOrHasChild(related)) {
			//  return;
			//}
			//            }

			//break;
			//    }
			//DomEvent.fireNativeEvent(evt, this, this.getElement());
		}

		public virtual bool IsAttached { get; private set; }

		public Widget Parent {
			get { return this.parent; }
			set {
				var oldParent = this.parent;
				if (value == null) {
					//try {
					if (oldParent != null && oldParent.IsAttached) {
						OnDetach();
						//assert !isAttached() : "Failure of " + this.getClass().getName()
						//+ " to call super.onDetach()";
					}
					//}
					//finally {
					// Put this in a finally in case onDetach throws an exception.
					this.parent = null;
					//}
				}
				else {
					if (oldParent != null) {
						throw new /*IllegalStateException*/Exception("Cannot set a new parent without first clearing the old parent");
					}
					this.parent = value;
					if (value.IsAttached) {
						OnAttach();
						//assert isAttached() : "Failure of " + this.getClass().getName()
						//+ " to call super.onAttach()";
					}
				}
			}
		}

		/// <summary>
		/// <para>
		/// This method is called when a widget is attached to the browser's document.
		/// To receive notification after a Widget has been added to the document,
		/// override the {@link #onLoad} method.
		/// </para>
		/// <para>
		/// It is strongly recommended that you override {@link #onLoad()} or
		/// {@link #doAttachChildren()} instead of this method to avoid
		/// inconsistencies between logical and physical attachment states. 
		/// </para>
		/// <para>
		/// Subclasses that override this method must call
		/// <code>super.onAttach()</code> to ensure that the Widget has been attached
		/// to its underlying Element.
		/// </para>
		/// </summary>
		protected internal virtual void OnAttach() {
			if (IsAttached) {
				throw new /*IllegalState*/Exception("Should only call onAttach when the widget is detached from the browser's document");
			}

			this.IsAttached = true;

			// Event hookup code
			Browser.SetEventListener(this.Element, this);
			//var bitsToAdd = this.eventsToSink;
			//this.eventsToSink = Browser.EventFlags.Invalid;
			//if (bitsToAdd != Browser.EventFlags.None) {
			//    SinkEvents(bitsToAdd);
			//}
			DoAttachChildren();

			// onLoad() gets called only *after* all of the children are attached and
			// the attached flag is set. This allows widgets to be notified when they
			// are fully attached, and panels when all of their children are attached.
			OnLoad();
		}

		protected internal virtual void OnDetach() {
			if (!IsAttached) {
				throw new /*IllegalState*/Exception("Should only call onDetach when the widget is attached to the browser's document");
			}

			//try {
			// onUnload() gets called *before* everything else (the opposite of
			// onLoad()).
			OnUnload();
			//}
			//finally {
			// Put this in a finally, just in case onUnload throws an exception.
			//try {
			DoDetachChildren();
			//}
			//finally {
			// Put this in a finally, in case doDetachChildren throws an exception.
			//Browser.SetEventListener(this.Element, null);
			this.IsAttached = false;
			//}
			//}
		}

		protected virtual void OnLoad() { }

		protected virtual void OnUnload() { }

		/// <summary>
		/// If a widget contains one or more child widgets that are not in the logical
		/// widget hierarchy (the child is physically connected only on the DOM level),
		/// it must override this method and call {@link #onAttach()} for each of its
		/// child widgets.
		/// </summary>
		protected virtual void DoAttachChildren() { }

		/// <summary>
		/// If a widget contains one or more child widgets that are not in the logical
		/// widget hierarchy (the child is physically connected only on the DOM level),
		/// it must override this method and call {@link #onDetach()} for each of its
		/// child widgets.
		/// </summary>
		protected virtual void DoDetachChildren() { }

		//protected bool IsOrWasAttached {
		//    get { return eventsToSink == Browser.EventFlags.Invalid; }
		//}

		public void RemoveFromParent() {
			if (this.parent != null) {
				((IHasWidgets)this.parent).Remove(this);
			}
		}

	}
}
