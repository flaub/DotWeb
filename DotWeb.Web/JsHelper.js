$wnd = window;
$doc = $wnd.document;

JsHelper = function() {
	this.functions = {};
}

JsHelper.prototype.getWindow = function() { return $wnd; }
JsHelper.prototype.createObject = function() { return {}; }
JsHelper.prototype.createArray = function() { return []; }
JsHelper.prototype.createArgs = function() { return arguments; }

JsHelper.prototype.defineFunction = function(name, args, body) {
	var str = 'function (' + args + ') { ' + body + ' }';
	debug.log('defineFunction: "' + str + '"');
	var def = eval('(' + str + ')');
	this.functions[name] = def;
}

JsHelper.prototype.invokeFunction = function(name, scope) {
	try {
		debug.log('invokeFunction: ' + name);
		var def = this.functions[name];
		var args = Array.prototype.slice.call(arguments, 2);
		var ret = def.apply(scope, args);
		return [false, ret];
	} 
	catch(e) {
		debug.log('exception: ' + e);
		return [true, e];
	}
}

JsHelper.prototype.invokeDelegate = function(f_) {
	try {
		var args = Array.prototype.slice.call(arguments, 1);
		var ret = f_.apply(args);
		return [false, ret];
	} 
	catch(e) {
		debug.log('exception: ' + e);
		return [true, e];
	}
}

JsHelper.prototype.wrapDelegate = function(f_) {
	return function() { return f_(arguments); };
}

__$helper = new JsHelper();
