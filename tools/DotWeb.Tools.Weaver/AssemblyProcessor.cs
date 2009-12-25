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
// 

using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil.Cil;
using System.IO;
using DotWeb.Utility;
using System.Diagnostics;
using DotWeb.Hosting;

namespace DotWeb.Tools.Weaver
{
	public class AssemblyProcessor : ITypeResolver
	{
		private IResolver resolver;
		private AssemblyDefinition asmDef;
		private ModuleDefinition moduleDef;
		private AssemblyBuilder asmBuilder;
		private ModuleBuilder moduleBuilder;
		private string fileName;

		private Dictionary<string, IType> typesByDef = new Dictionary<string, IType>();

		private const string HostedPrefix = "Hosted-";

		public AssemblyProcessor(IResolver resolver, AssemblyDefinition asmDef, string outputDir) {
			this.resolver = resolver;
			this.asmDef = asmDef;
			this.moduleDef = asmDef.MainModule;
			//this.moduleDef.LoadSymbols();

			var name = asmDef.Name.Name;
			if (!name.StartsWith(HostedPrefix))
				name = HostedPrefix + name;

			this.fileName = name + ".dll";
			var asmName = new AssemblyName(name);

			this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave, outputDir);
			this.moduleBuilder = asmBuilder.DefineDynamicModule(name, this.fileName, true);
		}

		public Assembly ProcessModule() {
			foreach (TypeDefinition typeDef in this.moduleDef.Types) {
				if (typeDef.Name == Constants.ModuleType)
					continue;

				IType item;
				if (!this.typesByDef.TryGetValue(typeDef.FullName, out item)) {
					item = ProcessType(typeDef);
				}

				item.Process();
			}

			foreach (var item in this.typesByDef.Values) {
				item.Close();
			}

			if (this.asmDef.HasCustomAttributes) {
				CustomAttributeProcessor.Process(this.resolver, this.asmDef, this.asmBuilder);
			}

			var type = typeof(AssemblyWeavedAttribute);
			var ctor = type.GetConstructor(Type.EmptyTypes);
			this.asmBuilder.SetCustomAttribute(new CustomAttributeBuilder(ctor, new object[0]));

			this.asmBuilder.Save(this.fileName);

			return this.asmBuilder;
		}

		//public string ProcessEntry(AssemblyQualifiedTypeName asmQualifiedTypeName) {
		//    this.asmDef = this.asmResolver.Resolve(asmQualifiedTypeName.AssemblyName.FullName);
		//    this.moduleDef = this.asmDef.MainModule;
		//    this.moduleDef.LoadSymbols();
		//    //asmDef.MainModule.FullLoad();

		//    var startType = asmDef.MainModule.Types[asmQualifiedTypeName.TypeName];

		//    var asmName = new AssemblyName("Hosted-" + asmQualifiedTypeName.AssemblyName.FullName);
		//    string fileName = asmName.Name + ".dll";

		//    this.asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Save, this.OutputDir);
		//    this.moduleBuilder = asmBuilder.DefineDynamicModule(fileName, fileName, true);

		//    var typeProc = (TypeProcessor)ProcessType(startType);
		//    var ctor = startType.Constructors.GetConstructor(false, Type.EmptyTypes);
		//    typeProc.ProcessConstructor(ctor);

		//    foreach (var item in this.typesByDef) {
		//        item.Value.Close();
		//    }

		//    this.asmBuilder.Save(fileName);

		//    string outPath = Path.Combine(this.OutputDir, fileName);
		//    return outPath;
		//}

		private string GetTypeKey(TypeReference typeRef) {
			return typeRef.FullName;
		}

		public IType ResolveTypeReference(TypeReference typeRef) {
			IType type;
			string key = GetTypeKey(typeRef);
			if (!this.typesByDef.TryGetValue(key, out type)) {
				type = ProcessType(typeRef);
			}

			return type;
		}

		private IType ProcessType(TypeReference typeRef) {
			var typeDef = typeRef.Resolve();
			if (typeRef is ArrayType) {
			}

			if (typeDef.IsEnum) {
				var enumProc = new EnumProcessor(this.resolver, this, typeDef, this.moduleBuilder);
				RegisterType(typeRef, enumProc);
				return enumProc;
			}
			else if (typeDef.IsNested) {
				var outerProc = ResolveTypeReference(typeDef.DeclaringType);
				var outerBuilder = (TypeBuilder)outerProc.Type;
				var typeProc = new TypeProcessor(this.resolver, this, typeDef, this.moduleBuilder, outerBuilder);
				RegisterType(typeRef, typeProc);
				return typeProc;
			}
			else {
				var typeProc = new TypeProcessor(this.resolver, this, typeDef, this.moduleBuilder);
				RegisterType(typeRef, typeProc);
				return typeProc;
			}
		}

		private void RegisterType(TypeReference typeRef, IType type) {
			string key = GetTypeKey(typeRef);
			this.typesByDef.Add(key, type);
		}
	}
}
