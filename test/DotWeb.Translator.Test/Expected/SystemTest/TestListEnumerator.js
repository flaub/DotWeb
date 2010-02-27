$Namespace('System.Collections.Generic');

System.Collections.Generic.List$1 = function() {
};

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1_Enumerator = function() {
};

System.Collections.Generic.List$1_Enumerator.prototype.$ctor = function(list) {
	this.list = list;
	this.index = 0;
	this.current = null;
	return this;
};

System.Collections.Generic.List$1.prototype.GetEnumerator = function() {
	var V_0 = new System.Collections.Generic.List$1_Enumerator().$ctor(this);
	return V_0;
};

System.Collections.Generic.List$1.prototype.get_Count = function() {
	var V_0 = this.items.length;
	return V_0;
};

System.Collections.Generic.List$1_Enumerator.prototype.MoveNextRare = function() {
	this.index = this.list.get_Count() + 1;
	this.current = null;
	var V_0 = false;
	return V_0;
};

System.Collections.Generic.List$1.prototype.get_Item = function(index) {
	var V_0 = this.items[index];
	return V_0;
};

System.Collections.Generic.List$1_Enumerator.prototype.MoveNext = function() {
	var V_1 = this.index >= this.list.get_Count();
	if (!V_1) {
		this.current = this.list.get_Item(this.index);
		var D_0 = this;
		D_0.index = D_0.index + 1;
		var V_0 = true;
	}
	else {
		V_0 = this.MoveNextRare();
	}
	return V_0;
};

System.Collections.Generic.List$1_Enumerator.prototype.get_Current = function() {
	var V_0 = this.current;
	return V_0;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Collections.Generic.List$1_Enumerator.prototype.Dispose = function() {
};

$Namespace('H8');

H8.SystemTests = function() {
};

H8.SystemTests.prototype.TestListEnumerator = function() {
	var list = new System.Collections.Generic.List$1().$ctor$0();
	var CS$5$0000 = list.GetEnumerator();
	try {
		while (CS$5$0000.MoveNext()) {
			var item = CS$5$0000.get_Current();
			System.Console.WriteLine$1(item);
		}
	}
	finally {
		if (CS$5$0000) {
			CS$5$0000.Dispose();
		}
	}
};
