$Namespace('System.Collections.Generic');

System.Collections.Generic.List$1 = function() {
};

System.Collections.Generic.List$1.prototype.$ctor = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.toString = function() {
	var V_0 = "[ " + this.items.toString() + " ]";
	return V_0;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value /*System.String*/) {
	console.log(value);
};

$Namespace('H8');

H8.SystemTests = function() {
};

H8.SystemTests.prototype.TestToStringDirect = function() {
	var list = new System.Collections.Generic.List$1().$ctor();
	System.Console.WriteLine(list.toString());
};
