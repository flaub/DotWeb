﻿$Namespace('System.Collections.Generic');

System.Collections.Generic.List$1 = function() {
};

System.Collections.Generic.List$1.prototype.$ctor = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.Add$0 = function(item) {
	this.items.push(item);
};

System.Collections.Generic.List$1.prototype.toString = function() {
	var V_0 = "[ " + this.items.toString() + " ]";
	return V_0;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Collections.Generic.List$1.prototype.IndexOf$0 = function(item) {
	var V_0 = this.items.indexOf(item);
	return V_0;
};

System.Console.WriteLine$0 = function(value) {
	console.log(value);
};

System.Collections.Generic.List$1___c__DisplayClass5 = function() {
};

System.Collections.Generic.List$1___c__DisplayClass5.prototype.$ctor = function() {
	return this;
};

System.Collections.Generic.List$1___c__DisplayClass5.prototype._Remove_b__4 = function(element, i, array) {
	if (!this.foundFirst) {
		var R_1 = !(this.item === element);
	}
	else {
		R_1 = 1;
	}
	var V_1 = R_1;
	if (!V_1) {
		this.foundFirst = true;
		var V_0 = false;
	}
	else {
		V_0 = true;
	}
	return V_0;
};

System.Collections.Generic.List$1.prototype.Remove$0 = function(item) {
	var V_0 = new System.Collections.Generic.List$1___c__DisplayClass5().$ctor();
	V_0.item = item;
	V_0.foundFirst = false;
	this.items = this.items.filter($Delegate(V_0, V_0._Remove_b__4));
	var V_1 = V_0.foundFirst;
	return V_1;
};

$Namespace('H8');

H8.SystemTests = function() {
};

H8.SystemTests.prototype.TestList = function() {
	var list = new System.Collections.Generic.List$1().$ctor();
	list.Add$0("one");
	System.Console.WriteLine$1(list.toString());
	var index = list.IndexOf$0("one");
	System.Console.WriteLine$0(index);
	list.Remove$0("two");
};