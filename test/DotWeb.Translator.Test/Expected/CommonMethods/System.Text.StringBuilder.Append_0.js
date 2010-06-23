System.Text.StringBuilder.prototype.Append$0 = function(value) {
	var CS$4$0001 = value != null;
	if (!CS$4$0001) {
		return this;
	}
	CS$4$0001 = value.length != 0;
	if (!CS$4$0001) {
		this.value = value;
		return this;
	}
	this.value = this.value + value;
	return this;
};