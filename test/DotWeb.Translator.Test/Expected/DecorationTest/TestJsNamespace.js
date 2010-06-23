$Class(null, '', 'DefaultNamespaceTest', { _Value_k__BackingField: 0 });

DefaultNamespaceTest.prototype.$ctor = function() {
	return this;
};

DefaultNamespaceTest.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

$Class(null, 'Foo', 'FooNamespaceTest', { _Value_k__BackingField: 0 });

Foo.FooNamespaceTest.prototype.$ctor = function() {
	return this;
};

DefaultNamespaceTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

Foo.FooNamespaceTest.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

Foo.FooNamespaceTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

//>System.Console.WriteLine$0 

$Class(null, 'H8', 'DecorationTests');

H8.DecorationTests.prototype.TestJsNamespace = function() {
	var __g__initLocal5 = new DefaultNamespaceTest().$ctor();
	__g__initLocal5.set_Value(1);
	var item1 = __g__initLocal5;
	var __g__initLocal6 = new Foo.FooNamespaceTest().$ctor();
	__g__initLocal6.set_Value(item1.get_Value());
	var item2 = __g__initLocal6;
	System.Console.WriteLine$0(item2.get_Value());
};
