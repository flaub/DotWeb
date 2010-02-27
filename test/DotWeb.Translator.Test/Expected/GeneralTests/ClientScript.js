$Class(null, 'DotWeb.Client', 'JsScript');

DotWeb.Client.JsScript.prototype.$ctor = function() {
	return this;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(DotWeb.Client.JsScript, 'H8', 'GeneralTests_ClientScriptClass');

H8.GeneralTests_ClientScriptClass.prototype.$ctor = function() {
	this.$super.$ctor();
	System.Console.WriteLine$1("Hello");
	return this;
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.ClientScript = function() {
	new H8.GeneralTests_ClientScriptClass().$ctor();
};
