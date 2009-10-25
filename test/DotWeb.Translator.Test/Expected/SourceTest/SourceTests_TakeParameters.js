H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
	System.Console.WriteLine(str);
	var loc0 = System.Math.Sin(rad[value] * 1.570795);
	return System.Math.Cos(loc0);
};
