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
