$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.TakeParameters = function(str, value, rad, flag) {
	System.Console.WriteLine$1(str);
	var x = Math.sin(rad[value] * 1.570795);
	return Math.cos(x);
};

//>System.Console.WriteLine$0 

H8.GeneralTests.prototype.CallTakeParameters = function() {
	var CS$0$0000 = $Array(2, 0);
	CS$0$0000[0] = 1;
	CS$0$0000[1] = 2;
	var result = this.TakeParameters("Hi", 1, CS$0$0000, true);
	System.Console.WriteLine$0(result);
};
