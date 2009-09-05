H8.NativeTest.prototype.TestTuple = function() {
	var loc3 = {};
	loc3.id = 666;
	loc3.value = "value";
	var loc0 = loc3;
	var loc1 = new Tuple(loc0);
	var loc2 = loc1.id;
	console.log(loc2);
	loc1.id = 9;
};
