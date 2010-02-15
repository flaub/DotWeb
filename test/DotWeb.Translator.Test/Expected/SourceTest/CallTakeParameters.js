$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(/*System.String*/ value) {
	console.log(value);
};

System.Math = function() {
};

System.Math.Sin = function(/*System.Double*/ a) {
	return Math.sin(a);
};

System.Math.Cos = function(/*System.Double*/ a) {
	return Math.cos(a);
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.TakeParameters = function(/*System.String*/ str, /*System.Int32*/ value, /*System.Double[]*/ rad) {
	System.Console.WriteLine(str);
	var x = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(x);
};

System.Console.WriteLine = function(/*System.Object*/ value) {
	console.log(value);
};

H8.SourceTests.prototype.CallTakeParameters = function() {
	var CS$0$0000 = new /*System.Double*/Array(2);
	CS$0$0000[0] = 1;
	CS$0$0000[1] = 2;
	var result = this.TakeParameters("Hi", 1, CS$0$0000);
	System.Console.WriteLine(result);
};
