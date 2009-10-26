$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value /*System.String*/) {
	console.log(value);
};

System.Math = function() {
};

System.Math.Sin = function(a /*System.Double*/) {
	return Math.sin(a);
};

System.Math.Cos = function(a /*System.Double*/) {
	return Math.cos(a);
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
	System.Console.WriteLine(str);
	var loc0 = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(loc0);
};

System.Console.WriteLine = function(value /*System.Object*/) {
	console.log(value);
};

H8.SourceTests.prototype.CallTakeParameters = function() {
	var loc1 = new System.Double[2];
	loc1[0] = 1;
	loc1[1] = 2;
	var loc0 = this.TakeParameters("Hi", 1, loc1);
	System.Console.WriteLine(loc0);
};
