H8.SourceTests.prototype.EnumArray = function() {
	System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Int32[4], [ 1, 2, 3, 4 ]);
	var array = new System.Int32[4];
	var CS$6$0000 = array;
	var CS$7$0001 = 0;
	while(CS$7$0001 < /*(System.Int32)*/CS$6$0000.length) {
		var item = CS$6$0000[CS$7$0001];
		System.Console.WriteLine(item);
		CS$7$0001 = CS$7$0001 + 1;
	}
};
