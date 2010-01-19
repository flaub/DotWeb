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
