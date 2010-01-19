using System;
using DotWeb.Client.Dom.Events;

namespace DotWeb.Client
{
	public interface IEventListener
	{
		void OnBrowserEvent(Event evt);
	}
}
