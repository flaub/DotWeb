System.Exception.prototype.get_Message = function() {
	var CS$4$0001 = this.message != null;
	if (!CS$4$0001) {
		this.message = String.format$0("Exception of type '{0}' was thrown.", this.$typename);
	}
	return this.message;
};
