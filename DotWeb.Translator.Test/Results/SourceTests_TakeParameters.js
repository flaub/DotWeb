H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
	console.log(str);
	var loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
	return System.Math.Cosh(loc0);
};

