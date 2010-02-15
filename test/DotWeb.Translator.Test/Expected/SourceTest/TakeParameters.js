H8.SourceTests.prototype.TakeParameters = function(/*System.String*/ str, /*System.Int32*/ value, /*System.Double[]*/ rad) {
	System.Console.WriteLine(str);
	var x = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(x);
};
