using System;
using DotWeb.Client.Dom.Events;

namespace DotWeb.Client.Ui
{
	public abstract class Composite : Widget
	{
		public Widget Widget { get; private set; }

		public override bool IsAttached {
			get {
				if (this.Widget != null)
					return this.Widget.IsAttached;
				return false;
			}
		}

		public override void OnBrowserEvent(Event evt) {
			base.OnBrowserEvent(evt);

			this.Widget.OnBrowserEvent(evt);
		}

		protected virtual void InitWidget(Widget widget) {
			if (this.Widget != null) {
				throw new /*IllegalState*/Exception("Composite.initWidget() may only be called once.");
			}

			//widget.removeFromParent();

			// Use the contained widget's element as the composite's element,
			// effectively merging them within the DOM.
			this.Element = widget.Element;

			this.Widget = widget;

			widget.Parent = this;
		}

		protected internal override void OnAttach() {
			//if (!IsOrWasAttached) {
			//    this.Widget.SinkEvents(this.eventsToSink);
			//    this.eventsToSink = Browser.EventFlags.Invalid;
			//}

			this.Widget.OnAttach();

			// Clobber the widget's call to setEventListener(), causing all events to
			// be routed to this composite, which will delegate back to the widget by
			// default (note: it's not necessary to clear this in onDetach(), because
			// the widget's onDetach will do so).
			Browser.SetEventListener(this.Element, this);

			// Call onLoad() directly, because we're not calling super.onAttach().
			OnLoad();
		}

		protected internal override void OnDetach() {
			//try {
				OnUnload();
			//}
			//finally {
				// We don't want an exception in user code to keep us from calling the
				// super implementation (or event listeners won't get cleaned up and
				// the attached flag will be wrong).
				this.Widget.OnDetach();
			//}
		}
	}
}
