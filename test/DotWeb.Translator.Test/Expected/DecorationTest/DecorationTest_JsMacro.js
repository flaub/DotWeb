H8.DecorationTests.prototype.TestJsMacro = function() {
	this.jQuery("*");
	H8.DecorationTests.jQuery("*");
	H8.DecorationTests.TakeJQuery(this.jQuery("#id"));
	System.Console.WriteLine$0($doc.getElementById("id"));
};
