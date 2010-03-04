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
//		if (ns) console.log(ns + '.' + name); else console.log(name);
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

Error.prototype.get_Message = function() {
	return this.message;
}
