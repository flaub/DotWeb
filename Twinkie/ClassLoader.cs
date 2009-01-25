using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

namespace Twinkie
{
	public class Loader
	{
		private Loader(ModuleBuilder dynamicModule) {
			this.dynamicModule = dynamicModule;
			this.definedTypes = new HashSet<string>();
		}

		private static readonly Loader instance;
		private readonly ModuleBuilder dynamicModule;
		private readonly HashSet<string> definedTypes;

		static Loader() {
			var name = new AssemblyName("$Runtime");
			var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
			var module = assemblyBuilder.DefineDynamicModule("$Runtime");
			instance = new Loader(module);
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			AppDomain.CurrentDomain.TypeResolve += new ResolveEventHandler(CurrentDomain_TypeResolve);
		}

		static Assembly CurrentDomain_TypeResolve(object sender, ResolveEventArgs args) {
			throw new NotImplementedException();
		}

		static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			if (args.Name == Instance.dynamicModule.Assembly.FullName) {
				return Instance.dynamicModule.Assembly;
			}
			else {
				return null;
			}
		}

		public static Loader Instance { get { return instance; } }
		public bool IsDefined(string name) { return definedTypes.Contains(name); }

		public TypeBuilder DefineType(string name) {
			//in a real system we would not expose the type builder.
			//instead a AST for the type would be passed in, and we would just create it.
			var type = dynamicModule.DefineType(name, TypeAttributes.Public);
			definedTypes.Add(name);
			return type;
		}
	}
}
