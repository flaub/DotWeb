H8.SourceTests_SimpleDelegate = function() {
	this.$super.constructor();
};
H8.SourceTests_SimpleDelegate.$extend(System.MulticastDelegate);

H8.SourceTests = function() {
};

H8.SourceTests.prototype.SourceTests_SimpleEvent = function() {
	throw new System.NotImplementedException().$ctor()
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

