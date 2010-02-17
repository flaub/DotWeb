H8.SourceTests.prototype.TakeParameters = function(str, value, rad) {
	System.Console.WriteLine(str);
	var x = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(x);
};
