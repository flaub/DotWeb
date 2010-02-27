$Namespace('H8');

H8.Base = function() {
};

H8.Derived = function() {
	this.$super.constructor();
};
H8.Derived.$extend(H8.Base);

H8.Derived.NextId = function() {
	var D_0 = H8.Derived.counter;
	H8.Derived.counter = D_0 + 1;
	return D_0;
};

H8.Base.prototype.$ctor = function() {
	return this;
};

H8.Derived.prototype.$ctor$0 = function() {
	this.id = H8.Derived.NextId();
	this.$super.$ctor();
	return this;
};

H8.Base.prototype.BaseMethod = function() {
};

H8.Derived.prototype.DerviedMethod = function() {
	this.BaseMethod();
};

H8.GeneralTests = function() {
};

H8.GeneralTests.prototype.CallDerived = function() {
	var derived = new H8.Derived().$ctor$0();
	derived.DerviedMethod();
	derived.BaseMethod();
};
