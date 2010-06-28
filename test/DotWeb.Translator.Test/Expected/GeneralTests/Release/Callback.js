//>System.Exception

//>System.SystemException

$Class(System.SystemException, 'System', 'NotImplementedException');

System.NotImplementedException.prototype.$ctor$0 = function() {
	System.SystemException.prototype.$ctor$1.call(this, "The requested feature is not implemented.");
	return this;
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.SourceTests_SimpleEvent = function() {
	throw new System.NotImplementedException().$ctor$0();
};

$Class(System.SystemException, 'System', 'NotSupportedException');

System.NotSupportedException.prototype.$ctor$0 = function() {
	System.SystemException.prototype.$ctor$1.call(this, "Operation is not supported.");
	return this;
};

$Class(null, 'System', 'Delegate');

System.Delegate.Combine = function(a, b) {
	throw new System.NotSupportedException().$ctor$0();
};

H8.GeneralTests.prototype.Callback = function(del) {
	if (del) {
		del();
	}
	if (this.SimpleEvent) {
		this.SimpleEvent();
	}
	this.SimpleEvent = System.Delegate.Combine(this.SimpleEvent, $Delegate(this, this.SourceTests_SimpleEvent));
};
