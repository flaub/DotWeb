H8.SourceTests.prototype.Switch = function(val /*System.Int32*/) {
	console.log("Hello");
	var loc0 = val;
	switch(loc0 - 1) {
		default:
			console.log("default");
			break;
		case 0:
			console.log("1");
			break;
		case 1:
			console.log("2");
			break;
		case 2:
			console.log("3");
			break;
		case 3:
		case 4:
			console.log("4, 5");
			break;
	}
	console.log("Bye");
};

