$Class(System.ArgumentException, 'System', 'ArgumentNullException');

(function() {
	System.ArgumentNullException.DefaultMessage = "Value cannot be null.";
})();

System.ArgumentNullException.prototype.$ctor$1 = function(paramName) {
	System.ArgumentException.prototype.$ctor$3.call(this, System.ArgumentNullException.DefaultMessage, paramName);
	return this;
};
