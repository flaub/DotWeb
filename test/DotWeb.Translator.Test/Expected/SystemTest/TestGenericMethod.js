$Class(null, 'System.Collections.Generic', 'List$1');

System.Collections.Generic.List$1.prototype.$ctor$0 = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.Add$0 = function(item) {
	this.items.push(item);
};

System.Collections.Generic.List$1.prototype.IndexOf$0 = function(item) {
	var V_0 = this.items.indexOf(item);
	return V_0;
};

System.Collections.Generic.List$1.prototype.toString = function() {
	var V_0 = "[ " + this.items.toString() + " ]";
	return V_0;
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
