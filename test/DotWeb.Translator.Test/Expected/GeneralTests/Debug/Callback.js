$Class(null, 'System', 'Exception');

System.Exception.prototype.set_Message = function(value) {
	this._Message_k__BackingField = value;
};

System.Exception.prototype.$ctor$1 = function(message) {
	this.set_Message(message);
	return this;
};

$Class(System.Exception, 'System', 'SystemException');

System.SystemException.prototype.$ctor$0 = function() {
	this.$super.$ctor$1("System error.");
	return this;
};

$Class(System.SystemException, 'System', 'NotImplementedException');

System.NotImplementedException.prototype.$ctor$0 = function() {
	this.$super.$ctor$0();
	return this;
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.SourceTests_SimpleEvent = function() {
	throw new System.NotImplementedException().$ctor$0();
};

$Class(System.SystemException, 'System', 'NotSupportedException');

System.NotSupportedException.prototype.$ctor$0 = function() {
	this.$super.$ctor$0();
	return this;
};

$Class(null, 'System', 'Delegate');

System.Delegate.Combine = function(a, b) {
	throw new System.NotSupportedException().$ctor$0();
};

H8.GeneralTests.prototype.Callback = function(del) {
	var CS$4$0000 = del == null;
	if (!CS$4$0000) {
		del();
	}
	CS$4$0000 = this.SimpleEvent == null;
	if (!CS$4$0000) {
		this.SimpleEvent();
	}
	var D_0 = this;
	D_0.SimpleEvent = System.Delegate.Combine(D_0.SimpleEvent, $Delegate(this, this.SourceTests_SimpleEvent));
};
