System.Exception.prototype.toString = function() {
	var result = new System.Text.StringBuilder().$ctor();
	result.Append$0(this.$typename);
	result.Append$0(": ").Append$0(this.get_Message());
	var CS$4$0001 = this.get_InnerException() == null;
	if (!CS$4$0001) {
		result.Append$0(" ---> ").Append$0(this.get_InnerException().toString());
		result.AppendLine$0();
		result.Append$0("  --- End of inner exception stack trace ---");
	}
	return result.toString();
};
