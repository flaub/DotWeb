H8.GeneralTests.prototype.Cifuentes = function() {
	var x = 5;
	var y = x * 5;
	if (x < y) {
		x = x * y;
		if ((x * 2) <= y) {
			y = y << 3;
		}
		else {
			x = x << 3;
		}
	}
	var a = 0;
	while (a < 10) {
		var b = a;
		do {
			b = b + 1;
			System.Console.WriteLine$3("{0}, {1}", a, b);
		} while (b < 5);
		a = a + 1;
	}
	if ((x < y) || ((y * 2) > x)) {
		x = (x + y) - 10;
		y = y / 2;
	}
};
