$Class(null, 'System.Collections.Generic', 'List$1', { items: null });

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.Add$0 = function(item) {
	this.items.push(item);
};

System.Collections.Generic.List$1.prototype.toString = function() {
	return "[ " + this.items.toString() + " ]";
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

System.Collections.Generic.List$1.prototype.IndexOf$0 = function(item) {
	return this.items.indexOf(item);
};

//>System.Console.WriteLine$0 

$Class(null, 'System.Collections.Generic', 'List$1___c__DisplayClass5', { foundFirst: 0, item: null });

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
	var CS$4$0001 = R_1;
	if (!CS$4$0001) {
		this.foundFirst = true;
		return false;
	}
	return true;
};

System.Collections.Generic.List$1.prototype.Remove$0 = function(item) {
	var CS$__8__locals6 = new System.Collections.Generic.List$1___c__DisplayClass5().$ctor();
	CS$__8__locals6.item = item;
	CS$__8__locals6.foundFirst = false;
	this.items = this.items.filter($Delegate(CS$__8__locals6, CS$__8__locals6._Remove_b__4));
	return CS$__8__locals6.foundFirst;
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestList = function() {
	var list = new System.Collections.Generic.List$1().$ctor$0();
	list.Add$0("one");
	System.Console.WriteLine$1(list.toString());
	var index = list.IndexOf$0("one");
	System.Console.WriteLine$0(index);
	list.Remove$0("two");
};
