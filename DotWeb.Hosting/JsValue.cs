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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using DotWeb.Utility;

namespace DotWeb.Hosting
{
	public enum JsValueType : byte
	{
		Null,
		Bool,
		Int,
		Double,
		String,
		Object,
		Delegate,
		Void,
		JsObject
	}

	public class JsValue
	{
		public JsValueType Tag { get; set; }
		public object Object { get; set; }

		public int RefId { get { return (int)Object; } }

		public bool IsDelegate { get { return Tag == JsValueType.Delegate; } }
		public bool IsObject { get { return Tag == JsValueType.Object; } }
		public bool IsJsObject { get { return Tag == JsValueType.JsObject; } }
		public bool IsNull { get { return Tag == JsValueType.Null; } }
		public bool IsVoid { get { return Tag == JsValueType.Void; } }

		public JsValue() { }

		public JsValue(JsValueType tag, object value) {
			this.Tag = tag;
			this.Object = value;
		}

		public static JsValue FromPrimitive(object value) {
			if (value == null) {
				return new JsValue(JsValueType.Null, null);
			}
			else if (value is string) {
				return new JsValue((string)value);
			}
			else if (value is int) {
				return new JsValue((int)value);
			}
			else if (value is bool) {
				return new JsValue((bool)value);
			}
			else if (value is double) {
				return new JsValue((double)value);
			}
			string msg = string.Format("Cannot convert to JsValue: {0}", value);
			throw new ArgumentException(msg, "value");
		}

		public JsValue(string value) {
			this.Tag = JsValueType.String;
			this.Object = value;
		}

		public JsValue(int value) {
			this.Tag = JsValueType.Int;
			this.Object = value;
		}

		public JsValue(bool value) {
			this.Tag = JsValueType.Bool;
			this.Object = value;
		}

		public JsValue(double value) {
			this.Tag = JsValueType.Double;
			this.Object = value;
		}

		public void Write(NetworkWriter writer) {
			writer.Write((byte)Tag);
			switch (Tag) {
				case JsValueType.Null:
				case JsValueType.Void:
					break;
				case JsValueType.Bool:
					writer.Write((bool)Object);
					break;
				case JsValueType.Int:
					writer.Write((int)Object);
					break;
				case JsValueType.Double:
					writer.Write((double)Object);
					break;
				case JsValueType.String:
					writer.Write((string)Object);
					break;
				case JsValueType.Object:
				case JsValueType.JsObject:
				case JsValueType.Delegate:
					writer.Write((int)Object);
					break;
				default:
					throw new InvalidDataException();
			}
		}

		public void Read(NetworkReader reader) {
			Tag = (JsValueType)reader.ReadByte();
			switch (Tag) {
				case JsValueType.Null:
				case JsValueType.Void:
					Object = null;
					break;
				case JsValueType.Bool:
					Object = reader.ReadBoolean();
					break;
				case JsValueType.Int:
					Object = reader.ReadInt32();
					break;
				case JsValueType.Double:
					Object = reader.ReadDouble();
					break;
				case JsValueType.String:
					Object = reader.ReadString();
					break;
				case JsValueType.Object:
				case JsValueType.JsObject:
				case JsValueType.Delegate:
					Object = reader.ReadInt32();
					break;
				default:
					throw new InvalidDataException();
			}
		}
	}
}
