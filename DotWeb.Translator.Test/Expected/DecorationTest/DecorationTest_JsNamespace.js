if(typeof(H8) == 'undefined') H8 = {};

DefaultNamespaceTest = function() {
};

DefaultNamespaceTest.prototype.$ctor = function() {
	return this;
};

DefaultNamespaceTest.prototype.set_Value = function(value /*System.Int32*/) {
	this._Value_k__BackingField = value;
};

Foo.FooNamespaceTest = function() {
};

Foo.FooNamespaceTest.prototype.$ctor = function() {
	return this;
};

DefaultNamespaceTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

Foo.FooNamespaceTest.prototype.set_Value = function(value /*System.Int32*/) {
	this._Value_k__BackingField = value;
};

Foo.FooNamespaceTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

H8.DecorationTests = function() {
};

H8.DecorationTests.prototype.TestJsNamespace = function() {
	var loc2 = new DefaultNamespaceTest().$ctor();
	loc2.set_Value(1);
	var loc0 = loc2;
	var loc3 = new Foo.FooNamespaceTest().$ctor();
	loc3.set_Value(loc0.get_Value());
	var loc1 = loc3;
	console.log(loc1.get_Value());
};
