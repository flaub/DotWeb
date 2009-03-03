H8.SourceTests.prototype.Callback = function(del /*H8.SourceTests_SimpleDelegate*/) {
	if (del) {
		del.Invoke();
	}
	if (this.SimpleEvent) {
		this.SimpleEvent.Invoke();
	}
	this.SimpleEvent = /*(H8.SourceTests_SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, this.SourceTests_SimpleEvent);
};

