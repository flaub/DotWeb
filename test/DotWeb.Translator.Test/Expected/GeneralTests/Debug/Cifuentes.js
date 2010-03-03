H8.GeneralTests.prototype.Cifuentes = function() {
	var x = 5;
	var y = x * 5;
	var CS$4$0000 = x >= y;
	if (!CS$4$0000) {
		x = x * y;
		CS$4$0000 = (x * 2) > y;
		if (!CS$4$0000) {
			y = y << 3;
		}
		else {
			x = x << 3;
		}
	}
	var a = 0;
	while (true) {
		CS$4$0000 = a < 10;
		if (!CS$4$0000) {
			break;
		}
		var b = a;
		do {
			b = b + 1;
			System.Console.WriteLine$3("{0}, {1}", a, b);
			CS$4$0000 = b < 5;
		} while (CS$4$0000);
		a = a + 1;
	}
	if (x >= y) {
		var R_1 = (y * 2) <= x;
	}
	else {
		R_1 = 0;
	}
	CS$4$0000 = R_1;
	if (!CS$4$0000) {
		x = (x + y) - 10;
		y = y / 2;
	}
};
