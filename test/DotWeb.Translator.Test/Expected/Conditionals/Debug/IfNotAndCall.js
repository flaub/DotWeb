Conditionals.prototype.IfNotAndCall = function(element, i, array) {
	if (!this.foundFirst) {
		var R_1 = !(this.item === element);
	}
	else {
		R_1 = 1;
	}
	var CS$4$0001 = R_1;
	if (!CS$4$0001) {
		this.foundFirst = true;
		var CS$1$0000 = false;
	}
	else {
		CS$1$0000 = true;
	}
	return CS$1$0000;
};
