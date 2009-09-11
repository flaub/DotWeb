﻿// Copyright 2009, Frank Laub
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
using DotWeb.Client;

namespace DotWeb.Sample.Script.Test
{
	[JsNamespace]
	internal class NativeCaller : JsNativeBase
	{
		public NativeCaller(object cfg) { C_(cfg); }

		public void Start() { _(); }
	}

	[JsNamespace]
	internal class NativeObject : JsNativeBase
	{
		public NativeObject() { C_(); }

		public void NativeCall() { _(); }
	}

	public class NativeCallback : JsScript
	{
		public NativeCallback() {
			Console.Write("Hi");

			var obj = new NativeObject();
			Console.Write(obj);

			var cfg = new Config {
				nativeObject = obj
			};
			Console.Write(cfg);

			var caller = new NativeCaller(cfg);
			Console.Write(caller);

			caller.Start();
		}

		#region Nested type: Config

		[JsAnonymous]
		private class Config
		{
			public NativeObject nativeObject { get; set; }
		}

		#endregion

		#region Nested type: Console

		private class Console
		{
			[JsCode("console.log(obj);")]
			public static void Write(object obj) { JsHost.S_(obj); }
		}

		#endregion
	}
}