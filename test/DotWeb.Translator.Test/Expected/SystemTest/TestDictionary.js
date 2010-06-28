$Class(null, 'System.Collections.Generic', 'EqualityComparer$1');

System.Collections.Generic.EqualityComparer$1.prototype.$ctor = function() {
	return this;
};

$Class(System.Collections.Generic.EqualityComparer$1, 'System.Collections.Generic', 'EqualityComparer$1_DefaultComparer');

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.$ctor = function() {
	System.Collections.Generic.EqualityComparer$1.prototype.$ctor.call(this);
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

//>System.ArgumentException.$ctor$3

$Class(System.ArgumentException, 'System', 'ArgumentOutOfRangeException', { _ActualValue_k__BackingField: null });

(function() {
	System.ArgumentOutOfRangeException.RangeMessage = "Specified argument was out of the range of valid values.";
})();

//>System.ArgumentOutOfRangeException.$ctor$1

//>System.Collections.Generic.Dictionary$2.Init

System.Collections.Generic.Dictionary$2.prototype.$ctor$3 = function(capacity) {
	this.Init(capacity, null);
	return this;
};

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.GetHashCode = function(obj) {
	var CS$4$0001 = obj != null;
	if (!CS$4$0001) {
		return 0;
	}
	return obj.GetHashCode();
};

System.Collections.Generic.EqualityComparer$1_DefaultComparer.prototype.Equals = function(x, y) {
	var CS$4$0001 = x != null;
	if (!CS$4$0001) {
		return y == null;
	}
	return (x == y);
};

//>System.ArgumentException.$ctor$1

System.Collections.Generic.Dictionary$2.TestPrime = function(x) {
	var CS$4$0001 = (x & 1) == 0;
	if (!CS$4$0001) {
		var top = Math.floor(Math.sqrt(x));
		var n = 3;
		while (true) {
			CS$4$0001 = n < top;
			if (!CS$4$0001) {
				break;
			}
			CS$4$0001 = (x % n) != 0;
			if (!CS$4$0001) {
				return false;
			}
			n = n + 2;
		}
		return true;
	}
	return x == 2;
};

System.Collections.Generic.Dictionary$2.CalcPrime = function(x) {
	var i = (x & -2) - 1;
	while (true) {
		var CS$4$0001 = i < 2147483647;
		if (!CS$4$0001) {
			break;
		}
		CS$4$0001 = !System.Collections.Generic.Dictionary$2.TestPrime(i);
		if (!CS$4$0001) {
			return i;
		}
		i = i + 2;
	}
	return x;
};

System.Collections.Generic.Dictionary$2.ToPrime = function(x) {
	var i = 0;
	while (true) {
		var CS$4$0001 = i < System.Collections.Generic.Dictionary$2.primeTable.length;
		if (!CS$4$0001) {
			break;
		}
		CS$4$0001 = x > System.Collections.Generic.Dictionary$2.primeTable[i];
		if (!CS$4$0001) {
			return System.Collections.Generic.Dictionary$2.primeTable[i];
		}
		i = i + 1;
	}
	return System.Collections.Generic.Dictionary$2.CalcPrime(x);
};

//>System.ArgumentOutOfRangeException.$ctor$3

//>System.ArgumentNullException

Array.Copy = function(sourceArray, sourceIndex, destinationArray, destinationIndex, length) {
	var CS$4$0000 = sourceArray != null;
	if (!CS$4$0000) {
		throw new System.ArgumentNullException().$ctor$1("sourceArray");
	}
	CS$4$0000 = destinationArray != null;
	if (!CS$4$0000) {
		throw new System.ArgumentNullException().$ctor$1("destinationArray");
	}
	CS$4$0000 = length >= 0;
	if (!CS$4$0000) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "Value has to be >= 0.");
	}
	CS$4$0000 = sourceIndex >= 0;
	if (!CS$4$0000) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("sourceIndex", "Value has to be >= 0.");
	}
	CS$4$0000 = destinationIndex >= 0;
	if (!CS$4$0000) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("destinationIndex", "Value has to be >= 0.");
	}
	var i = 0;
	while (true) {
		CS$4$0000 = i < length;
		if (!CS$4$0000) {
			break;
		}
		destinationArray[destinationIndex + i] = sourceArray[sourceIndex + i];
		i = i + 1;
	}
};

System.Collections.Generic.Dictionary$2.prototype.Resize = function() {
	var newSize = System.Collections.Generic.Dictionary$2.ToPrime((this.table.length << 1) | 1);
	var newTable = $Array(newSize, 0);
	var newLinkSlots = $Array(newSize, null);
	var i = 0;
	while (true) {
		var CS$4$0001 = i < this.table.length;
		if (!CS$4$0001) {
			break;
		}
		var cur = this.table[i] - 1;
		while (true) {
			CS$4$0001 = cur != -1;
			if (!CS$4$0001) {
				break;
			}
			var D_0 = this.hcp.GetHashCode(this.keySlots[cur]) | -2147483648;
			var CS$0$0000 = D_0;
			newLinkSlots[cur].HashCode = D_0;
			var hashCode = CS$0$0000;
			var index = (hashCode & 2147483647) % newSize;
			newLinkSlots[cur].Next = newTable[index] - 1;
			newTable[index] = cur + 1;
			cur = this.linkSlots[cur].Next;
		}
		i = i + 1;
	}
	this.table = newTable;
	this.linkSlots = newLinkSlots;
	var newKeySlots = $Array(newSize, null);
	var newValueSlots = $Array(newSize, null);
	Array.Copy(this.keySlots, 0, newKeySlots, 0, this.touchedSlots);
	Array.Copy(this.valueSlots, 0, newValueSlots, 0, this.touchedSlots);
	this.keySlots = newKeySlots;
	this.valueSlots = newValueSlots;
	this.threshold = Math.floor(newSize * 0.9);
};

System.Collections.Generic.Dictionary$2.prototype.PutImpl = function(key, value) {
	var CS$4$0000 = key != null;
	if (!CS$4$0000) {
		throw new System.ArgumentNullException().$ctor$1("key");
	}
	var hashCode = this.hcp.GetHashCode(key) | -2147483648;
	var index = (hashCode & 2147483647) % this.table.length;
	var cur = this.table[index] - 1;
	while (true) {
		CS$4$0000 = cur != -1;
		if (!CS$4$0000) {
			break;
		}
		if (this.linkSlots[cur].HashCode == hashCode) {
			var R_1 = !this.hcp.Equals(this.keySlots[cur], key);
		}
		else {
			R_1 = 1;
		}
		CS$4$0000 = R_1;
		if (!CS$4$0000) {
			throw new System.ArgumentException().$ctor$1("An element with the same key already exists in the dictionary.");
		}
		cur = this.linkSlots[cur].Next;
	}
	var D_0 = this.count + 1;
	var CS$0$0001 = D_0;
	this.count = D_0;
	CS$4$0000 = CS$0$0001 <= this.threshold;
	if (!CS$4$0000) {
		this.Resize();
		index = (hashCode & 2147483647) % this.table.length;
	}
	cur = this.emptySlot;
	CS$4$0000 = cur != -1;
	if (!CS$4$0000) {
		var D_1 = this.touchedSlots;
		CS$0$0001 = D_1;
		this.touchedSlots = D_1 + 1;
		cur = CS$0$0001;
	}
	else {
		this.emptySlot = this.linkSlots[cur].Next;
	}
	CS$4$0000 = this.linkSlots[cur] != null;
	if (!CS$4$0000) {
		this.linkSlots[cur] = {};
	}
	this.linkSlots[cur].HashCode = hashCode;
	this.linkSlots[cur].Next = this.table[index] - 1;
	this.table[index] = cur + 1;
	this.keySlots[cur] = key;
	this.valueSlots[cur] = value;
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
