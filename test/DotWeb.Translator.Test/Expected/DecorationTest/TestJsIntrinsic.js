$Class(null, 'H8', 'IntrinsicClass');

H8.IntrinsicClass.prototype.$ctor = function() {
	return this;
};

$Class(null, 'System', 'Console');

System.Console.Write = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'DecorationTests');

H8.DecorationTests.prototype.TestJsIntrinsic = function() {
	var __g__initLocal3 = new H8.IntrinsicClass().$ctor();
	__g__initLocal3.Value = 1;
	var item = __g__initLocal3;
	System.Console.Write(item.Value);
};
