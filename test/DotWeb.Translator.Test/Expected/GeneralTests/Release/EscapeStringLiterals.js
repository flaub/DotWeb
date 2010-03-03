H8.GeneralTests.prototype.EscapeStringLiterals = function() {
	System.Console.WriteLine$1("line 1\nline 2");
	System.Console.WriteLine$1("\tindented");
	System.Console.WriteLine$1("x\\y");
	System.Console.WriteLine$1("begin \"quoted\" end");
};
