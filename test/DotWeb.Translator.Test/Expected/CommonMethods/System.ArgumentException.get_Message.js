System.ArgumentException.prototype.get_Message = function() {
	var message = System.SystemException.prototype.get_Message.call(this);
	if (this.get_ParamName()) {
		var R_1 = this.get_ParamName().length == 0;
	}
	else {
		R_1 = 1;
	}
	var CS$4$0001 = R_1;
	if (!CS$4$0001) {
		return message + "\nParameter name: " + this.get_ParamName();
	}
	return message;
};
