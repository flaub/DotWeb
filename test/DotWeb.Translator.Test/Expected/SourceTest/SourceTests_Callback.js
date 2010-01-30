$Namespace('System');

System.Exception = function() {
};

System.Exception.prototype.$ctor = function() {
	return this;
};

System.SystemException = function() {
	this.$super.constructor();
};
System.SystemException.$extend(System.Exception);

System.SystemException.prototype.$ctor = function() {
	this.$super.$ctor.call(this);
	return this;
};

System.NotImplementedException = function() {
	this.$super.constructor();
};
System.NotImplementedException.$extend(System.SystemException);

System.NotImplementedException.prototype.$ctor = function() {
	this.$super.$ctor.call(this);
	return this;
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.SourceTests_SimpleEvent = function() {
	throw new System.NotImplementedException().$ctor()
};

System.Delegate = function() {
};

System.Delegate.Combine = function(/*System.Delegate*/ a, /*System.Delegate*/ b) {
	throw 'Not Supported';
};

H8.SourceTests.prototype.Callback = function(/*H8.SourceTests_SimpleDelegate*/ del) {
	if (del) {
		del.Invoke();
	}
	if (this.SimpleEvent) {
		this.SimpleEvent.Invoke();
	}
	this.SimpleEvent = /*(H8.SourceTests_SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, $Delegate(this, this.SourceTests_SimpleEvent));
};
