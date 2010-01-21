$Namespace('H8');

H8.SystemTests_Base = function() {
};

H8.SystemTests_Base.prototype.$ctor = function() {
	return this;
};

H8.SystemTests_Derived = function() {
	this.$super.constructor();
};
H8.SystemTests_Derived.$extend(H8.SystemTests_Base);

H8.SystemTests_Derived.prototype.$ctor = function() {
	this.$super.$ctor.call(this);
	return this;
};

H8.SystemTests_Base.prototype.Foo = function() {
};

H8.SystemTests_Derived.prototype.Foo = function() {
	this.$super.Foo();
	this.Foo();
};

H8.SystemTests = function() {
};

H8.SystemTests.prototype.UseBase = function(x /*H8.SystemTests_Base*/) {
	x.Foo();
};

H8.SystemTests.prototype.TestDerivedThruBaseIndirect = function() {
	var x = new H8.SystemTests_Derived().$ctor();
	this.UseBase(x);
};
