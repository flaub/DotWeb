$Class(System.SystemException, 'System', 'IndexOutOfRangeException');

System.IndexOutOfRangeException.prototype.$ctor$0 = function() {
	System.SystemException.prototype.$ctor$1.call(this, "Array index is out of range.");
	return this;
};
