$Class(null, 'H8', 'Generic$1');

H8.Generic$1.prototype.$ctor = function() {
	return this;
};

$Class(null, 'H8', 'Generic$1_Nested');

H8.Generic$1_Nested.prototype.$ctor = function() {
	return this;
};

$Class(null, 'H8', 'Generic$1_Nested_Inner');

H8.Generic$1_Nested_Inner.prototype.$ctor = function() {
	return this;
};

H8.Generic$1_Nested_Inner.prototype.Foo = function() {
};

H8.Generic$1_Nested.prototype.Foo = function() {
	var x = new H8.Generic$1_Nested_Inner().$ctor();
	x.Foo();
};

$Class(null, 'H8', 'Generic$1_Nested$1');

H8.Generic$1_Nested$1.prototype.$ctor = function() {
	return this;
};

$Class(null, 'H8', 'Generic$1_Nested$1_Inner$2');

H8.Generic$1_Nested$1_Inner$2.prototype.$ctor = function() {
	return this;
};

H8.Generic$1_Nested$1_Inner$2.prototype.Foo = function() {
};

H8.Generic$1_Nested$1.prototype.Foo = function() {
	var x = new H8.Generic$1_Nested$1_Inner$2().$ctor();
	x.Foo();
};

H8.Generic$1.prototype.Foo = function() {
	var x = new H8.Generic$1_Nested().$ctor();
	x.Foo();
	var y = new H8.Generic$1_Nested$1().$ctor();
	y.Foo();
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.TestGenericNested = function() {
	var x = new H8.Generic$1().$ctor();
	x.Foo();
};
