H8.SourceTests.prototype.CreateOuterObject = function() {
	var loc0 = new H8.OuterClassTest().$ctor("Test1", 1);
	var loc2 = new H8.OuterClassTest().$ctor();
	loc2.Text = "Test2";
	loc2.Value = 2;
	var loc1 = loc2;
	console.log("{0}, {1}", loc0.Text, loc0.Value);
	console.log("{0}, {1}", loc1.Text, loc1.Value);
};

