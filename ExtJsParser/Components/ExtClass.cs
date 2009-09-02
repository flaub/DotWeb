using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;

namespace SourceConverter.Components
{
	[DebuggerDisplay("{FullyQualifiedName}")]
	public class ExtClass
	{
		public string SourceFile;

		public string Name;
		public string Namespace;
		public string SuperClass;
		public bool Singleton;
		public ExtDescription Description;
		public ExtConstructorCollection Constructors;
		public ExtPropertyCollection Properties;
		public ExtMethodCollection Methods;
		public ExtEventCollection Events;
		public ExtConfigCollection Configs;

		public string FullyQualifiedName { get { return String.IsNullOrEmpty(Namespace) ? Name : Namespace + "." + Name; } }

		public string ToExtSharp() {
			string newName = ExtType.ParseClassName(FullyQualifiedName);
			if (newName != Name) {
				SourceConverter.ClassAliases.Add(FullyQualifiedName, FullyQualifiedName.Replace(Name, newName));
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("using System;");
			sb.AppendLine("using DotWeb.Client;");
			sb.AppendLine();

			sb.AppendLine("namespace " + (String.IsNullOrEmpty(Namespace) ? "Ext" : Namespace) + " {");

			if (SourceConverter.ShowDoc)
				sb.AppendFormat("\t/// <summary>{0}</summary>\r\n", Description.GetDocComment("\t"));
			sb.AppendFormat("\t/// <jssource>{0}</jssource>\r\n", SourceFile);
			if (String.IsNullOrEmpty(Namespace)) 
				sb.AppendLine("\t[JsNamespace()]");
			sb.AppendFormat("\tpublic class {0} ", newName);
			if (!String.IsNullOrEmpty(SuperClass)) {
				sb.Append(": " + ExtType.ParseType(SuperClass));
			}
			else {
				sb.Append(": DotWeb.Client.JsNativeBase");
			}
			sb.AppendLine(" {");
			sb.AppendLine();

			sb.Append(Constructors.ToExtSharp());
			sb.AppendLine();

			sb.AppendLine("\t\t/// <summary></summary>");
			ExtDescription desc = new ExtDescription("The reference to the prototype the every object of this type is constructed with");
			sb.Append(ExtProperty.Print("prototype", newName, "static", "public", desc));
			sb.AppendLine();

			desc = new ExtDescription("The reference to the constructor function");
			sb.Append(ExtProperty.Print("constructor", "Delegate", "static", "public", desc));
			sb.AppendLine();

			if (!String.IsNullOrEmpty(SuperClass)) {
				desc = new ExtDescription("The reference to the class that this class inherits from");
				sb.Append(ExtProperty.Print("superclass", ExtType.ParseType(SuperClass), "static", "public", desc));
				sb.AppendLine();
			}
			sb.Append(Properties.ToExtSharp());
			sb.AppendLine();

			sb.Append(Methods.ToExtSharp());
			sb.AppendLine();

			sb.Append(SourceConverter.GetMissingCode(FullyQualifiedName));
			sb.AppendLine();

			sb.AppendLine("\t}"); // class
			if (Configs.Any()) {
				sb.AppendLine();
				sb.Append(Configs.ToExtSharp(this));
			}
			if (Events.Any()) {
				sb.AppendLine();
				sb.Append(Events.ToExtSharp(Name));
				sb.AppendLine();
				sb.Append(Events.Delegates(Name));
			}
			sb.AppendLine("}"); // namespace
			return sb.ToString();
		}

		public void SaveToDisk(string basepath) {

			// ignore this deprecated class
			if (Namespace == "DragDropMgr") return;

			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
			if (!String.IsNullOrEmpty(basepath)) path = basepath;

			if (!Directory.Exists(path)) Directory.CreateDirectory(path);

			if (!String.IsNullOrEmpty(Namespace)) {
				string[] parts = Namespace.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				foreach (string dir in parts) {
					string d = dir.Trim();
					if (String.IsNullOrEmpty(d)) continue;
					if (d == "Ext") continue;

					path = Path.Combine(path, d);
					if (!Directory.Exists(path)) Directory.CreateDirectory(path);
				}
			}

			path = Path.Combine(path, Name + ".cs");
			Console.WriteLine(path);

			string code = ToExtSharp();
			//#if DEBUG
			// do not write files while debugging because Visual Studio will complain about changed files
			//           return;
			//#else
			File.WriteAllText(path, code);
			//#endif

		}

		public static void ParseClass(string member, ref ExtClass ec) {
			/**
			 * @class Ext.SplitButton
			 * @extends Ext.Button
			 * A split button that provides a built-in dropdown arrow that can fire an event separately from the default
			 * click event of the button.  Typically this would be used to display a dropdown menu that provides additional
			 * options to the primary button action, but any custom handler can provide the arrowclick implementation.
			 * @cfg {Function} arrowHandler A function called when the arrow button is clicked (can be used instead of click event)
			 * @cfg {String} arrowTooltip The title attribute of the arrow
			 * @constructor
			 * Create a new menu button
			 * @param {String/HTMLElement/Element} renderTo The element to append the button to
			 * @param {Object} config The config object
			 */
			string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < data.Length; i++) {
				string line = data[i].Trim();
				if (line.StartsWith("@class")) {
					ec.Name = line.Substring("@class".Length).Trim();
					if (ec.Name.Contains(".")) {
						int p = ec.Name.LastIndexOf('.');
						ec.Namespace = ec.Name.Substring(0, p);
						ec.Name = ec.Name.Substring(p + 1);
					}
				}
				else if (line.StartsWith("@extends")) {
					ec.SuperClass = line.Substring("@extends".Length).Trim();
				}
				else if (line.StartsWith("@singleton")) {
					ec.Singleton = true;
				}
				else if (line.StartsWith("@constructor")) {
					string ctor = String.Empty;
					while (++i < data.Length - 1) {
						ctor += data[i] + SourceConverter.CRLF;
					}
					ExtConstructor.ParseConstructor(ctor, ref ec);
				}
				else {
					ec.Description.Value += line + SourceConverter.CRLF;
				}
			}
			ec.Description.Value.Trim(SourceConverter.CRLFA);

			// undocumented superclass
			if (ec.Name == "XTemplate") ec.SuperClass = "Ext.Template";

			// Missing config options that need to be added before writing to file so that superclasses can copy this option to their configs
			if (ec.FullyQualifiedName == "Ext.Component") ec.Configs.Add(ExtConfig.Create("xtype", "string", "The registered xtype to create. This config option is not used when passing a config object into a constructor. This config option is used only when lazy instantiation is being used, and a child item of a Container is being specified not as a fully instantiated Component, but as a Component config object. The xtype will be looked up at render time up to determine what type of child Component to create.\r\nThe predefined xtypes are listed at the top of this document.\r\nIf you subclass Components to create your own Components, you may register them using Ext.ComponentMgr.registerType in order to be able to take advantage of lazy instantiation and rendering."));
			if (ec.FullyQualifiedName == "Ext.Container") ec.Configs.Add(ExtConfig.Create("defaultType", "string", "The default type of container represented by this object as registered in Ext.ComponentMgr (defaults to 'panel')."));
		}
	}
}