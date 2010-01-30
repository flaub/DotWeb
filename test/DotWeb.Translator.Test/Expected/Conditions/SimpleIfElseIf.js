Conditions.prototype.SimpleIfElseIf = function() {
	var i = 0;
	if (i == 1) {
		System.Console.WriteLine("True");
	}
	else {
		if (i == 2) {
			System.Console.WriteLine("False");
		}
	}
	System.Console.WriteLine(i);
};
