// Copyright 2009, Frank Laub
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

using System;

namespace DotWeb.Client
{
	/// <summary>
	/// Classes decorated with this attribute mean that they
	/// won't be emitted as normal JavaScript classes.
	/// Instead, they are anonymous, which puts a number of restrictions
	/// on this class.
	/// For example, only fields and auto-implemented properties 
	/// are supported.
	/// Note that [JsIntrinsic] is implied for all properties defined 
	/// on the decorated class.
	/// <example>
	/// The following C# code gets translated from:
	/// <code>
	/// [JsAnonymous]
	/// class Config
	/// {
	///		public int X { get; set; }
	///		public int y;
	/// }
	/// 
	/// class Test
	/// {
	///		void UseConfig()
	///		{
	///			var item = new AnonymousClass {
	///				X = 1,
	///				y = 2
	///			};
	///			
	///			item.X = item.y;
	///			item.y = item.X;
	///		}
	///	}
	/// </code>
	/// Into the following JavaScript code:
	/// <code>
	/// Test.prototype.UseConfig = function() {
	///		var loc1 = {};
	///		loc1.X = 1;
	///		loc1.y = 2;
	///		var loc0 = loc1;
	///		loc0.X = loc0.y;
	///		loc0.y = loc0.X;
	///	};
	/// </code>
	/// </example>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class JsAnonymousAttribute : Attribute
	{
	}
}
