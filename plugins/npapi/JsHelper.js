JsHelper = function() {
	this.functions = {};
};

JsHelper.prototype.defineFunction = function(name, args, body) {
	var str = 'function(' + args + ') { ' + body + ' }';
	var def = eval('(' + str + ')');
	this.functions[name] = def;
}

JsHelper.prototype.invokeFunction = function(name, scope) {
	var def = this.functions[name];
    var args = Array.prototype.slice.call(arguments, 2);
	var ret = def.apply(scope, args);
	return ret;
}

JsHelper.prototype.invokeDelegate = function(delegate) {
    var args = Array.prototype.slice.call(arguments, 1);
	var ret = delegate.apply(args);
	return ret;
}

