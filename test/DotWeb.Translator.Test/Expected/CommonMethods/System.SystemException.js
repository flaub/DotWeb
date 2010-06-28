$Class(System.Exception, 'System', 'SystemException');

System.SystemException.prototype.$ctor$1 = function(message) {
	System.Exception.prototype.$ctor$1.call(this, message);
	return this;
};
