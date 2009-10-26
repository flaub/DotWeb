DefaultNamespaceTest = function() {
};

DefaultNamespaceTest.prototype.$ctor = function() {
	return this;
};

DefaultNamespaceTest.prototype.set_Value = function(value /*System.Int32*/) {
	this._Value_k__BackingField = value;
};

$Namespace('Foo');

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

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value /*System.Object*/) {
	console.log(value);
};

$Namespace('DotWeb.Client');

DotWeb.Client.JsScript = function() {
};

$Namespace('H8');

H8.DecorationTests = function() {
	this.$super.constructor();
};
H8.DecorationTests.$extend(DotWeb.Client.JsScript);

H8.DecorationTests.prototype.TestJsNamespace = function() {
	var loc2 = new DefaultNamespaceTest().$ctor();
	loc2.set_Value(1);
	var loc0 = loc2;
	var loc3 = new Foo.FooNamespaceTest().$ctor();
	loc3.set_Value(loc0.get_Value());
	var loc1 = loc3;
	System.Console.WriteLine(loc1.get_Value());
};
