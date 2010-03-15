$Class(null, 'System.Collections.Generic', 'List$1', { items: null });

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.Add$0 = function(item) {
	this.items.push(item);
};

System.Collections.Generic.List$1.prototype.IndexOf$0 = function(item) {
	return this.items.indexOf(item);
};

System.Collections.Generic.List$1.prototype.toString = function() {
	return "[ " + this.items.toString() + " ]";
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$0 = function(value) {
	console.log(value);
};

$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.AreEqual = function(name, expected, actual) {
	expected.toString();
	var equal = (expected == actual);
	System.Console.WriteLine$0(equal);
};

H8.SystemTests.prototype.TestGenericMethod = function() {
	var list = new System.Collections.Generic.List$1().$ctor$0();
	list.Add$0("one");
	this.AreEqual("IndexOf", 0, list.IndexOf$0("one"));
};
