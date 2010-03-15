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

System.Collections.Generic.Dictionary$2.prototype.$ctor$3 = function(capacity) {
	this.Init(capacity, null);
	return this;
};

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.GetHashCode = function(obj) {
	var V_1 = obj != null;
	if (!V_1) {
		return 0;
	}
	return obj.GetHashCode();
};

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.Equals = function(x, y) {
	var V_1 = x != null;
	if (!V_1) {
		return y == null;
	}
	return (x == y);
};

System.ArgumentException.prototype.$ctor$1 = function(message) {
	this.$super.$ctor$1(message);
	return this;
};

System.Collections.Generic.Dictionary$2.TestPrime = function(x) {
	var V_3 = (x & 1) == 0;
	if (!V_3) {
		var V_0 = Math.floor(Math.sqrt(x));
		var V_1 = 3;
		while (true) {
			V_3 = V_1 < V_0;
			if (!V_3) {
				break;
			}
			V_3 = (x % V_1) != 0;
			if (!V_3) {
				return false;
			}
			V_1 = V_1 + 2;
		}
		return true;
	}
	return x == 2;
};

System.Collections.Generic.Dictionary$2.CalcPrime = function(x) {
	var V_0 = (x & -2) - 1;
	while (true) {
		var V_2 = V_0 < 2147483647;
		if (!V_2) {
			break;
		}
		V_2 = !System.Collections.Generic.Dictionary$2.TestPrime(V_0);
		if (!V_2) {
			return V_0;
		}
		V_0 = V_0 + 2;
	}
	return x;
};

System.Collections.Generic.Dictionary$2.ToPrime = function(x) {
	var V_0 = 0;
	while (true) {
		var V_2 = V_0 < System.Collections.Generic.Dictionary$2.primeTable.length;
		if (!V_2) {
			break;
		}
		V_2 = x > System.Collections.Generic.Dictionary$2.primeTable[V_0];
		if (!V_2) {
			return System.Collections.Generic.Dictionary$2.primeTable[V_0];
		}
		V_0 = V_0 + 1;
	}
	return System.Collections.Generic.Dictionary$2.CalcPrime(x);
};

System.ArgumentOutOfRangeException.prototype.$ctor$3 = function(paramName, message) {
	this.$super.$ctor$3(message, paramName);
	return this;
};

$Class(System.ArgumentException, 'System', 'ArgumentNullException');

(function() {
	System.ArgumentNullException.DefaultMessage = "Value cannot be null.";
})();

System.ArgumentNullException.prototype.$ctor$1 = function(paramName) {
	this.$super.$ctor$3(System.ArgumentNullException.DefaultMessage, paramName);
	return this;
};

Array.Copy = function(sourceArray, sourceIndex, destinationArray, destinationIndex, length) {
	var V_1 = sourceArray != null;
	if (!V_1) {
		throw new System.ArgumentNullException().$ctor$1("sourceArray");
	}
	V_1 = destinationArray != null;
	if (!V_1) {
		throw new System.ArgumentNullException().$ctor$1("destinationArray");
	}
	V_1 = length >= 0;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "Value has to be >= 0.");
	}
	V_1 = sourceIndex >= 0;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("sourceIndex", "Value has to be >= 0.");
	}
	V_1 = destinationIndex >= 0;
	if (!V_1) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("destinationIndex", "Value has to be >= 0.");
	}
	var V_0 = 0;
	while (true) {
		V_1 = V_0 < length;
		if (!V_1) {
			break;
		}
		destinationArray[destinationIndex + V_0] = sourceArray[sourceIndex + V_0];
		V_0 = V_0 + 1;
	}
};

System.Collections.Generic.Dictionary$2.prototype.Resize = function() {
	var V_0 = System.Collections.Generic.Dictionary$2.ToPrime((this.table.length << 1) | 1);
	var V_1 = $Array(V_0, 0);
	var V_2 = $Array(V_0, null);
	var V_3 = 0;
	while (true) {
		var V_10 = V_3 < this.table.length;
		if (!V_10) {
			break;
		}
		var V_4 = this.table[V_3] - 1;
		while (true) {
			V_10 = V_4 != -1;
			if (!V_10) {
				break;
			}
			var D_0 = this.hcp.GetHashCode(this.keySlots[V_4]) | -2147483648;
			var V_9 = D_0;
			V_2[V_4].HashCode = D_0;
			var V_5 = V_9;
			var V_6 = (V_5 & 2147483647) % V_0;
			V_2[V_4].Next = V_1[V_6] - 1;
			V_1[V_6] = V_4 + 1;
			V_4 = this.linkSlots[V_4].Next;
		}
		V_3 = V_3 + 1;
	}
	this.table = V_1;
	this.linkSlots = V_2;
	var V_7 = $Array(V_0, null);
	var V_8 = $Array(V_0, null);
	Array.Copy(this.keySlots, 0, V_7, 0, this.touchedSlots);
	Array.Copy(this.valueSlots, 0, V_8, 0, this.touchedSlots);
	this.keySlots = V_7;
	this.valueSlots = V_8;
	this.threshold = Math.floor(V_0 * 0.9);
};

System.Collections.Generic.Dictionary$2.prototype.PutImpl = function(key, value) {
	var V_3 = key != null;
	if (!V_3) {
		throw new System.ArgumentNullException().$ctor$1("key");
	}
	var V_0 = this.hcp.GetHashCode(key) | -2147483648;
	var V_1 = (V_0 & 2147483647) % this.table.length;
	var V_2 = this.table[V_1] - 1;
	while (true) {
		V_3 = V_2 != -1;
		if (!V_3) {
			break;
		}
		if (this.linkSlots[V_2].HashCode == V_0) {
			var R_1 = !this.hcp.Equals(this.keySlots[V_2], key);
		}
		else {
			R_1 = 1;
		}
		V_3 = R_1;
		if (!V_3) {
			throw new System.ArgumentException().$ctor$1("An element with the same key already exists in the dictionary.");
		}
		V_2 = this.linkSlots[V_2].Next;
	}
	var D_0 = this.count + 1;
	var V_4 = D_0;
	this.count = D_0;
	V_3 = V_4 <= this.threshold;
	if (!V_3) {
		this.Resize();
		V_1 = (V_0 & 2147483647) % this.table.length;
	}
	V_2 = this.emptySlot;
	V_3 = V_2 != -1;
	if (!V_3) {
		var D_1 = this.touchedSlots;
		V_4 = D_1;
		this.touchedSlots = D_1 + 1;
		V_2 = V_4;
	}
	else {
		this.emptySlot = this.linkSlots[V_2].Next;
	}
	V_3 = this.linkSlots[V_2] != null;
	if (!V_3) {
		this.linkSlots[V_2] = {};
	}
	this.linkSlots[V_2].HashCode = V_0;
	this.linkSlots[V_2].Next = this.table[V_1] - 1;
	this.table[V_1] = V_2 + 1;
	this.keySlots[V_2] = key;
	this.valueSlots[V_2] = value;
	this.generation = this.generation + 1;
};

System.Collections.Generic.Dictionary$2.prototype.Add$0 = function(key, value) {
	this.PutImpl(key, value);
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestDictionary = function() {
	var dict = new System.Collections.Generic.Dictionary$2().$ctor$3(1);
	dict.Add$0("key", "value");
};
