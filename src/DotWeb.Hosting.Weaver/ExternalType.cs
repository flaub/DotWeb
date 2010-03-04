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
using System.Reflection.Emit;
using System.Diagnostics;

namespace DotWeb.Hosting.Weaver
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

		public Type Type { get; protected set; }

		public ExternalType(IResolver resolver, Type type) {
			if (type == null)
				throw new ArgumentNullException("type");
			this.resolver = resolver;
			this.Type = type;
		}

		public override string ToString() {
			return string.Format("ExternalType: {0}", this.Type.ToString());
		}

		public virtual MethodBase ResolveMethod(MethodReference methodRef) {
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

		public virtual FieldInfo ResolveField(FieldDefinition fieldDef) {
			var ret = this.Type.GetField(fieldDef.Name, Flags);
			if (ret == null)
				throw new NullReferenceException(string.Format("Could not find field: {0}", fieldDef.ToString()));
			return ret;				
		}

		protected Type ResolveTypeReference(ParameterDefinition parameterDef) {
			if (parameterDef.ParameterType.Name.StartsWith("!")) {
				var genericArg = (GenericParameter)parameterDef.ParameterType;
				var args = this.Type.GetGenericArguments();
				return args[genericArg.Position];
			}
			return this.resolver.ResolveTypeReference(parameterDef.ParameterType, null).Type;
		}

		public virtual void Close() {
		}

		public virtual void Process() {
		}
	}

	class GenericType : IType
	{
		private IResolver resolver;
		private Type concreteType;
		private TypeProcessor genericTypeProc;

		public GenericType(IResolver resolver, TypeProcessor genericTypeProc, Type concreteType) {
			this.resolver = resolver;
			this.genericTypeProc = genericTypeProc;
			this.concreteType = concreteType;
		}

		public override string ToString() {
			return string.Format("GenericType: [{0}]", this.Type.ToString());
		}

		public Type Type {
			get { return this.concreteType; }
		}

		public TypeProcessor GenericTypeProc { get { return this.genericTypeProc; } }

		public void Close() {
			throw new NotImplementedException();
		}

		public void Process() {
			throw new NotImplementedException();
		}

		public MethodBase ResolveMethod(MethodReference methodRef) {
			var genericMethod = this.genericTypeProc.ResolveMethod(methodRef);
			if (methodRef.Name == ConstructorInfo.ConstructorName) {
				return TypeBuilder.GetConstructor(this.concreteType, (ConstructorInfo)genericMethod);
			}
			else {
				return TypeBuilder.GetMethod(this.concreteType, (MethodInfo)genericMethod);
			}
		}

		public FieldInfo ResolveField(FieldDefinition fieldDef) {
			var genericField = this.genericTypeProc.ResolveField(fieldDef);
			return TypeBuilder.GetField(this.concreteType, genericField);
		}
	}
}
