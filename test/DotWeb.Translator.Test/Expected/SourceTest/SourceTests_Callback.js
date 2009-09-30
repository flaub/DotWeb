$Namespace('System');

System.Exception = function() {
};

System.Exception.prototype.$ctor = function() {
	// nop
	// nop
	// nop
	return this;
};

System.SystemException = function() {
	this.$super.constructor();
};
System.SystemException.$extend(System.Exception);

System.SystemException.prototype.$ctor = function() {
	this.$super.$ctor.call(this);
	// nop
	// nop
	// nop
	return this;
};

System.NotImplementedException = function() {
	this.$super.constructor();
};
System.NotImplementedException.$extend(System.SystemException);

System.NotImplementedException.prototype.$ctor = function() {
	this.$super.$ctor.call(this);
	// nop
	// nop
	// nop
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

System.Delegate.Combine = function(a /*System.Delegate*/, b /*System.Delegate*/) {
	throw 'Not Supported';
};

H8.SourceTests.prototype.Callback = function(del /*H8.SourceTests_SimpleDelegate*/) {
	if (del) {
		del.Invoke();
	}
	if (this.SimpleEvent) {
		this.SimpleEvent.Invoke();
	}
	this.SimpleEvent = /*(H8.SourceTests_SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, $Delegate(this, this.SourceTests_SimpleEvent));
};
