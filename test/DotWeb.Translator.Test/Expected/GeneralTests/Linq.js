$Namespace('H8');

H8.GeneralTests = function() {
};

H8.GeneralTests._Linq_b__2 = function(ch /*System.Char*/) {
	return System.Char.IsDigit(ch);
};

H8.GeneralTests.prototype.Linq = function() {
	var loc0 = "ABCDE99F-J74-12-89A";
	if (!H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate3) {
		H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate3 = $Delegate(H8.GeneralTests, H8.GeneralTests._Linq_b__2);
	}
	var loc1 = System.Linq.Enumerable.Where(loc0, H8.GeneralTests.CS$__9__CachedAnonymousMethodDelegate3);
	var loc3 = loc1.GetEnumerator();
	while(loc3.MoveNext()) {
		var loc2 = loc3.get_Current();
		System.Console.WriteLine(loc2);
	}
};

