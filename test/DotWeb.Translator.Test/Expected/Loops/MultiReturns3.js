$Class(null, 'System.Collections.Generic', 'EqualityComparer$1');

System.Collections.Generic.EqualityComparer$1.prototype.$ctor = function() {
	return this;
};

$Class(System.Collections.Generic.EqualityComparer$1, 'System.Collections.Generic', 'EqualityComparer$1_DefaultComparer');

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.$ctor = function() {
	this.$super.$ctor();
	return this;
};

System.Collections.Generic.EqualityComparer$1.get_Default = function() {
	return new System.Collections.Generic.EqualityComparer$1_DefaultComparer().$ctor();
};

$Class(null, 'System.Collections.Generic', 'Dictionary$2', { table: 0, linkSlots: null, keySlots: null, valueSlots: null, touchedSlots: 0, emptySlot: 0, count: 0, threshold: 0, hcp: null, generation: 0 });

(function() {
	System.Collections.Generic.Dictionary$2.INITIAL_SIZE = 10;
	System.Collections.Generic.Dictionary$2.DEFAULT_LOAD_FACTOR = 0.9;
	System.Collections.Generic.Dictionary$2.NO_SLOT = -1;
	System.Collections.Generic.Dictionary$2.HASH_FLAG = -2147483648;
	var D_0 = [11, 19, 37, 73, 109, 163, 251, 367, 557, 823, 1237, 1861, 2777, 4177, 6247, 9371, 14057, 21089, 31627, 47431, 71143, 106721, 160073, 240101, 360163, 540217, 810343, 1215497, 1823231, 2734867, 4102283, 6153409, 9230113, 13845163];
	System.Collections.Generic.Dictionary$2.primeTable = D_0;
})();

System.Collections.Generic.Dictionary$2.prototype.InitArrays = function(size) {
	this.table = $Array(size, 0);
	this.linkSlots = $Array(size, null);
	this.emptySlot = -1;
	this.keySlots = $Array(size, null);
	this.valueSlots = $Array(size, null);
	this.touchedSlots = 0;
	this.threshold = Math.floor(this.table.length * 0.9);
	if (!this.threshold) {
		var R_1 = this.table.length <= 0;
	}
	else {
		R_1 = 1;
	}
	var V_0 = R_1;
	if (!V_0) {
		this.threshold = 1;
	}
};

$Class(null, 'System', 'Exception', { message: null, _InnerException_k__BackingField: null, _Source_k__BackingField: null, _StackTrace_k__BackingField: null });

System.Exception.prototype.set_Message = function(value) {
	this.message = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

$Class(System.Exception, 'System', 'SystemException');

System.SystemException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

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

System.Collections.Generic.Dictionary$2.prototype.Init = function(capacity, hcp) {
	var V_0 = capacity >= 0;
	if (!V_0) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("capacity");
	}
	var R_1 = this;
	if (!hcp) {
		var R_2 = System.Collections.Generic.EqualityComparer$1.get_Default();
	}
	else {
		R_2 = hcp;
	}
	R_1.hcp = R_2;
	V_0 = capacity != 0;
	if (!V_0) {
		capacity = 10;
	}
	capacity = Math.floor(capacity / 0.9) + 1;
	this.InitArrays(capacity);
	this.generation = 0;
};

System.Collections.Generic.Dictionary$2.prototype.$ctor$0 = function() {
	this.Init(10, null);
	return this;
};

$Class(null, 'System.Collections.Generic', 'Dictionary$2_Enumerator', { dictionary: null, next: 0, stamp: 0, current: null });

System.Collections.Generic.Dictionary$2_Enumerator.prototype.$ctor = function(dictionary) {
	this.dictionary = dictionary;
	this.stamp = dictionary.generation;
	return this;
};

System.Collections.Generic.Dictionary$2.prototype.GetEnumerator = function() {
	return new System.Collections.Generic.Dictionary$2_Enumerator().$ctor(this);
};

$Class(System.SystemException, 'System', 'InvalidOperationException');

System.InvalidOperationException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.VerifyState = function() {
	var V_0 = this.dictionary.generation == this.stamp;
	if (!V_0) {
		throw new System.InvalidOperationException().$ctor$1("out of sync");
	}
};

$Class(null, 'System.Collections.Generic', 'KeyValuePair$2', { _Key_k__BackingField: null, _Value_k__BackingField: null });

System.Collections.Generic.KeyValuePair$2.prototype.set_Key = function(value) {
	this._Key_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

System.Collections.Generic.KeyValuePair$2.prototype.$ctor = function(key, value) {
	this.set_Key(key);
	this.set_Value(value);
	return this;
};

System.Collections.Generic.Dictionary$2_Enumerator.prototype.MoveNext = function() {
	this.VerifyState();
	var V_5 = this.next >= 0;
	if (!V_5) {
		return false;
	}
	while (true) {
		V_5 = this.next < this.dictionary.touchedSlots;
		if (!V_5) {
			break;
		}
		var D_0 = this.next;
		var V_6 = D_0;
		this.next = D_0 + 1;
		var V_0 = V_6;
		var V_1 = this.dictionary.linkSlots[V_0];
		V_5 = (V_1.HashCode & -2147483648) == 0;
		if (!V_5) {
			var V_2 = this.dictionary.keySlots[V_0];
			var V_3 = this.dictionary.valueSlots[V_0];
			this.current = new System.Collections.Generic.KeyValuePair$2().$ctor(V_2, V_3);
			return true;
		}
	}
	this.next = -1;
	return false;
};

$Class(null, '', 'Loops');

Loops.prototype.MultiReturns3 = function() {
	return new System.Collections.Generic.Dictionary$2().$ctor$0().GetEnumerator().MoveNext();
};
