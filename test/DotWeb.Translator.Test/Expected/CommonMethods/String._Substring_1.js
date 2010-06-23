String.prototype._Substring$1 = function(startIndex, length) {
	var CS$4$0001 = length >= 0;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "Cannot be negative.");
	}
	CS$4$0001 = startIndex >= 0;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("startIndex", "Cannot be negative.");
	}
	CS$4$0001 = startIndex <= this.length;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("startIndex", "Cannot exceed length of string.");
	}
	CS$4$0001 = startIndex <= (this.length - length);
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$3("length", "startIndex + length > this.length");
	}
	if (!startIndex) {
		var R_1 = length != this.length;
	}
	else {
		R_1 = 1;
	}
	CS$4$0001 = R_1;
	if (!CS$4$0001) {
		return this;
	}
	return this.substring(startIndex, startIndex + length);
};
