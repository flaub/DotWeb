System.ArgumentException.prototype.$ctor$3 = function(message, paramName) {
	System.SystemException.prototype.$ctor$1.call(this, message);
	this.set_ParamName(paramName);
	return this;
};
