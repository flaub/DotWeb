H8.SourceTests.prototype.Linq = function() {
	var loc0 = "ABCDE99F-J74-12-89A";
	if (!H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2) {
		H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2 = H8.SourceTests._Linq_b__1;
	}
	var loc1 = System.Linq.Enumerable.Where(loc0, H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2);
	var loc3 = loc1.GetEnumerator();
	while(loc3.MoveNext()) {
		var loc2 = loc3.Current;
		console.log(loc2);
	}
};

