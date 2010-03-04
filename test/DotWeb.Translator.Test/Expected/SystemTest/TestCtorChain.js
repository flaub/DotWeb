$Class(null, 'H8', 'SystemTests_CtorChain');

H8.SystemTests_CtorChain.prototype.$ctor$1 = function(x) {
	return this;
};

H8.SystemTests_CtorChain.prototype.$ctor$0 = function() {
	this.$ctor$1(55);
	return this;
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.TestCtorChain = function() {
	new H8.SystemTests_CtorChain().$ctor$0();
};
