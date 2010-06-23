$Class(null, 'System.Collections.Generic', 'List$1', { items: null });

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

$Class(null, 'System.Collections.Generic', 'List$1_Enumerator', { list: null, index: 0, current: null });

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

//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'ArgumentException', { _ParamName_k__BackingField: null });

System.ArgumentException.prototype.set_ParamName = function(value) {
	this._ParamName_k__BackingField = value;
};

System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	this.$super.$ctor$1(message);
	this.set_ParamName(paramName);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

System.ArgumentOutOfRangeException.prototype.$ctor$1 = function(paramName) {
	this.$super.$ctor$3(System.ArgumentOutOfRangeException.RangeMessage, paramName);
	return this;
};

System.Collections.Generic.List$1.prototype.get_Item = function(index) {
	var CS$4$0001 = index < this.items.length;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("index");
	}
	return this.items[index];
};

System.Collections.Generic.List$1_Enumerator.prototype.MoveNext = function() {
	var CS$4$0001 = this.index >= this.list.get_Count();
	if (!CS$4$0001) {
		this.current = this.list.get_Item(this.index);
		this.index = this.index + 1;
		return true;
	}
	return this.MoveNextRare();
};

System.Collections.Generic.List$1_Enumerator.prototype.get_Current = function() {
	return this.current;
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

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
