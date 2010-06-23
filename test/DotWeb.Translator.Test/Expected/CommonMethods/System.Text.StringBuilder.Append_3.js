System.Text.StringBuilder.prototype.Append$3 = function(value, repeatCount) {
	var i = 0;
	while (true) {
		var CS$4$0001 = i < repeatCount;
		if (!CS$4$0001) {
			break;
		}
		this.Append$1(value);
		i = i + 1;
	}
	return this;
};