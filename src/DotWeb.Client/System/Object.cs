using System;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace DotWeb.Client.System
{
	//[Serializable, ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
	public class Object
	{
		//    // Methods
		//    public virtual bool Equals(object obj) {
		//        return InternalEquals(this, obj);
		//    }

		//    public static bool Equals(object objA, object objB) {
		//        return ((objA == objB) || (((objA != null) && (objB != null)) && objA.Equals(objB)));
		//    }

		//    private void FieldGetter(string typeName, string fieldName, ref object val) {
		//        val = this.GetFieldInfo(typeName, fieldName).GetValue(this);
		//    }

		//    private void FieldSetter(string typeName, string fieldName, object val) {
		//        FieldInfo fieldInfo = this.GetFieldInfo(typeName, fieldName);
		//        if (fieldInfo.IsInitOnly) {
		//            throw new FieldAccessException(Environment.GetResourceString("FieldAccess_InitOnly"));
		//        }
		//        Message.CoerceArg(val, fieldInfo.FieldType);
		//        fieldInfo.SetValue(this, val);
		//    }

		//    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		//    protected override void Finalize() {
		//    }

		//    private FieldInfo GetFieldInfo(string typeName, string fieldName) {
		//        Type baseType = this.GetType();
		//        while (baseType != null) {
		//            if (baseType.FullName.Equals(typeName)) {
		//                break;
		//            }
		//            baseType = baseType.BaseType;
		//        }
		//        if (baseType == null) {
		//            throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadType"), new object[] { typeName }));
		//        }
		//        FieldInfo field = baseType.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
		//        if (field == null) {
		//            throw new RemotingException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Remoting_BadField"), new object[] { fieldName, typeName }));
		//        }
		//        return field;
		//    }

		//    public virtual int GetHashCode() {
		//        return InternalGetHashCode(this);
		//    }

		//    [MethodImpl(MethodImplOptions.InternalCall)]
		//    public extern Type GetType();

		//    [MethodImpl(MethodImplOptions.InternalCall)]
		//    internal static extern bool InternalEquals(object objA, object objB);

		//    [MethodImpl(MethodImplOptions.InternalCall)]
		//    internal static extern int InternalGetHashCode(object obj);

		//    [MethodImpl(MethodImplOptions.InternalCall)]
		//    protected extern object MemberwiseClone();

		//    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		//    public static bool ReferenceEquals(object objA, object objB) {
		//        return (objA == objB);
		//    }

		//    public virtual string ToString() {
		//        return this.GetType().ToString();
		//    }
	}
}
