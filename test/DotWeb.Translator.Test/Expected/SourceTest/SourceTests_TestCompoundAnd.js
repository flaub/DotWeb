H8.SourceTests.prototype.TestCompoundAnd = function() {
	var x = true;
	var y = true;
	if ((x) && (y)) {
		System.Console.Write(1);
		return;
	}
	System.Console.Write(2);
};
