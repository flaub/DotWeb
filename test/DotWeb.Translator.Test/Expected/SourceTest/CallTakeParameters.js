$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value) {
	console.log(value);
};

System.Math = function() {
};

System.Math.Sin = function(a) {
	return Math.sin(a);
};

System.Math.Cos = function(a) {
	return Math.cos(a);
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.TakeParameters = function(str, value, rad) {
	System.Console.WriteLine(str);
	var x = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(x);
};

System.Console.WriteLine = function(value) {
	console.log(value);
};

H8.SourceTests.prototype.CallTakeParameters = function() {
	var CS$0$0000 = new Array(2);
	CS$0$0000[0] = 1;
	CS$0$0000[1] = 2;
	var result = this.TakeParameters("Hi", 1, CS$0$0000);
	System.Console.WriteLine(result);
};
