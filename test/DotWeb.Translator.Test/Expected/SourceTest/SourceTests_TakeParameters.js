H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
	System.Console.WriteLine(str);
	var loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
	return System.Math.Cosh(loc0);
};

