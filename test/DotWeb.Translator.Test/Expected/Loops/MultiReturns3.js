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

//>System.Collections.Generic.Dictionary$2

//>System.Collections.Generic.Dictionary$2.InitArrays

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

//>System.Collections.Generic.Dictionary$2.Init

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
	var CS$4$0000 = this.dictionary.generation == this.stamp;
	if (!CS$4$0000) {
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
	var CS$4$0001 = this.next >= 0;
	if (!CS$4$0001) {
		return false;
	}
	while (true) {
		CS$4$0001 = this.next < this.dictionary.touchedSlots;
		if (!CS$4$0001) {
			break;
		}
		var D_0 = this.next;
		var CS$0$0002 = D_0;
		this.next = D_0 + 1;
		var cur = CS$0$0002;
		var link = this.dictionary.linkSlots[cur];
		CS$4$0001 = (link.HashCode & -2147483648) == 0;
		if (!CS$4$0001) {
			var key = this.dictionary.keySlots[cur];
			var value = this.dictionary.valueSlots[cur];
			this.current = new System.Collections.Generic.KeyValuePair$2().$ctor(key, value);
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
