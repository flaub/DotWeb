﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
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
        internal static string DecorationTest {
            get {
                return ResourceManager.GetString("DecorationTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
        ///
        ///H8.DecorationTests = function() {
        ///};
        ///
        ///H8.DecorationTests.prototype.box_OnMouseOver = function(evt /*DotWeb.Client.Dom.Events.MouseEvent*/) {
        ///};
        ///
        ///H8.DecorationTests.prototype.TestCastInterface = function() {
        ///	var element = $doc.getElementById(&quot;box&quot;);
        ///	var box = /*(DotWeb.Client.Dom.Html.HtmlDivElement)*/element;
        ///	box.onmouseover = $Delegate(this, this.box_OnMouseOver);
        ///};
        ///.
        /// </summary>
        internal static string DecorationTest_CastInterface {
            get {
                return ResourceManager.GetString("DecorationTest_CastInterface", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;System&apos;);
        ///
        ///System.Console = function() {
        ///};
        ///
        ///System.Console.WriteLine = function(value /*System.Object*/) {
        ///	console.log(value);
        ///};
        ///
        ///$Namespace(&apos;H8&apos;);
        ///
        ///H8.DecorationTests = function() {
        ///};
        ///
        ///H8.DecorationTests.prototype.TestJsAnonymous = function() {
        ///	var __g__initLocal0 = {};
        ///	__g__initLocal0.X = 1;
        ///	__g__initLocal0.y = 2;
        ///	var item = __g__initLocal0;
        ///	item.X = item.y;
        ///	item.y = item.X;
        ///	var CS$0$0000 = [];
        ///	var __g__initLocal1 = {};
        ///	__g__initLocal1.X = 0;
        ///	__g__initLoca [rest of string was truncated]&quot;;.
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
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
        ///
        ///H8.IntrinsicClass = function() {
        ///};
        ///
        ///H8.IntrinsicClass.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///$Namespace(&apos;System&apos;);
        ///
        ///System.Console = function() {
        ///};
        ///
        ///System.Console.Write = function(value /*System.Int32*/) {
        ///	console.log(value);
        ///};
        ///
        ///H8.DecorationTests = function() {
        ///};
        ///
        ///H8.DecorationTests.prototype.TestJsIntrinsic = function() {
        ///	var __g__initLocal3 = new H8.IntrinsicClass().$ctor();
        ///	__g__initLocal3.Value = 1;
        ///	var item = __g__initLocal3;
        ///	System.Conso [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DecorationTest_JsIntrinsic {
            get {
                return ResourceManager.GetString("DecorationTest_JsIntrinsic", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.DecorationTests.prototype.TestJsInline = function() {
        ///	jQuery(&quot;*&quot;);
        ///	H8.DecorationTests.TakeJQuery(jQuery(&quot;#id&quot;));
        ///	System.Console.WriteLine($doc.getElementById(&quot;id&quot;));
        ///};
        ///.
        /// </summary>
        internal static string DecorationTest_JsMacro {
            get {
                return ResourceManager.GetString("DecorationTest_JsMacro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DefaultNamespaceTest = function() {
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
        ///$Namespace(&apos;Foo&apos;);
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
        ///Foo.FooNamespaceTest.prototype. [rest of string was truncated]&quot;;.
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
        internal static string NativeTest {
            get {
                return ResourceManager.GetString("NativeTest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.NativeTest.prototype.TestTuple = function() {
        ///	var __g__initLocal0 = {};
        ///	__g__initLocal0.id = 666;
        ///	__g__initLocal0.value = &quot;value&quot;;
        ///	var config = __g__initLocal0;
        ///	var tuple = new Tuple(config);
        ///	var id = tuple.id;
        ///	System.Console.WriteLine(id);
        ///	tuple.id = 9;
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
        ///__f__AnonymousType0$2.prototype.$ctor = function(Key /*_Key_j__TPar*/, Value /*_Value_j__TPar*/) {
        ///	this._Key_i__Field = Key;
        ///	this._Value_i__Field = Value;
        ///	return this;
        ///};
        ///
        ///__f__AnonymousType0$2.prototype.get_Key = function() {
        ///	return this._Key_i__Field;
        ///};
        ///
        ///$Namespace(&apos;System&apos;);
        ///
        ///System.String = function() {
        ///};
        ///
        ///System.String.prototype.get_Length = function() {
        ///	var V_0 = this._Length_k__BackingField;
        ///	return V_0;
        ///};
        ///
        ///__f__AnonymousType0$2. [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_AnonymousType {
            get {
                return ResourceManager.GetString("SourceTests_AnonymousType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;System&apos;);
        ///
        ///System.Exception = function() {
        ///};
        ///
        ///System.Exception.prototype.$ctor = function() {
        ///	// nop
        ///	// nop
        ///	// nop
        ///	return this;
        ///};
        ///
        ///System.SystemException = function() {
        ///	this.$super.constructor();
        ///};
        ///System.SystemException.$extend(System.Exception);
        ///
        ///System.SystemException.prototype.$ctor = function() {
        ///	this.$super.$ctor.call(this);
        ///	// nop
        ///	// nop
        ///	// nop
        ///	return this;
        ///};
        ///
        ///System.NotImplementedException = function() {
        ///	this.$super.constructor();
        ///};
        ///System.NotI [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_Callback {
            get {
                return ResourceManager.GetString("SourceTests_Callback", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
        ///
        ///H8.Base = function() {
        ///};
        ///
        ///H8.Derived = function() {
        ///	this.$super.constructor();
        ///};
        ///H8.Derived.$extend(H8.Base);
        ///
        ///H8.Derived.NextId = function() {
        ///	H8.Derived.counter = H8.Derived.counter + 1;
        ///	return H8.Derived.counter;
        ///};
        ///
        ///H8.Base.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///H8.Derived.prototype.$ctor = function() {
        ///	this.id = H8.Derived.NextId();
        ///	this.$super.$ctor.call(this);
        ///	return this;
        ///};
        ///
        ///H8.Base.prototype.BaseMethod = function() {
        ///};
        ///
        ///H8.Derived.p [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CallDerived {
            get {
                return ResourceManager.GetString("SourceTests_CallDerived", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;System&apos;);
        ///
        ///System.Console = function() {
        ///};
        ///
        ///System.Console.WriteLine = function(value /*System.String*/) {
        ///	console.log(value);
        ///};
        ///
        ///System.Math = function() {
        ///};
        ///
        ///System.Math.Sin = function(a /*System.Double*/) {
        ///	return Math.sin(a);
        ///};
        ///
        ///System.Math.Cos = function(a /*System.Double*/) {
        ///	return Math.cos(a);
        ///};
        ///
        ///$Namespace(&apos;H8&apos;);
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*Syst [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CallTakeParameters {
            get {
                return ResourceManager.GetString("SourceTests_CallTakeParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.Cifuentes = function() {
        ///	var x = 5;
        ///	var y = x * 5;
        ///	if (x &lt; y) {
        ///		x = x * y;
        ///		if ((x * 2) &lt;= y) {
        ///			y = y &lt;&lt; 3;
        ///		}
        ///		else {
        ///			x = x &lt;&lt; 3;
        ///		}
        ///	}
        ///	var a = 0;
        ///	while(a &lt; 10) {
        ///		var b = a;
        ///		do {
        ///			b = b + 1;
        ///			System.Console.WriteLine(&quot;{0}, {1}&quot;, a, b);
        ///		} while(b &lt; 5);
        ///		a = a + 1;
        ///	}
        ///	if ((x &lt; y) || ((y * 2) &gt; x)) {
        ///		x = (x + y) - 10;
        ///		y = y / 2;
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_Cifuentes {
            get {
                return ResourceManager.GetString("SourceTests_Cifuentes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
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
        ///	this.set_Value(value);
        ///	return this;
        ///};        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CreateInnerObject {
            get {
                return ResourceManager.GetString("SourceTests_CreateInnerObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
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
        ///H8.OuterClassTest.prototype.$ctor = function() {
        ///	return th [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_CreateOuterObject {
            get {
                return ResourceManager.GetString("SourceTests_CreateOuterObject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.DoWhileLoop = function() {
        ///	var i = 0;
        ///	do {
        ///		System.Console.WriteLine(i);
        ///		i = i + 1;
        ///	} while(i &lt; 10);
        ///};
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
        ///	var array = new System.Int32[4];
        ///	var CS$6$0000 = array;
        ///	var CS$7$0001 = 0;
        ///	while(CS$7$0001 &lt; /*(System.Int32)*/CS$6$0000.length) {
        ///		var item = CS$6$0000[CS$7$0001];
        ///		System.Console.WriteLine(item);
        ///		CS$7$0001 = CS$7$0001 + 1;
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_EnumArray {
            get {
                return ResourceManager.GetString("SourceTests_EnumArray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.ForLoop = function() {
        ///	var i = 0;
        ///	while(i &lt; 10) {
        ///		System.Console.WriteLine(i);
        ///		i = i + 1;
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_ForLoop {
            get {
                return ResourceManager.GetString("SourceTests_ForLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.HelloWorld = function() {
        ///	System.Console.WriteLine(&quot;Hello World!&quot;);
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
        ///	var i = 0;
        ///	if (i == 1) {
        ///		System.Console.WriteLine(&quot;True&quot;);
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_If {
            get {
                return ResourceManager.GetString("SourceTests_If", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.IfElse = function() {
        ///	var i = 0;
        ///	if (i == 1) {
        ///		System.Console.WriteLine(&quot;True&quot;);
        ///	}
        ///	else {
        ///		System.Console.WriteLine(&quot;False&quot;);
        ///	}
        ///	System.Console.WriteLine(&quot;Yep&quot;);
        ///};
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
        ///		System.Console.WriteLine(&quot;True&quot;);
        ///		return;
        ///	}
        ///	else {
        ///		if (loc0 == 2) {
        ///			System.Console.WriteLine(&quot;False&quot;);
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
        ///	var i = 0;
        ///	if (i == 1) {
        ///		System.Console.WriteLine(&quot;True&quot;);
        ///	}
        ///	if (i == 2) {
        ///		System.Console.WriteLine(&quot;False&quot;);
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_IfIf {
            get {
                return ResourceManager.GetString("SourceTests_IfIf", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
        ///
        ///H8.IndexerTest = function() {
        ///};
        ///
        ///H8.IndexerTest.prototype.$ctor = function() {
        ///	return this;
        ///};
        ///
        ///$Namespace(&apos;System&apos;);
        ///
        ///System.Console = function() {
        ///};
        ///
        ///System.Console.WriteLine = function(value /*System.Object*/) {
        ///	console.log(value);
        ///};
        ///
        ///H8.SourceTests = function() {
        ///};
        ///
        ///H8.SourceTests.prototype.Indexer = function() {
        ///	var indexer = new H8.IndexerTest().$ctor();
        ///	indexer[&quot;Test&quot;] = 1;
        ///	var value = indexer[&quot;Test&quot;];
        ///	System.Console.WriteLine(value);
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_Indexer {
            get {
                return ResourceManager.GetString("SourceTests_Indexer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to $Namespace(&apos;H8&apos;);
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
        ///	var loc1 = System.Linq.Enumerable.Where(loc0, H8.SourceTests.CS$__9__CachedAnonymousMethod [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceTests_Linq {
            get {
                return ResourceManager.GetString("SourceTests_Linq", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.Switch = function(val /*System.Int32*/) {
        ///	System.Console.WriteLine(&quot;Hello&quot;);
        ///	var CS$0$0000 = val;
        ///	switch(CS$0$0000 - 1) {
        ///		default:
        ///			System.Console.WriteLine(&quot;default&quot;);
        ///			break;
        ///		case 0:
        ///			System.Console.WriteLine(&quot;1&quot;);
        ///			break;
        ///		case 1:
        ///			System.Console.WriteLine(&quot;2&quot;);
        ///			break;
        ///		case 2:
        ///			System.Console.WriteLine(&quot;3&quot;);
        ///			break;
        ///		case 3:
        ///		case 4:
        ///			System.Console.WriteLine(&quot;4, 5&quot;);
        ///			break;
        ///	}
        ///	System.Console.WriteLine(&quot;Bye&quot;);
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_Switch {
            get {
                return ResourceManager.GetString("SourceTests_Switch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
        ///	System.Console.WriteLine(str);
        ///	var x = System.Math.Sin(rad[value] * 1.570795);
        ///	return System.Math.Cos(x);
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_TakeParameters {
            get {
                return ResourceManager.GetString("SourceTests_TakeParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileBreakLoop = function() {
        ///	var i = 0;
        ///	while(i != 10) {
        ///		System.Console.WriteLine(i);
        ///		i = i + 1;
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_WhileBreakLoop {
            get {
                return ResourceManager.GetString("SourceTests_WhileBreakLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileCondBreakLoop = function() {
        ///	var i = 0;
        ///	while(i &lt; 9) {
        ///		if (i == 10) {
        ///			return;
        ///		}
        ///		else {
        ///			System.Console.WriteLine(i);
        ///			i = i + 1;
        ///		}
        ///	}
        ///};
        ///.
        /// </summary>
        internal static string SourceTests_WhileCondBreakLoop {
            get {
                return ResourceManager.GetString("SourceTests_WhileCondBreakLoop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to H8.SourceTests.prototype.WhileLoop = function() {
        ///	var i = 0;
        ///	while(i &lt; 10) {
        ///		System.Console.WriteLine(i);
        ///		i = i + 1;
        ///	}
        ///};
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
        internal static string TranslationTest {
            get {
                return ResourceManager.GetString("TranslationTest", resourceCulture);
            }
        }
    }
}
