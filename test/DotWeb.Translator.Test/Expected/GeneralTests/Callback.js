$Namespace('System');

System.Exception = function() {
};

System.Exception.prototype.set_Message = function(value) {
	this._Message_k__BackingField = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

System.SystemException = function() {
	this.$super.constructor();
};
System.SystemException.$extend(System.Exception);

System.SystemException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1("System error.");
	return this;
};

System.NotImplementedException = function() {
	this.$super.constructor();
};
System.NotImplementedException.$extend(System.SystemException);

System.NotImplementedException.prototype.$ctor$0 = function() {
	this.$super.$ctor$0();
	return this;
};

$Namespace('H8');

H8.GeneralTests = function() {
};

H8.GeneralTests.prototype.SourceTests_SimpleEvent = function() {
	throw new System.NotImplementedException().$ctor$0();
};

System.NotSupportedException = function() {
	this.$super.constructor();
};
System.NotSupportedException.$extend(System.SystemException);

System.NotSupportedException.prototype.$ctor$0 = function() {
	this.$super.$ctor$0();
	return this;
};

System.Delegate = function() {
};

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
	var D_0 = this;
	D_0.SimpleEvent = System.Delegate.Combine(D_0.SimpleEvent, $Delegate(this, this.SourceTests_SimpleEvent));
};
