System.ArgumentOutOfRangeException.prototype.get_Message = function() {
	var message = this.$super.get_Message();
	var CS$4$0001 = this.get_ActualValue() != null;
	if (!CS$4$0001) {
		return message;
	}
	var str2 = "Actual value was " + this.get_ActualValue().toString();
	CS$4$0001 = message != null;
	if (!CS$4$0001) {
		return str2;
	}
	return message + "\n" + str2;
};
