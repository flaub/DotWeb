using System;
using System.DotWeb;
using DotWeb.Client.Dom.Html;

namespace DotWeb.Client.Ui
{
	public abstract class UiObject
	{
		public HtmlElement Element { get; protected set; }

		public bool Visible {
			get { return this.Element.Visible; }
			set { this.Element.Visible = value; }
		}

		public virtual void SinkEvents(Browser.EventFlags eventBitsToAdd) {
			Browser.SinkEvents(this.Element, eventBitsToAdd | Browser.GetEventsSunk(this.Element));
		}

		public virtual void UnsinkEvents(Browser.EventFlags eventBitsToRemove) {
			Browser.SinkEvents(this.Element, Browser.GetEventsSunk(this.Element) & (~eventBitsToRemove));
		}
	}
}
