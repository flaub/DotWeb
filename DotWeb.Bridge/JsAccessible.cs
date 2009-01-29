using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DotWeb.Hosting.Bridge
{
	public class JsAccessible : MarshalByRefObject, IJsAccessible
	{
		private MemberInfo GetMember(int id) {
			MemberInfo member = GetType().GetMembers().Where(x => x.MetadataToken == id).FirstOrDefault();
			return member;
		}

		#region IJsAccessible Members

		public int GetMemberId(string name) {
			if (name == "toString")
				name = "ToString";
			MemberInfo info = this.GetType().GetMember(name).First();
			return info.MetadataToken;
		}

		public object Invoke(int id, DispatchType dispType, object[] args) {
			MemberInfo member = GetMember(id);
			if(dispType.IsMethod()) {
				MethodBase method = member as MethodBase;
				return method.Invoke(this, args);
			}
			else if (dispType.IsPropertyGet()) {
				PropertyInfo pi = member as PropertyInfo;
				return pi.GetValue(this, null);
			}
			else if (dispType.IsPropertyPut()) {
				PropertyInfo pi = member as PropertyInfo;
				pi.SetValue(this, args.First(), null);
			}
			return null;
		}

		public MemberProperties GetMemberProperties(int id, MemberProperties fetch) {
			MemberProperties ret = 0;
			MemberInfo member = GetMember(id);
			if (member is MethodInfo)
				ret |= MemberProperties.CanCall;
			if (member is ConstructorInfo)
				ret |= MemberProperties.CanConstruct;
			if (member is FieldInfo || member is PropertyInfo)
				ret |= MemberProperties.CanGet | MemberProperties.CanPut | MemberProperties.CanPutRef;
			return ret;
		}

		#endregion
	}
}
