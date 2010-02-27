Object.prototype.$extend = function(parent) {
	var tmp = function() { };
	tmp.prototype = parent.prototype;
//	console.log('this is: ' + this);
	this.prototype = new tmp();
	this.prototype.constructor = this;
	this.prototype.$super = tmp.prototype;
};

$Override = function() {
};

BaseClass = function() {
	console.log('BaseClass()');
	// static initializer if needed
};

BaseClass.prototype.$ctor = function(id) {
	this.id = id;
	console.log('BaseClass.$ctor: %s', this.id);
	return this;
};

Class = function() {
	this.$super.constructor();
	console.log('Class()');
};

Class.$extend(BaseClass);
Class.prototype.$ctor = function(id) {
	console.log('Class.$ctor');
	this.$super.$ctor(id);
	return this;
};

Class.prototype.Method = function() {
	console.log('Class.Method: %s', this.id);
};
Class.StaticMethod = function() {
	console.log('Class.StaticMethod');
};

Child = function() {
	this.$super.constructor();
	console.log('Child()');
};
Child.$extend(Class);
Child.prototype.$ctor = function(id) {
	console.log('Child.$ctor');
	this.$super.$ctor(id);
	return this;
};

Child.prototype.Method = function() {
	console.log('Child.Method');
	this.$super.Method();
};

console.log('-----');
Class.StaticMethod();

console.log('-----');
var instance = new Class().$ctor(1);
instance.Method();

console.log('-----');
var child = new Child().$ctor(2);
child.Method();

console.log('-----');
