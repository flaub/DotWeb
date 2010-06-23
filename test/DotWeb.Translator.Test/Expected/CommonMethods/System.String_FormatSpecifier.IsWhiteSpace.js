System.String_FormatSpecifier.prototype.IsWhiteSpace = function() {
	var ch = this.str.charCodeAt(this.ptr);
	if ((((ch < 9) || (ch > 13)) && (ch != 32)) && (ch != 133)) {
		var R_1 = ch == 8287;
	}
	else {
		R_1 = 1;
	}
	return R_1;
};
