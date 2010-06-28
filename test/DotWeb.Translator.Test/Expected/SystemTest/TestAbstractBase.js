$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'AbstractBase');

$Class(H8.AbstractBase, 'H8', 'AbstractImpl');

H8.AbstractImpl.prototype.Method = function() {
	System.Console.WriteLine$1("Method");
};

H8.AbstractBase.prototype.$ctor = function() {
	this.Method();
	return this;
};

H8.AbstractImpl.prototype.$ctor = function() {
	H8.AbstractBase.prototype.$ctor.call(this);
	return this;
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestAbstractBase = function() {
	new H8.AbstractImpl().$ctor();
};
