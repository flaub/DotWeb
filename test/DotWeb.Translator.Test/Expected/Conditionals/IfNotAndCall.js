Conditionals.prototype.IfNotAndCall = function(element, i, array) {
	if (!this.foundFirst && (this.item === element)) {
		this.foundFirst = true;
		return 0;
	}
	return 1;
};
