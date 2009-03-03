$wnd = window;
$doc = $wnd.document;

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
