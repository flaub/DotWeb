$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value) {
	console.log(value);
};

$Namespace('H8');

H8.DecorationTests = function() {
};

H8.DecorationTests.prototype.TestJsAnonymous = function() {
	var __g__initLocal0 = {};
	__g__initLocal0.X = 1;
	__g__initLocal0.y = 2;
	var item = __g__initLocal0;
	item.X = item.y;
	item.y = item.X;
	var CS$0$0000 = new Array(2);
	var __g__initLocal1 = {};
	__g__initLocal1.X = 0;
	__g__initLocal1.y = 0;
	CS$0$0000[0] = __g__initLocal1;
	var __g__initLocal2 = {};
	__g__initLocal2.X = 1;
	__g__initLocal2.y = 1;
	CS$0$0000[1] = __g__initLocal2;
	var array = CS$0$0000;
	var first = array[0];
	System.Console.WriteLine(first);
	var dynamic = {};
	dynamic.id = "1";
};
