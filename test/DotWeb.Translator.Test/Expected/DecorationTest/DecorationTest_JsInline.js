H8.DecorationTests.prototype.TestJsInline = function() {
	jQuery("*");
	H8.DecorationTests.TakeJQuery(jQuery("#id"));
	System.Console.WriteLine($doc.getElementById("id"));
};
