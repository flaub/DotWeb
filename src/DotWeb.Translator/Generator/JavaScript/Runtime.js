$wnd = window;
$doc = $wnd.document;

function $(id) {
    return document.getElementById(id);
}

Object.prototype.$extend = function(superclass) {
	var tmp = function() {};
	tmp.prototype = superclass.prototype;
	this.prototype = new tmp();
	this.prototype.constructor = this;
	this.prototype.$super = tmp.prototype;
};

$Delegate = function(scope, target) {
	return function() {
		return target.apply(scope, arguments);
	};
};

$Namespace = function(name) {
	if (!$wnd.__namespaces) {
		$wnd.__namespaces = {};
	}

	if ($wnd.__namespaces[name]) {
		return;
	}

	var parent = $wnd;
	var parts = name.split('.');

	for (var i = 0; i < parts.length; i++) {
		var part = parts[i];
		var child = parent[part];
		if(!child) {
			parent[part] = child = {};
		}
		parent = child;
	}
	
	$wnd.__namespaces[name] = child;
}
