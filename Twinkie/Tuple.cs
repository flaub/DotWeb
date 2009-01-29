using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twinkie;

//public class Config : MarshalByRefObject
//{
//    public int Id { get; set; }
//    public string Value { get; set; }
//}

//public delegate void Handler(Tuple tuple, int id);

//public class Tuple : JsNativeBase
//{
//    public Tuple() { }
//    public Tuple(object config) { C_(config); }

//    public int id {
//        get { return (int)_(); }
//        set { _(value); }
//    }

//    public object Value {
//        [JavaScript("return this.getValue();")]
//        get { return _(); }
//        [JavaScript("this.setValue(value);")]
//        set { _(value); }
//    }

//    public Handler handler {
//        get { return (Handler)_(); }
//        set { _(value); }
//    }

//    public void fireEvent() { _(); }

//    public static void StaticMethod(int x, int y) { S_(x, y); }
//    public static Tuple Factory() { return (Tuple)S_(); }
//}
