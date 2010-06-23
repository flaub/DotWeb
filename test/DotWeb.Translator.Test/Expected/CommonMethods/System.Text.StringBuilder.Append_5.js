System.Text.StringBuilder.prototype.Append$5 = function(value, startIndex, count) {
	var CS$4$0001 = value != null;
	if (!CS$4$0001) {
		if (startIndex) {
			var R_1 = count == 0;
		}
		else {
			R_1 = 1;
		}
		CS$4$0001 = R_1;
		if (!CS$4$0001) {
			throw new System.ArgumentNullException().$ctor$1("value");
		}
		return this;
	}
	if ((count >= 0) && (startIndex >= 0)) {
		R_1 = startIndex <= (value.length - count);
	}
	else {
		R_1 = 0;
	}
	CS$4$0001 = R_1;
	if (!CS$4$0001) {
		throw new System.ArgumentOutOfRangeException().$ctor$0();
	}
	var i = startIndex;
	while (true) {
		CS$4$0001 = i < (startIndex + count);
		if (!CS$4$0001) {
			break;
		}
		this.Append$1(value.charAt(i));
		i = i + 1;
	}
	return this;
};
