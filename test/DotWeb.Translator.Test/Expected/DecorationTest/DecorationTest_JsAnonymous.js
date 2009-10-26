$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value /*System.Object*/) {
	console.log(value);
};

$Namespace('DotWeb.Client');

DotWeb.Client.JsScript = function() {
};

$Namespace('H8');

H8.DecorationTests = function() {
	this.$super.constructor();
};
H8.DecorationTests.$extend(DotWeb.Client.JsScript);

H8.DecorationTests.prototype.TestJsAnonymous = function() {
	var loc3 = {};
	loc3.X = 1;
	loc3.y = 2;
	var loc0 = loc3;
	loc0.X = loc0.y;
	loc0.y = loc0.X;
	var loc6 = [];
	var loc4 = {};
	loc4.X = 0;
	loc4.y = 0;
	loc6[0] = loc4;
	var loc5 = {};
	loc5.X = 1;
	loc5.y = 1;
	loc6[1] = loc5;
	var loc1 = loc6;
	var loc2 = loc1[0];
	System.Console.WriteLine(loc2);
};
