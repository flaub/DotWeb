$Class(null, 'H8', 'SystemTests_Base');

H8.SystemTests_Base.prototype.$ctor = function() {
	return this;
};

H8.SystemTests_Base.prototype.Foo = function() {
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestBase = function() {
	var x = new H8.SystemTests_Base().$ctor();
	x.Foo();
};
