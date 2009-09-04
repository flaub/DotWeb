H8.SourceTests.prototype.CreateOuterObject = function() {
	var loc0 = new H8.OuterClassTest().$ctor("Test1", 1);
	var loc2 = new H8.OuterClassTest().$ctor();
	loc2.set_Text("Test2");
	loc2.set_Value(2);
	var loc1 = loc2;
	console.log("{0}, {1}", loc0.get_Text(), loc0.get_Value());
	console.log("{0}, {1}", loc1.get_Text(), loc1.get_Value());
};

