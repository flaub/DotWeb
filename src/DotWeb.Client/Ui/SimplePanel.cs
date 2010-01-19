using System;
using DotWeb.Client.Dom.Html;
using DotWeb.Client.Dom.Helper;

namespace DotWeb.Client.Ui
{
	public class SimplePanel : Panel
	{
		private Widget widget;

		public SimplePanel() 
			: this(ElementFactory.CreateDiv()) {
		}

		protected SimplePanel(HtmlElement element) {
			this.Element = element;
		}

		public Widget Widget {
			get { return this.widget; }
			set {
				if (this.widget == value)
					return;

				if (value != null) {
					value.RemoveFromParent();
				}

				if (this.widget != null) {
					Remove(this.widget);
				}

				this.widget = value;

				if (value != null) {
					this.Element.appendChild(this.widget.Element);
				}
			}
		}

		public override void Add(Widget widget) {
			if (this.widget != null) {
				throw new Exception("SimplePanel can only contain one child widget");
			}
			this.Widget = widget;
		}

		public override bool Remove(Widget widget) {
			if (this.widget != widget) {
				return false;
			}

			Orphan(widget);

			this.Element.removeChild(widget.Element);

			this.widget = null;

			return true;
		}
	}
}
