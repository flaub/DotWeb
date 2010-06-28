$Class(System.SystemException, 'System', 'FormatException');

System.FormatException.prototype.$ctor$1 = function(message) {
	System.SystemException.prototype.$ctor$1.call(this, message);
	return this;
};
