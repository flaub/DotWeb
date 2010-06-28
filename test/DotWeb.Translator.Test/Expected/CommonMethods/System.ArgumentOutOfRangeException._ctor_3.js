System.ArgumentOutOfRangeException.prototype.$ctor$3 = function(paramName, message) {
	System.ArgumentException.prototype.$ctor$3.call(this, message, paramName);
	return this;
};
