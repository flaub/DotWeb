$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.TakeParameters = function(str, value, rad, flag) {
	System.Console.WriteLine$1(str);
	var x = Math.sin(rad[value] * 1.570795);
	return Math.cos(x);
};

System.Console.WriteLine$0 = function(value) {
	console.log(value);
};

H8.GeneralTests.prototype.CallTakeParameters = function() {
	var CS$0$0000 = new Array(2);
	CS$0$0000[0] = 1;
	CS$0$0000[1] = 2;
	var result = this.TakeParameters("Hi", 1, CS$0$0000, true);
	System.Console.WriteLine$0(result);
};
