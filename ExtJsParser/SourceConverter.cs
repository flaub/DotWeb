using System;
using System.Collections.Generic;
using System.Text;
using SourceConverter.Components;
using System.IO;

namespace SourceConverter
{
	public class SourceConverter
	{
		public static bool ShowDoc = true;

		// these paths are relative to .\bin\Debug\
		private readonly string SourcePath = @"..\..\ext-2.2\source";
		private readonly string OutputPath = @"..\..\..\Ext\";
		public static string CRLF = Environment.NewLine;
		public static char[] CRLFA = Environment.NewLine.ToCharArray();

		/// <summary>
		/// Stores a list of classes that are renamed
		/// </summary>
		public static Dictionary<string, string> ClassAliases = new Dictionary<string, string>();
		/// <summary>
		/// Stores a list of methods that are renamed
		/// </summary>
		public static Dictionary<string, string> MethodAliases = new Dictionary<string, string>();
		/// <summary>
		/// Stores a list of properties that are renamed
		/// </summary>
		public static Dictionary<string, string> PropertyAliases = new Dictionary<string, string>();

		public SourceConverter() {
			ExtClassCollection classes = new ExtClassCollection();
			CreateClassesFromDir(SourcePath, ref classes);
			//CreateClassesFromDir(@"..\..\ext-2-plugins\", ref classes);
			classes.AddRange(
				CreateCustomClasses("Ext.data.DataReader")
			);

			// delete existing generated files
			string dir = OutputPath + @"Ext\";
//			if(Directory.Exists(dir))
//				Directory.Delete(dir, true);

			foreach (ExtClass ec in classes) {
				// exclude specific classes
				if (ec.Name == "Array"
					|| ec.Name == "Date"
					|| ec.Name == "Function"
					|| ec.Name == "Number"
					|| ec.Name == "String") {
					continue;
				}

				ec.Constructors.AddBaseOverloads(ec, classes);
				ec.Configs.CopyBaseConfigs(ec, classes);
				ec.SaveToDisk(dir);
			}
			CreateAdapterScripts();
		}

		/// <summary>
		/// Creates an empty class. This is needed for compilation
		/// </summary>
		/// <param name="types">An array of strings specifying the classes to create. Each string should bee the fully qulified class name (incl. Namespace)</param>
		public ExtClassCollection CreateCustomClasses(params string[] types) {
			ExtClassCollection classes = new ExtClassCollection();
			foreach (string t in types) {
				if (String.IsNullOrEmpty(t)) continue;
				ExtClass ec = new ExtClass();
				ec.Description = new ExtDescription();
				ec.Constructors = new ExtConstructorCollection();
				ec.Properties = new ExtPropertyCollection();
				ec.Methods = new ExtMethodCollection();
				ec.Events = new ExtEventCollection();
				ec.Configs = new ExtConfigCollection();
				ec.Name = t;
				if (ec.Name.Contains(".")) {
					int p = ec.Name.LastIndexOf('.');
					ec.Namespace = ec.Name.Substring(0, p);
					ec.Name = ec.Name.Substring(p + 1);
				}
				ec.Constructors.AddDefault(ec);
				ec.SourceFile = "custom";
				classes.Add(ec);
			}
			return classes;
		}

		/// <summary>
		/// Creates scripts that fix compatability issues between ExtJS and Script#
		/// These scripts are appended to the main ExtSharp.js file using a post-build event
		/// </summary>
		public void CreateAdapterScripts() {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine();
			sb.AppendLine("// *********************************************");
			sb.AppendLine("//      ExtSharp Adapter/Compatability Script");
			sb.AppendLine("// *********************************************");
			sb.AppendLine();
			sb.AppendLine("// **** renamed classes ****");
			foreach (string s in ClassAliases.Keys) {
				sb.AppendLine(String.Format("{0} = {1};", ClassAliases[s], s));
			}
			sb.AppendLine();
			sb.AppendLine("// **** renamed methods ****");
			foreach (string s in MethodAliases.Keys) {
				sb.AppendLine(String.Format("{0} = {1};", MethodAliases[s], s));
			}
			sb.AppendLine();
			sb.AppendLine("// **** renamed properties ****");
			foreach (string s in PropertyAliases.Keys) {
				sb.AppendLine(String.Format("{0} = {1};", PropertyAliases[s], s));
			}

			File.WriteAllText(OutputPath + @"ExtSharpAdapter.debug.js", sb.ToString());
//			File.WriteAllText(OutputPath + @"ExtSharpAdapter.js", new JavaScriptMinifier().Minify(sb.ToString()));
		}

		/// <summary>
		/// Recursively goes thru every file in the given folder and converts a javascript class to a C# class
		/// </summary>
		/// <param name="path">the path to look for js files in</param>
		/// <param name="allClasses">the collection of classes to add the found classes to</param>
		public void CreateClassesFromDir(string path, ref ExtClassCollection allClasses) {
			DirectoryInfo dir = new DirectoryInfo(path);
			FileInfo[] files = dir.GetFiles("*.js");
			foreach (FileInfo file in files) {
				if (!file.Name.ToLower().EndsWith(".js")) continue;
				ExtClassCollection classes = LoadFromFile(File.ReadAllLines(file.FullName));
				foreach (ExtClass cls in classes) {
					cls.SourceFile = file.FullName.Replace(SourcePath, String.Empty);
					allClasses.Add(cls);
				}
			}
			foreach (DirectoryInfo subdir in dir.GetDirectories()) {
				if (subdir.Name == ".svn") continue;
				if (subdir.Name == "yui") continue;
				if (subdir.Name == "adapter") continue;
				if (subdir.Name == "legacy") continue;
				CreateClassesFromDir(subdir.FullName, ref allClasses);
			}
		}

		/// <summary>
		/// Converts a single js file into a list of ExtClass objects
		/// </summary>
		/// <param name="data">the contents of the js file</param>
		/// <returns>the list of classes found in the js file</returns>
		public ExtClassCollection LoadFromFile(string[] data) {
			List<string> allMembers = GetMembersInFile(data);
			return ExtractClasses(allMembers);
		}

		/// <summary>
		/// Parses a list of members and extracts the class definitions
		/// </summary>
		/// <param name="members">A list of members</param>
		/// <returns>The classes parsed</returns>
		public ExtClassCollection ExtractClasses(List<string> members) {
			ExtClassCollection ecs = new ExtClassCollection();
			List<string> lines;
			for (int i = 0; i < members.Count; i++) {
				string m = members[i];
				if (m.Contains("@class")) {
					lines = new List<string>();
					do {
						// capture every line until the next @class definition or the end of the file
						lines.Add(m);
						i++;
						if (i < members.Count) m = members[i];
					} while (!m.Contains("@class") && i < members.Count);
					i--; // step back to allow the next iteration to grab the @class line
					ExtClass cls = Parse(lines);
					ecs.Add(cls);
				}
			}
			return ecs;
		}

		/// <summary>
		/// Converts a full js file into blocks of strings, referred to as members. Each string will be the comments of a single class, method, property, or event
		/// </summary>
		/// <remarks>
		/// Here are some examples of what the data of a "member" will look like
		/// - A Class member
		///   /**
		///    * @class Ext.data.Record
		///    * Instances of this class encapsulate both record <em>definition</em> information, and record ...
		///    * @param {Array} data An associative Array of data values keyed by the field name.
		///    * @param {Object} id (Optional) The id of the record. This id should be unique, and is used by the
		///    * {@link Ext.data.Store} object which owns the Record to index its collection of Records. If
		///    * not specified an integer id is generated.
		///    */
		/// - A Method member
		///    /**
		///     * Set the named field to the specified value.
		///     * @param {String} name The name of the field to set.
		///     * @param {Object} value The value to set the field to.
		///     */
		///     set : function(name, value){
		/// - A Property member
		///     /**
		///      * Readonly flag - true if this record has been modified.
		///      * @type Boolean
		///      */
		///     dirty : false,
		/// - An Event member
		///     /**
		///      * @event datachanged
		///      * Fires when the data cache has changed, and a widget which is using this Store
		///      * as a Record cache should refresh its view.
		///      * @param {Store} this
		///      */
		///     datachanged : true,
		/// </remarks>
		/// <param name="data">The contents of the js file</param>
		/// <returns>
		/// The list of members (classes, methods, properties, events) extracted from the input
		/// </returns>
		public static List<string> GetMembersInFile(string[] data) {
			List<string> members = new List<string>();
			StringBuilder buffer;
			for (int i = 0; i < data.Length; i++) {
				string line = data[i].Trim();
				if (line == "/**") {
					// capture multi-line comments
					buffer = new StringBuilder();
					while (line != "*/" && i < data.Length - 1) {
						if (line.StartsWith("*")) line = line.Substring(1).Trim();
						buffer.AppendLine(line);
						i++;
						line = data[i].Trim();
					}
					buffer.AppendLine(data[i].Trim()); // capture "*/"
					if (i + 1 < data.Length && !data[i + 1].Contains("/**")) {
						i++;
						// capture first line after the comments
						// i.e. Ext.LayoutDialog = function(el, config){
						buffer.AppendLine(data[i].Trim());
					}
					members.Add(buffer.ToString());
				}
				else if (line.StartsWith("/**") && line.EndsWith("*/") && !line.Contains("@ignore") && !line.Contains("@private") && !line.Contains("@hide")) {
					// capture single line comments
					// /** @type Boolean */
					// isOpera : isOpera,
					buffer = new StringBuilder();
					buffer.AppendLine("@extproperty"); // mark it so that its easier to distinguish later
					buffer.AppendLine(line); //first line
					i++;
					line = data[i].Trim();
					buffer.AppendLine(line); // second line       
					members.Add(buffer.ToString());
				}

			}
			return members;
		}

		/// <summary>
		/// Reads the missing code from the text file and returns the data in it.
		/// </summary>
		/// <param name="fqName">The name of the class to retrieve missing code for</param>
		/// <returns>The missing code or an empty string if there is no aaditional code</returns>
		public static string GetMissingCode(string fqName) {
			string loc = fqName.Replace("Ext.", "").Replace(".", "\\");
			string path = @"..\..\MoreCode\" + loc + ".txt";
			if (!File.Exists(path)) return String.Empty;
			return File.ReadAllText(path);
		}

		/// <summary>
		/// Parses a list of members which contain all of the members for a single class
		/// </summary>
		/// <param name="members">The members of a single class</param>
		/// <returns>The object representation of the members in the file</returns>
		public static ExtClass Parse(List<string> members) {
			ExtClass ec = new ExtClass();
			ec.Description = new ExtDescription();
			ec.Constructors = new ExtConstructorCollection();
			ec.Properties = new ExtPropertyCollection();
			ec.Methods = new ExtMethodCollection();
			ec.Events = new ExtEventCollection();
			ec.Configs = new ExtConfigCollection();

			foreach (string member in members) {
				if (member.Contains("@class")) {
					ExtClass.ParseClass(member, ref ec);
				}
				else if (member.Contains("@event")) {
					ExtEvent.ParseEvent(member, ref ec);
				}
				else if (member.Contains("@method")) {
					ExtMethod.ParseMethod(member, ref ec);
				}
				else if (member.Contains("@extproperty")) {
					ExtProperty.ParseProperty(member, ref ec);
				}
				else {
					if (IsFunction(member, ec)) {
						ExtMethod.ParseMethod(member, ref ec);
					}
					else {
						ExtProperty.ParseProperty(member, ref ec);
					}
				}
				if (member.Contains("@cfg") && !member.Contains("@hide")) {
					// since some definitions for config options and properties will be 
					// in the same comment, parse this outside of the if stmt
					ExtConfig.ParseConfig(member, ref ec);
				}
			}
			ec.Constructors = ec.Constructors.CreateOverloads();
			if (!ec.Constructors.HasDefaultConstructor) ec.Constructors.AddDefault(ec);
			ec.Methods = ec.Methods.CreateOverloads();
			return ec;
		}

		/// <summary>
		/// Splits the last line of a member by a ":" or "=" sign
		/// </summary>
		/// <param name="member">The member to split</param>
		/// <returns>
		/// A 2-string array where the first string is the text before the ":" or "=" sign and the second string is
		/// the text after the ":" or "=" sign. If there is no ":" or "=" sign on the last line of the data, an
		/// empty string[] is returned
		/// </returns>
		public static string[] ParseLastLine(string member) {
			string[] data = member.Split(CRLFA, StringSplitOptions.RemoveEmptyEntries);

			string[] lastLine = new string[0];
			string ds = data[data.Length - 1].TrimStart(',');

			if (ds.Contains("=") || ds.Contains(":")) {
				char[] sep = { ':', '=' };
				lastLine = ds.Split(sep, 2, StringSplitOptions.RemoveEmptyEntries);
			}
			return lastLine;

		}

		/// <summary>
		/// Checks the last line of a member to see if it is a fuction declaration
		/// </summary>
		/// <param name="member">The member to check</param>
		/// <param name="ec">The class the member belongs to</param>
		/// <returns>True is this member is a function</returns>
		public static bool IsFunction(string member, ExtClass ec) {
			string[] lines = member.Split(CRLFA, StringSplitOptions.RemoveEmptyEntries);
			string line = lines[lines.Length - 1];
			if (line.Contains("function")) return true;
			if (line.Contains(" = ")) {
				// check if a variable if being set that points to another function in the class
				string[] d = line.Split(" = ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				if (d.Length > 1) {
					string method = d[1].Trim();
					if (method.Contains(".")) method = method.Substring(method.LastIndexOf(".") + 1);
					if (method.Contains(";")) method = method.Replace(";", "");
					foreach (ExtMethod m in ec.Methods) {
						if (m.Name == method) return true;
					}
				}
			}
			return false;
		}
	}
}
