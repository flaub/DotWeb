﻿H8.SourceTests.prototype.WhileCondBreakLoop = function() {
	var loc0 = 0;
	while(loc0 < 9) {
		if (loc0 == 10) {
			return;
		}
		else {
			System.Console.WriteLine(loc0);
			loc0 = loc0 + 1;
		}
	}
};

