$Namespace('GitHub_Issue5');

GitHub_Issue5.Class1 = function() {
};

GitHub_Issue5.Class1._$ctor_b__0 = function() {
	$wnd.alert("test");
};

GitHub_Issue5.Class1.prototype.Call = function(action) {
	action();
};

GitHub_Issue5.Class1.prototype.$ctor = function() {
	var R_1 = this;
	if (!GitHub_Issue5.Class1.CS$__9__CachedAnonymousMethodDelegate1) {
		GitHub_Issue5.Class1.CS$__9__CachedAnonymousMethodDelegate1 = $Delegate(GitHub_Issue5.Class1, GitHub_Issue5.Class1._$ctor_b__0);
	}
	R_1.Call(GitHub_Issue5.Class1.CS$__9__CachedAnonymousMethodDelegate1);
	return this;
};

$Namespace('H8');

H8.SourceTests = function() {
};

H8.SourceTests.prototype.GitHub_Issue5 = function() {
	new GitHub_Issue5.Class1().$ctor();
};
