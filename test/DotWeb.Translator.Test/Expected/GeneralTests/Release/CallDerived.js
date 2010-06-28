$Class(null, 'H8', 'Base', { _X_k__BackingField: 0 });

$Class(H8.Base, 'H8', 'Derived', { id: 0 });

(function() {
	H8.Derived.counter = 0;
})();

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
	H8.Base.prototype.$ctor.call(this);
	return this;
};

H8.Base.prototype.BaseMethod = function() {
};

H8.Derived.prototype.DerviedMethod = function() {
	this.BaseMethod();
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.CallDerived = function() {
	var derived = new H8.Derived().$ctor$0();
	derived.DerviedMethod();
	derived.BaseMethod();
};
