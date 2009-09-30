H8.SourceTests.prototype.EnumArray = function() {
	System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Int32[4], [ 1, 2, 3, 4 ]);
	var loc0 = new System.Int32[4];
	var loc2 = loc0;
	var loc3 = 0;
	while(loc3 < loc2.length) {
		var loc1 = loc2[loc3];
		System.Console.WriteLine(loc1);
		loc3 = loc3 + 1;
	}
};

