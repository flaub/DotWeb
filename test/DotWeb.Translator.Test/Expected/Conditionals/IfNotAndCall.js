Conditionals.prototype.IfNotAndCall = function(/*System.Object*/ element, /*System.Int32*/ i, /*System.DotWeb.JsArray*/ array) {
	if (!this.foundFirst && (this.item === element)) {
		this.foundFirst = true;
		return 0;
	}
	return 1;
};
