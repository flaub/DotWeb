﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4918
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotWeb.Translator.Test.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DotWeb.Translator.Test.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.DecorationTests = function() {
        ///};
        ///
        ///H8.DecorationTests.prototype.TestJsAnonymous = function() {
        ///	var loc3 = {};
        ///	loc3.X = 1;
        ///	loc3.y = 2;
        ///	var loc0 = loc3;
        ///	loc0.X = loc0.y;
        ///	loc0.y = loc0.X;
        ///	var loc6 = [];
        ///	var loc4 = {};
        ///	loc4.X = 0;
        ///	loc4.y = 0;
        ///	loc6[0] = loc4;
        ///	var loc5 = {};
        ///	loc5.X = 1;
        ///	loc5.y = 1;
        ///	loc6[1] = loc5;
        ///	var loc1 = loc6;
        ///	var loc2 = loc1[0];
        ///	console.log(loc2);
        ///};
        ///.
        /// </summary>
        internal static string DecorationTest_JsAnonymous {
            get {
                return ResourceManager.GetString("DecorationTest_JsAnonymous", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.DecorationTests.prototype.TestJsCode = function(arg /*System.String*/) {
        ///	alert(arg);
        ///};
        ///.
        /// </summary>
        internal static string DecorationTest_JsCode {
            get {
                return ResourceManager.GetString("DecorationTest_JsCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.IntrinsicClass = function() {
        ///};
        ///
        ///H8.IntrinsicClass.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///H8.DecorationTests = function() {
        ///};
        ///
        ///H8.DecorationTests.prototype.TestJsIntrinsic = function() {
        ///	var loc1 = new H8.IntrinsicClass().$ctor();
        ///	loc1.Value = 1;
        ///	var loc0 = loc1;
        ///	System.Console.Write(loc0.Value);
        ///};
        ///.
        /// </summary>
        internal static string DecorationTest_JsIntrinsic {
            get {
                return ResourceManager.GetString("DecorationTest_JsIntrinsic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///DefaultNamespaceTest = function() {
        ///};
        ///
        ///DefaultNamespaceTest.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///DefaultNamespaceTest.prototype.set_Value = function(value /*System.Int32*/) {
        ///	this._Value_k__BackingField = value;
        ///};
        ///
        ///Foo.FooNamespaceTest = function() {
        ///};
        ///
        ///Foo.FooNamespaceTest.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///DefaultNamespaceTest.prototype.get_Value = function() {
        ///	return this._Value_k__BackingField;
        ///};
        ///
        ///Foo.FooName [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DecorationTest_JsNamespace {
            get {
                return ResourceManager.GetString("DecorationTest_JsNamespace", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // Copyright 2009, Frank Laub
        /////
        ///// This file is part of DotWeb.
        /////
        ///// DotWeb is free software: you can redistribute it and/or modify
        ///// it under the terms of the GNU General Public License as published by
        ///// the Free Software Foundation, either version 3 of the License, or
        ///// (at your option) any later version.
        /////
        ///// DotWeb is distributed in the hope that it will be useful,
        ///// but WITHOUT ANY WARRANTY; without even the implied warranty of
        ///// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DecorationTest_Source {
            get {
                return ResourceManager.GetString("DecorationTest_Source", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // Copyright 2009, Frank Laub
        /////
        ///// This file is part of DotWeb.
        /////
        ///// DotWeb is free software: you can redistribute it and/or modify
        ///// it under the terms of the GNU General Public License as published by
        ///// the Free Software Foundation, either version 3 of the License, or
        ///// (at your option) any later version.
        /////
        ///// DotWeb is distributed in the hope that it will be useful,
        ///// but WITHOUT ANY WARRANTY; without even the implied warranty of
        ///// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string NativeTest_Source {
            get {
                return ResourceManager.GetString("NativeTest_Source", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.NativeTest.prototype.TestTuple = function() {
        ///	var loc3 = {};
        ///	loc3.id = 666;
        ///	loc3.value = &quot;value&quot;;
        ///	var loc0 = loc3;
        ///	var loc1 = new Tuple(loc0);
        ///	var loc2 = loc1.id;
        ///	console.log(loc2);
        ///	loc1.id = 9;
        ///};
        ///.
        /// </summary>
        internal static string NativeTest_TestTuple {
            get {
                return ResourceManager.GetString("NativeTest_TestTuple", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to __f__AnonymousType0$2 = function() {
        ///};
        ///
        ///__f__AnonymousType0$2.prototype.$ctor = function(Key /*System.String*/, Value /*System.Int32*/) {
        ///	this._Key_i__Field = Key;
        ///	this._Value_i__Field = Value;
        ///	return this;
        ///};
        ///
        ///__f__AnonymousType0$2.prototype.get_Key = function() {
        ///	return this._Key_i__Field;
        ///};
        ///
        ///__f__AnonymousType0$2.prototype.get_Value = function() {
        ///	return this._Value_i__Field;
        ///};
        ///
        ///if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototyp [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_AnonymousType {
            get {
                return ResourceManager.GetString("SourceTests_AnonymousType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototype.SourceTests_SimpleEvent = function() {
        ///	throw new System.NotImplementedException().$ctor()
        ///};
        ///
        ///H8.SourceTests.prototype.Callback = function(del /*H8.SourceTests_SimpleDelegate*/) {
        ///	if (del) {
        ///		del.Invoke();
        ///	}
        ///	if (this.SimpleEvent) {
        ///		this.SimpleEvent.Invoke();
        ///	}
        ///	this.SimpleEvent = /*(H8.SourceTests_SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, $Delegate(this, this.SourceTest [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_Callback {
            get {
                return ResourceManager.GetString("SourceTests_Callback", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.Base = function() {
        ///};
        ///
        ///H8.Base.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///H8.Derived = function() {
        ///	this.$super.constructor();
        ///};
        ///H8.Derived.$extend(H8.Base);
        ///
        ///H8.Derived.prototype.$ctor = function() {
        ///	this.$super.$ctor.call(this);
        ///	return this;
        ///};
        ///
        ///H8.Base.prototype.BaseMethod = function() {
        ///};
        ///
        ///H8.Derived.prototype.DerviedMethod = function() {
        ///	this.BaseMethod();
        ///};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototype. [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CallDerived {
            get {
                return ResourceManager.GetString("SourceTests_CallDerived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
        ///	console.log(str);
        ///	var loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
        ///	return System.Math.Cosh(loc0);
        ///};
        ///
        ///H8.SourceTests.prototype.CallTakeParameters = function() {
        ///	var loc1 = new System.Double[2];
        ///	loc1[0] = 1;
        ///	loc1[1] = 2;
        ///	var loc0 = this.TakeParameters(&quot;Hi&quot;, 1, loc1);
        ///	console.log(l [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CallTakeParameters {
            get {
                return ResourceManager.GetString("SourceTests_CallTakeParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.Cifuentes = function() {
        ///	var loc0 = 5;
        ///	var loc1 = loc0 * 5;
        ///	if (loc0 &lt; loc1) {
        ///		loc0 = loc0 * loc1;
        ///		if ((loc0 * 2) &lt;= loc1) {
        ///			loc1 = loc1 &lt;&lt; 3;
        ///		}
        ///		else {
        ///			loc0 = loc0 &lt;&lt; 3;
        ///		}
        ///	}
        ///	var loc2 = 0;
        ///	while(loc2 &lt; 10) {
        ///		var loc3 = loc2;
        ///		do {
        ///			loc3 = loc3 + 1;
        ///			console.log(&quot;{0}, {1}&quot;, loc2, loc3);
        ///		} while(loc3 &lt; 5);
        ///		loc2 = loc2 + 1;
        ///	}
        ///	if ((loc0 &lt; loc1) || ((loc1 * 2) &gt; loc0)) {
        ///		loc0 = (loc0 + loc1) - 10;
        ///		loc1 = loc1 / 2;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_Cifuentes {
            get {
                return ResourceManager.GetString("SourceTests_Cifuentes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.SourceTests_InnerClassTest = function() {
        ///};
        ///
        ///H8.SourceTests_InnerClassTest.prototype.set_Text = function(value /*System.String*/) {
        ///	this._Text_k__BackingField = value;
        ///};
        ///
        ///H8.SourceTests_InnerClassTest.prototype.set_Value = function(value /*System.Int32*/) {
        ///	this._Value_k__BackingField = value;
        ///};
        ///
        ///H8.SourceTests_InnerClassTest.prototype.$ctor = function(text /*System.String*/, value /*System.Int32*/) {
        ///	this.set_Text(text);
        ///	this.set_Value(value) [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CreateInnerObject {
            get {
                return ResourceManager.GetString("SourceTests_CreateInnerObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.OuterClassTest = function() {
        ///};
        ///
        ///H8.OuterClassTest.prototype.set_Text = function(value /*System.String*/) {
        ///	this._Text_k__BackingField = value;
        ///};
        ///
        ///H8.OuterClassTest.prototype.set_Value = function(value /*System.Int32*/) {
        ///	this.m_value = value;
        ///};
        ///
        ///H8.OuterClassTest.prototype.$ctor = function(text /*System.String*/, value /*System.Int32*/) {
        ///	this.set_Text(text);
        ///	this.set_Value(value);
        ///	return this;
        ///};
        ///
        ///H8.OuterClassTest.prototype.$ctor = fun [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CreateOuterObject {
            get {
                return ResourceManager.GetString("SourceTests_CreateOuterObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.DoWhileLoop = function() {
        ///	var loc0 = 0;
        ///	do {
        ///		console.log(loc0);
        ///		loc0 = loc0 + 1;
        ///	} while(loc0 &lt; 10);
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_DoWhileLoop {
            get {
                return ResourceManager.GetString("SourceTests_DoWhileLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.EnumArray = function() {
        ///	System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Int32[4], [ 1, 2, 3, 4 ]);
        ///	var loc0 = new System.Int32[4];
        ///	var loc2 = loc0;
        ///	var loc3 = 0;
        ///	while(loc3 &lt; loc2.length) {
        ///		var loc1 = loc2[loc3];
        ///		console.log(loc1);
        ///		loc3 = loc3 + 1;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_EnumArray {
            get {
                return ResourceManager.GetString("SourceTests_EnumArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.ForLoop = function() {
        ///	var loc0 = 0;
        ///	while(loc0 &lt; 10) {
        ///		console.log(loc0);
        ///		loc0 = loc0 + 1;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_ForLoop {
            get {
                return ResourceManager.GetString("SourceTests_ForLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.HelloWorld = function() {
        ///	console.log(&quot;Hello World!&quot;);
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_HelloWorld {
            get {
                return ResourceManager.GetString("SourceTests_HelloWorld", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.If = function() {
        ///	var loc0 = 0;
        ///	if (loc0 == 1) {
        ///		console.log(&quot;True&quot;);
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_If {
            get {
                return ResourceManager.GetString("SourceTests_If", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.IfElse = function() {
        ///	var loc0 = 0;
        ///	if (loc0 == 1) {
        ///		console.log(&quot;True&quot;);
        ///	}
        ///	else {
        ///		console.log(&quot;False&quot;);
        ///	}
        ///	console.log(&quot;Yep&quot;);
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_IfElse {
            get {
                return ResourceManager.GetString("SourceTests_IfElse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.IfElseIf = function() {
        ///	var loc0 = 0;
        ///	if (loc0 == 1) {
        ///		console.log(&quot;True&quot;);
        ///		return;
        ///	}
        ///	else {
        ///		if (loc0 == 2) {
        ///			console.log(&quot;False&quot;);
        ///		}
        ///		return;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_IfElseIf {
            get {
                return ResourceManager.GetString("SourceTests_IfElseIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.IfIf = function() {
        ///	var loc0 = 0;
        ///	if (loc0 == 1) {
        ///		console.log(&quot;True&quot;);
        ///	}
        ///	if (loc0 == 2) {
        ///		console.log(&quot;False&quot;);
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_IfIf {
            get {
                return ResourceManager.GetString("SourceTests_IfIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to if(typeof(H8) == &apos;undefined&apos;) H8 = {};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests._Linq_b__2 = function(ch /*System.Char*/) {
        ///	return System.Char.IsDigit(ch);
        ///};
        ///
        ///H8.SourceTests.prototype.Linq = function() {
        ///	var loc0 = &quot;ABCDE99F-J74-12-89A&quot;;
        ///	if (!H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate3) {
        ///		H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate3 = $Delegate(H8.SourceTests, H8.SourceTests._Linq_b__2);
        ///	}
        ///	var loc1 = System.Linq.Enumerable.Where(loc0, H8.SourceTests.CS$__9__ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_Linq {
            get {
                return ResourceManager.GetString("SourceTests_Linq", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.Switch = function(val /*System.Int32*/) {
        ///	console.log(&quot;Hello&quot;);
        ///	var loc0 = val;
        ///	switch(loc0 - 1) {
        ///		default:
        ///			console.log(&quot;default&quot;);
        ///			break;
        ///		case 0:
        ///			console.log(&quot;1&quot;);
        ///			break;
        ///		case 1:
        ///			console.log(&quot;2&quot;);
        ///			break;
        ///		case 2:
        ///			console.log(&quot;3&quot;);
        ///			break;
        ///		case 3:
        ///		case 4:
        ///			console.log(&quot;4, 5&quot;);
        ///			break;
        ///	}
        ///	console.log(&quot;Bye&quot;);
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_Switch {
            get {
                return ResourceManager.GetString("SourceTests_Switch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
        ///	console.log(str);
        ///	var loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
        ///	return System.Math.Cosh(loc0);
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_TakeParameters {
            get {
                return ResourceManager.GetString("SourceTests_TakeParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileBreakLoop = function() {
        ///	var loc0 = 0;
        ///	while(loc0 != 10) {
        ///		console.log(loc0);
        ///		loc0 = loc0 + 1;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_WhileBreakLoop {
            get {
                return ResourceManager.GetString("SourceTests_WhileBreakLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileCondBreakLoop = function() {
        ///	var loc0 = 0;
        ///	while(loc0 &lt; 9) {
        ///		if (loc0 == 10) {
        ///			return;
        ///		}
        ///		else {
        ///			console.log(loc0);
        ///			loc0 = loc0 + 1;
        ///		}
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_WhileCondBreakLoop {
            get {
                return ResourceManager.GetString("SourceTests_WhileCondBreakLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileLoop = function() {
        ///	var loc0 = 0;
        ///	while(loc0 &lt; 10) {
        ///		console.log(loc0);
        ///		loc0 = loc0 + 1;
        ///	}
        ///};
        ///
        ///.
        /// </summary>
        internal static string SourceTests_WhileLoop {
            get {
                return ResourceManager.GetString("SourceTests_WhileLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to // Copyright 2009, Frank Laub
        /////
        ///// This file is part of DotWeb.
        /////
        ///// DotWeb is free software: you can redistribute it and/or modify
        ///// it under the terms of the GNU General Public License as published by
        ///// the Free Software Foundation, either version 3 of the License, or
        ///// (at your option) any later version.
        /////
        ///// DotWeb is distributed in the hope that it will be useful,
        ///// but WITHOUT ANY WARRANTY; without even the implied warranty of
        ///// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.   [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TranslationTest_Source {
            get {
                return ResourceManager.GetString("TranslationTest_Source", resourceCulture);
            }
        }
    }
}