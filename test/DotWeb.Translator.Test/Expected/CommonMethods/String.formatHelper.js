String.formatHelper = function(result, format, args) {
	var CS$4$0001 = format != null;
	if (!CS$4$0001) {
		throw new System.ArgumentNullException().$ctor$1("format");
	}
	CS$4$0001 = args != null;
	if (!CS$4$0001) {
		throw new System.ArgumentNullException().$ctor$1("args");
	}
	CS$4$0001 = result != null;
	if (!CS$4$0001) {
		result = new System.Text.StringBuilder().$ctor();
	}
	var ptr = 0;
	var start = ptr;
	while (true) {
		CS$4$0001 = ptr < format.length;
		if (!CS$4$0001) {
			break;
		}
		var D_0 = ptr;
		ptr = D_0 + 1;
		var ch = format.charAt(D_0);
		CS$4$0001 = ch != '{';
		if (!CS$4$0001) {
			result.Append$5(format, start, (ptr - start) - 1);
			CS$4$0001 = format.charAt(ptr) != '{';
			if (!CS$4$0001) {
				var D_2 = ptr;
				ptr = D_2 + 1;
				start = D_2;
				continue;
			}
			var specifier = new System.String_FormatSpecifier().$ctor(format, ptr);
			ptr = specifier.ptr;
			CS$4$0001 = specifier.n < args.length;
			if (!CS$4$0001) {
				throw new System.FormatException().$ctor$1("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");
			}
			var arg = args[specifier.n];
			CS$4$0001 = arg != null;
			if (!CS$4$0001) {
				var str = "";
			}
			str = arg.toString();
			CS$4$0001 = specifier.width <= str.length;
			if (!CS$4$0001) {
				var padlen = specifier.width - str.length;
				CS$4$0001 = !specifier.left_align;
				if (!CS$4$0001) {
					result.Append$0(str);
					result.Append$3(' ', padlen);
				}
				else {
					result.Append$3(' ', padlen);
					result.Append$0(str);
				}
			}
			else {
				result.Append$0(str);
			}
			start = ptr;
			CS$4$0001 = R_1;
			if (!CS$4$0001) {
				result.Append$5(format, start, (ptr - start) - 1);
				var D_1 = ptr;
				ptr = D_1 + 1;
				start = D_1;
			}
			else {
				CS$4$0001 = ch != '}';
				if (!CS$4$0001) {
					throw new System.FormatException().$ctor$1("Input string was not in a correct format.");
				}
			}
		}
		else {
			if ((ch == '}') && (ptr < format.length)) {
				var R_1 = format.charAt(ptr) != '}';
			}
			else {
				R_1 = 1;
			}
		}
	}
	CS$4$0001 = start >= format.length;
	if (!CS$4$0001) {
		result.Append$5(format, start, format.length - start);
	}
	return result;
};