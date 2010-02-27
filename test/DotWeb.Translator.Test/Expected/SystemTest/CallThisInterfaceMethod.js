$Class(null, 'H8', 'SystemTests_Impl');

H8.SystemTests_Impl.prototype.$ctor = function() {
	return this;
};

H8.SystemTests_Impl.prototype.Foo = function() {
};

H8.SystemTests_Impl.prototype.CallFoo = function() {
	this.Foo();
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.CallThisInterfaceMethod = function() {
	var x = new H8.SystemTests_Impl().$ctor();
	x.CallFoo();
};
