using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SourceConverter.Components
{
	public class ExtConfig
	{
		private string name;

		public string Name {
			get { return this.name; }
			set { this.name = value.Replace("<p>", ""); }
		}

		public string Type;
		public ExtDescription Description;

		public string ToExtSharp(string className) {
			string newName = Name;
			if (Name == "checked") newName += "_"; // Ext.menu.CheckItem
			if (Name == "params") newName += "_"; // Ext.ContentPanel
			if (Name == "fixed") newName += "_"; // Ext.grid.ColumnModel

			StringBuilder sb = new StringBuilder();
			if (SourceConverter.ShowDoc) 
				sb.AppendLine(String.Format("\t\t/// <summary>{0} {1}</summary>", Type.Contains("/") ? Type : "", Description.GetDocComment()));
			sb.AppendLine(string.Format("\t\tpublic {0} {1} {{ get; set; }}", ExtType.ParseType(Type), newName));
			return sb.ToString();
		}

		public ExtConfig Dupe() {
			ExtConfig ec = new ExtConfig();
			ec.Name = Name;
			ec.Type = Type;
			ec.Description = new ExtDescription(Description.Value);
			return ec;
		}

		public static void ParseConfig(string member, ref ExtClass ec) {
			// Expecting:
			/**
			* @cfg {Ext.data.DataProxy} proxy The Proxy object which provides access to a data object.
			*/
			// OR
			/**
			 * @class Ext.BasicDialog
			 * @extends Ext.util.Observable
			 * @cfg {Boolean/DomHelper} autoCreate True to auto create from scratch, or using a DomHelper Object (defaults to false)
			 * @cfg {String} title Default text to display in the title bar (defaults to null)
			 * @constructor
			 * Create a new BasicDialog.
			 * @param {String/HTMLElement/Ext.Element} el The container element or DOM node, or its id
			 * @param {Object} config Configuration options
			 */

			string[] data = member.Split(SourceConverter.CRLFA, StringSplitOptions.RemoveEmptyEntries);

			if (member.Contains("@constructor")) {
				// assume that the definition is only on one line since this is a constructor definition
				foreach (string line in data) {
					if (line.StartsWith("*/")) break;
					if (line.StartsWith("/**")) continue;
					if (line.StartsWith("@cfg")) {
						ExtConfig config = new ExtConfig();
						config.Description = new ExtDescription();
						GetFromLine(line, ref config);
						ec.Configs.Add(config);
					}
				}
			}
			else {
				// assume the definition is the whole member block. capture any additional lines as description
				ExtConfig config = new ExtConfig();
				config.Description = new ExtDescription();
				foreach (string line in data) {
					if (line.StartsWith("*/")) break;
					if (line.StartsWith("/**")) continue;
					if (line.StartsWith("@cfg")) {
						GetFromLine(line, ref config);
					}
					else {
						config.Description.Value += " " + line;
					}
				}

				if (String.IsNullOrEmpty(config.Name)) {
					// sometimes the name isn't on the @cfg line, so lets look on the last line
					string[] lastLine = SourceConverter.ParseLastLine(member);
					if (lastLine.Length > 0) {
						config.Name = lastLine[0].Replace("this.", "").Replace("var", "").Trim();
						config.Name = config.Name.Replace("'", "").Replace("\"", ""); // remove quotes
						if (config.Name.Contains(".")) {
							string[] split = config.Name.Split(".".ToCharArray());
							config.Name = split[split.Length - 1];
						}
					}
					else {
						return; // dont add if we cant parse the name
					}
				}

				// Ext.BasicForm bug
				if (config.Name == "fileUpload.") config.Name = "fileUpload";


				ec.Configs.Add(config);
			}
		}

		private static void GetFromLine(string line, ref ExtConfig config) {
			// Expecting:
			// @cfg {Ext.data.DataProxy} proxy The Proxy object which provides access to a data object.
			string[] text = line.Split(" ".ToCharArray());
			if (text.Length > 1) config.Type = text[1]; // capture {Ext.data.DataProxy}
			if (text.Length > 2) config.Name = text[2]; // capture proxy
			if (text.Length > 3) {
				// capture "The Proxy object which provides access to a data object."
				for (int j = 3; j < text.Length; j++) {
					config.Description.Value += text[j] + " ";
				}
				config.Description.Value = config.Description.Value.Trim();
			}
		}

		public static ExtConfig Create(string name, string type, string description) {
			ExtConfig c = new ExtConfig();
			c.Name = name;
			c.Type = type;
			c.Description = new ExtDescription(description);
			return c;
		}
	}
}