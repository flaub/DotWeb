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
using System.Text;
using System.Reflection;
using Mono.Cecil;

namespace DotWeb.Tools.Weaver
{
	class ExternalType : IType
	{
		public static readonly IType Void = new ExternalType(null, typeof(void));

		private IResolver resolver;

		private const BindingFlags Flags =
			BindingFlags.DeclaredOnly | 
			BindingFlags.Instance | 
			BindingFlags.Static |
			BindingFlags.Public | 
			BindingFlags.NonPublic;

		public Type Type { get; private set; }

		public ExternalType(IResolver resolver, Type type) {
			this.resolver = resolver;
			this.Type = type;
		}

		public override string ToString() {
			return string.Format("ExternalType: {0}", this.Type.ToString());
		}

		public MethodBase ResolveMethod(MethodReference methodRef) {
			var argDefs = methodRef.Parameters.Cast<ParameterDefinition>();
			var types = argDefs.Select(x => ResolveTypeReference(x)).ToArray();
			if (methodRef.Name == ConstructorInfo.ConstructorName) {
				var ret = this.Type.GetConstructor(Flags, Type.DefaultBinder, types, null);
				if (ret == null)
					throw new NullReferenceException(string.Format("Could not find ctor: {0}", methodRef.ToString()));
				return ret;
			}
			else {
				var ret = this.Type.GetMethod(methodRef.Name, Flags, Type.DefaultBinder, types, null);
				if (ret == null)
					throw new NullReferenceException(string.Format("Could not find method: {0}", methodRef.ToString()));
				return ret;
			}
		}

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			var ret = this.Type.GetField(fieldDef.Name, Flags);
			if (ret == null)
				throw new NullReferenceException(string.Format("Could not find field: {0}", fieldDef.ToString()));
			return ret;				
		}

		Type ResolveTypeReference(ParameterDefinition parameterDef) {
			if (parameterDef.ParameterType.Name.StartsWith("!")) {
				var genericArg = (GenericParameter)parameterDef.ParameterType;
				var args = this.Type.GetGenericArguments();
				return args[genericArg.Position];
			}
			return this.resolver.ResolveTypeReference(parameterDef.ParameterType).Type;
		}

		public void Close() {
		}

		public void Process() {
		}
	}
}
