if(typeof(H8) == 'undefined') H8 = {};

H8.SourceTests = function() {
};

H8.SourceTests.prototype.TakeParameters = function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
	console.log(str);
	var loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
	return System.Math.Cosh(loc0);
};

H8.SourceTests.prototype.CallTakeParameters = function() {
	var loc1 = new System.Double[2];
	loc1[0] = 1;
	loc1[1] = 2;
	var loc0 = this.TakeParameters("Hi", 1, loc1);
	console.log(loc0);
};
