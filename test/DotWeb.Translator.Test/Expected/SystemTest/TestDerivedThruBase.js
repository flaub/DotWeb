$Class(null, 'H8', 'SystemTests_Base');

H8.SystemTests_Base.prototype.$ctor = function() {
	return this;
};

$Class(H8.SystemTests_Base, 'H8', 'SystemTests_Derived');

H8.SystemTests_Derived.prototype.$ctor = function() {
	H8.SystemTests_Base.prototype.$ctor.call(this);
	return this;
};

H8.SystemTests_Base.prototype.Foo = function() {
};

H8.SystemTests_Derived.prototype.Foo = function() {
	H8.SystemTests_Base.prototype.Foo.call(this);
	this.Foo();
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestDerivedThruBase = function() {
	var x = new H8.SystemTests_Derived().$ctor();
	x.Foo();
};
