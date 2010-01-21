using System;
using DotWeb.Client;
using DotWeb.Client.Dom;

namespace DotWeb.Functional.Test.Client
{
	public class Sanity : JsScript
	{
		public Sanity() {
//			Log.Write("Hello World!");
			var height = Document.body.scrollHeight;
			Log.Write(height);
		}

		int GetInt() {
			object ret = GetObject();
			return (int)ret;
		}

		object GetObject() {
			return 1;
		}
	}
}
