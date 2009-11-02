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
	var __g__initLocal5 = new DefaultNamespaceTest().$ctor();
	__g__initLocal5.set_Value(1);
	var item1 = __g__initLocal5;
	var __g__initLocal6 = new Foo.FooNamespaceTest().$ctor();
	__g__initLocal6.set_Value(item1.get_Value());
	var item2 = __g__initLocal6;
	System.Console.WriteLine(item2.get_Value());
};
