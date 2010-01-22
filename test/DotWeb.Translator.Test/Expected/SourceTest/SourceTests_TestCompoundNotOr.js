H8.SourceTests.prototype.TestCompoundNotOr = function() {
	var x = true;
	var y = true;
	if ((!x) || (y)) {
		System.Console.Write(2);
		return;
	}
	System.Console.Write(1);
};
