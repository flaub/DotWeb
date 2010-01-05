H8.DecorationTests.prototype.TestJsMacro = function() {
	jQuery("*");
	H8.DecorationTests.TakeJQuery(jQuery("#id"));
	System.Console.WriteLine($doc.getElementById("id"));
};
