Object.prototype.$extend = function(superclass) {
	var tmp = function() {};
    tmp.prototype = superclass.prototype;
    this.prototype = new tmp();
    this.prototype.constructor = this;
    this.prototype.$super = tmp.prototype;
};

function BaseClass() {
	console.log('BaseClass: fieldInit');
	// field initializers go here
};

BaseClass.prototype.$ctor = function(id) {
	this.id = id;
	console.log('BaseClass.$ctor: %s', this.id);
	return this;
};

function Class() {
	this.$super.constructor();
	console.log('Class: fieldInit');
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

function Child() {
	this.$super.constructor();
	console.log('Child: fieldInit');
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
var child2 = new Child();
