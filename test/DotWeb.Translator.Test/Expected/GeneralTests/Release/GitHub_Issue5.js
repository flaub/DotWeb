$Class(null, 'GitHub_Issue5', 'Class1');

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

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.GitHub_Issue5 = function() {
	new GitHub_Issue5.Class1().$ctor();
};
