$Namespace('H8');

H8.IntrinsicClass = function() {
};

H8.IntrinsicClass.prototype.$ctor = function() {
	return this;
};

$Namespace('System');

System.Console = function() {
};

System.Console.Write = function(value /*System.Int32*/) {
	// nop
};

$Namespace('DotWeb.Client');

DotWeb.Client.JsScript = function() {
};

H8.DecorationTests = function() {
	this.$super.constructor();
};
H8.DecorationTests.$extend(DotWeb.Client.JsScript);

H8.DecorationTests.prototype.TestJsIntrinsic = function() {
	var loc1 = new H8.IntrinsicClass().$ctor();
	loc1.Value = 1;
	var loc0 = loc1;
	System.Console.Write(loc0.Value);
};
