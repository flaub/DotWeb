$wnd = window;
$doc = $wnd.document;
$wnd.__namespaces = {};

$Namespace = function(name) {
	if (!name) return $wnd;

	var ns = $wnd.__namespaces[name];
	if (ns) return ns;

	var parent = $wnd;
	var parts = name.split('.');

	for (var i = 0; i < parts.length; i++) {
		var part = parts[i];
		var child = parent[part];
		if (!child) parent[part] = child = {};
		parent = child;
	}

	$wnd.__namespaces[name] = parent;
	console.log(parent);
	return parent;
}

$Class = function(parent, ns, name, ctor) {
	var cls = function() {
		if (ns) console.log(ns + '.' + name); else console.log(name);
		if (parent) parent();
		if (ctor) ctor.call(this);
	};
	if (parent) {
		var tmp = function() { };
		tmp.prototype = parent.prototype;
		cls.prototype = new tmp();
		cls.prototype.constructor = cls;
		cls.prototype.$super = tmp.prototype;
	}

	var typename = name;
	if (ns) typename = ns + '.' + typename;
	cls.$typename = cls.prototype.$typename = typename;

	var slot = $Namespace(ns);
	slot[name] = cls;

	return cls;
};

$Delegate = function(scope, target) {
	return function() {
		return target.apply(scope, arguments);
	};
};

$Class(null, 'System', 'BaseClass');

System.BaseClass.prototype.$ctor = function(id) {
	this.id = id;
	console.log(this.$typename + '.$ctor: %s', this.id);
	return this;
};

$Class(System.BaseClass, '', 'Class');

Class.prototype.$ctor = function(id) {
	console.log('Class.$ctor');
	this.$super.$ctor(id);
	return this;
};

Class.prototype.Method = function() {
	console.log(this.$typename + '.Method');
};

Class.StaticMethod = function() {
	console.log(this.$typename + '.StaticMethod');
};

$Class(Class, '', 'Child');

Child.prototype.$ctor = function(id) {
	console.log('Child.$ctor');
	this.$super.$ctor(id);
	return this;
};

Child.prototype.Method = function() {
	console.log(this.$typename + '.Method');
	this.$super.Method();
};

console.log('-----');
console.log('> Class.StaticMethod();');
Class.StaticMethod();

console.log('-----');
console.log('> var instance = new Class().$ctor(1);');
var instance = new Class().$ctor(1);
console.log('> instance.Method();');
instance.Method();

console.log('-----');
console.log('> var child = new Child().$ctor(2);');
var child = new Child().$ctor(2);
console.log('> child.Method();');
child.Method();

console.log('-----');

var type = Class;
console.log('> type.$typename == "Class"');
console.log(type.$typename);
console.log('> instance.$typename == "Class"');
console.log(instance.$typename);
console.log('> child.$typename == "Child"');
console.log(child.$typename);
