using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twinkie
{
	class JsTypeConverter
	{
		public static object Convert(object source, Type targetType) {
			Type sourceType = source.GetType();
			if (sourceType != targetType) {
				// coerce
				if (targetType.IsSubclassOf(typeof(JsNativeBase))) {
					JsNativeBase jsnb = (JsNativeBase)Activator.CreateInstance(targetType);
					jsnb.Handle = source;
					return jsnb;
				}
				// TODO: use a TypeConverter instead
				return System.Convert.ChangeType(source, targetType);
			}
			return source;
		}
	}
}
