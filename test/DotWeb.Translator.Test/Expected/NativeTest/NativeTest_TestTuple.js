H8.NativeTest.prototype.TestTuple = function() {
	var __g__initLocal0 = {};
	__g__initLocal0.id = 666;
	__g__initLocal0.value = "value";
	var config = __g__initLocal0;
	var tuple = new Tuple(config);
	var id = tuple.id;
	System.Console.WriteLine(id);
	tuple.id = 9;
};
