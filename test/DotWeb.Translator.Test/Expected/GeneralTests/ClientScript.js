$Namespace('DotWeb.Client');

DotWeb.Client.JsScript = function() {
};

DotWeb.Client.JsScript.prototype.$ctor = function() {
	return this;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Namespace('H8');

H8.GeneralTests_ClientScriptClass = function() {
	this.$super.constructor();
};
H8.GeneralTests_ClientScriptClass.$extend(DotWeb.Client.JsScript);

H8.GeneralTests_ClientScriptClass.prototype.$ctor = function() {
	this.$super.$ctor();
	System.Console.WriteLine$1("Hello");
	return this;
};

H8.GeneralTests = function() {
};

H8.GeneralTests.prototype.ClientScript = function() {
	new H8.GeneralTests_ClientScriptClass().$ctor();
};
