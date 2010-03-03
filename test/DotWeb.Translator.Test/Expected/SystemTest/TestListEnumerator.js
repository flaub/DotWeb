$Class(null, 'System.Collections.Generic', 'List$1');

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

$Class(null, 'System.Collections.Generic', 'List$1_Enumerator');

System.Collections.Generic.List$1_Enumerator.prototype.$ctor = function(list) {
	this.list = list;
	this.index = 0;
	this.current = null;
	return this;
};

System.Collections.Generic.List$1.prototype.GetEnumerator = function() {
	return new System.Collections.Generic.List$1_Enumerator().$ctor(this);
};

System.Collections.Generic.List$1.prototype.get_Count = function() {
	return this.items.length;
};

System.Collections.Generic.List$1_Enumerator.prototype.MoveNextRare = function() {
	this.index = this.list.get_Count() + 1;
	this.current = null;
	return false;
};

$Class(null, 'System', 'Exception');

$Class(System.Exception, 'System', 'SystemException');

$Class(System.SystemException, 'System', 'ArgumentException');

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException');

System.ArgumentOutOfRangeException.get_RangeMessage = function() {
	return "Specified argument was out of the range of valid values.";
};

System.Exception.prototype.set_Message = function(value) {
	this._Message_k__BackingField = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

System.SystemException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	this.$super.$ctor$1(message);
	this.set_ParamName(paramName);
	return this;
};

System.ArgumentOutOfRangeException.prototype.$ctor$1 = function(paramName) {
	this.$super.$ctor$3(System.ArgumentOutOfRangeException.get_RangeMessage(), paramName);
	return this;
};

System.Collections.Generic.List$1.prototype.get_Item = function(index) {
	var V_1 = index < this.items.length;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("index");
	}
	return this.items[index];
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
	return this.current;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

System.Collections.Generic.List$1_Enumerator.prototype.Dispose = function() {
};

$Class(null, 'H8', 'SystemTests');

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
