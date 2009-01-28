using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.Expando;
using System.Reflection;

namespace Twinkie
{
	public class JsObjectAdapter : IReflect
	{
		private object target;
		private Type targetType;

		public JsObjectAdapter(object target) {
			this.target = target;
			this.targetType = target.GetType();
		}

		#region IExpando Members

		public FieldInfo AddField(string name) {
			throw new NotSupportedException();
		}

		public MethodInfo AddMethod(string name, Delegate method) {
			throw new NotSupportedException();
		}

		public PropertyInfo AddProperty(string name) {
			throw new NotSupportedException();
		}

		public void RemoveMember(MemberInfo m) {
			throw new NotSupportedException();
		}

		#endregion

		#region IReflect Members

		public FieldInfo GetField(string name, BindingFlags bindingAttr) {
			return this.GetField(name, bindingAttr);
		}

		public FieldInfo[] GetFields(BindingFlags bindingAttr) {
			return this.targetType.GetFields(bindingAttr);
		}

		public MemberInfo[] GetMember(string name, BindingFlags bindingAttr) {
			return this.targetType.GetMember(name, bindingAttr);
		}

		public MemberInfo[] GetMembers(BindingFlags bindingAttr) {
			return this.targetType.GetMembers(bindingAttr);
		}

		public MethodInfo GetMethod(string name, BindingFlags bindingAttr) {
			return this.targetType.GetMethod(name, bindingAttr);
		}

		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers) {
			return this.targetType.GetMethod(name, bindingAttr, binder, types, modifiers);
		}

		public MethodInfo[] GetMethods(BindingFlags bindingAttr) {
			return this.targetType.GetMethods(bindingAttr);
		}

		public PropertyInfo[] GetProperties(BindingFlags bindingAttr) {
			return this.targetType.GetProperties(bindingAttr);
		}

		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers) {
			return this.targetType.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
		}

		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr) {
			return this.targetType.GetProperty(name, bindingAttr);
		}

		public object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] namedParameters) {
			if (name == "[DISPID=0]") {
				Console.WriteLine("MethodDispatch");
				return null;
			}
			MethodInfo method = this.targetType.GetMethod(name);
			return method.Invoke(this.target, invokeAttr, binder, args, culture);
		}

		public Type UnderlyingSystemType {
			get { return this.targetType.UnderlyingSystemType; }
		}

		#endregion
	}
}
