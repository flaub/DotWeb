H8.DecorationTests.prototype.TestJsCamelCase = function() {
	var x = new H8.CamelCaseTest().$ctor();
	x.camelCase();
	x.NotCamelCase();
	this.camelCase();
};
