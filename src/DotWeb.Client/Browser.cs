using System;
using DotWeb.Client.Dom;
using System.DotWeb;
using DotWeb.Client.Dom.Events;
using DotWeb.Client.Dom.Html;

namespace DotWeb.Client
{
	public static class Browser
	{
		[Flags]
		public enum EventFlags
		{
			Invalid = -1,
			None = 0x0000,
			Click = 0x00001,
			DblClick = 0x00002,
			MouseDown = 0x00004,
			MouseUp = 0x00008,
			MouseOver = 0x00010,
			MouseOut = 0x00020,
			MouseMove = 0x00040,
			KeyDown = 0x00080,
			KeyPress = 0x00100,
			KeyUp = 0x00200,
			Change = 0x00400,
			Focus = 0x00800,
			Blur = 0x01000,
			LoseCapture = 0x02000,
			Scroll = 0x04000,
			Load = 0x08000,
			Error = 0x10000,
			MouseWheel = 0x20000,
			ContextMenu = 0x40000,
			Paste = 0x80000,
		}

		/// <summary>
		/// Sets the current set of events sunk by a given element. These events will
		/// be fired to the nearest {@link EventListener} specified on any of the
		/// element's parents.
		/// </summary>
		/// <param name="elem">the element whose events are to be retrieved</param>
		/// <param name="eventBits">
		/// a bitfield describing the events sunk on this element (its possible values 
		/// are described in {@link Event})
		/// </param>
		public static void SinkEvents(Element elem, EventFlags eventBits) {
//			impl.sinkEvents(elem, eventBits);
		}

		public static EventFlags GetEventsSunk(Element elem) {
			return 0;
		}

		[JsCode("element.__listener = listener;")]
		public static extern void SetEventListener(HtmlElement element, IEventListener listener);

		private static extern HtmlElement This {
			[JsMacro("this")]
			get;
		}

		[JsCode("return element.__listener")]
		private static extern IEventListener GetEventListener(HtmlElement element);

		public static void DispatchEvent(Event evt) {
			var listener = GetEventListener(This);
			listener.OnBrowserEvent(evt);
		}
	}
}
