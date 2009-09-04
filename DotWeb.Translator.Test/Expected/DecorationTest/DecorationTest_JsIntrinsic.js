H8.IntrinsicClass = function() {
};

H8.IntrinsicClass.prototype.$ctor = function() {
	return this;
};

H8.DecorationTests.prototype.TestJsIntrinsic = function() {
	var loc1 = new H8.IntrinsicClass().$ctor();
	loc1.Value = 1;
	var loc0 = loc1;
	System.Console.Write(loc0.Value);
};
