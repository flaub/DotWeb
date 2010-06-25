namespace System
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class JsAugmentAttribute : Attribute
	{
		public string JsType { get; private set; }

		public JsAugmentAttribute(string type) {
			this.JsType = type;
		}
	}

	[AttributeUsage(
		AttributeTargets.Class |
		AttributeTargets.Interface |
		AttributeTargets.Struct |
		AttributeTargets.Field |
		AttributeTargets.Method |
		AttributeTargets.Property,
		AllowMultiple = false, Inherited = false)]
	public class JsCamelCaseAttribute : Attribute
	{
		public bool Enabled { get; private set; }

		public JsCamelCaseAttribute() : this(true) { }
		public JsCamelCaseAttribute(bool enabled) {
			this.Enabled = enabled;
		}
	}

	/// <summary>
	/// COULD be applied to an extern method
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class JsNameAttribute : Attribute
	{
		public string Name { get; private set; }

		public JsNameAttribute(string name) {
			this.Name = name;
		}
	}

	/// <summary>
	/// MUST be applied to an extern method or constructor
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public class JsCodeAttribute : Attribute
	{
		public string Code { get; private set; }

		public JsCodeAttribute(string code) {
			this.Code = code;
		}
	}

	/// <summary>
	/// MUST be applied to an extern method or constructor
	/// </summary>
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public class JsMacroAttribute : Attribute
	{
		public string Code { get; private set; }

		public JsMacroAttribute(string code) {
			this.Code = code;
		}
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class JsNamespaceAttribute : Attribute
	{
		public string Namespace { get; private set; }

		public JsNamespaceAttribute() {
			this.Namespace = "";
		}

		public JsNamespaceAttribute(string ns) {
			this.Namespace = ns;
		}
	}

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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class JsAnonymousAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class JsIntrinsicAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
	public class JsObjectAttribute : Attribute
	{
	}
}
