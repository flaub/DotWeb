$Namespace('System.Collections.Generic');

System.Collections.Generic.List$1 = function() {
};

System.Collections.Generic.List$1.prototype.$ctor = function() {
	this.items = new Array();
	return this;
};

System.Collections.Generic.List$1.prototype.Add = function(/*T*/ item) {
	this.items.push(item);
};

$Namespace('H8');

H8.SystemTests = function() {
};

H8.SystemTests.prototype.TestList = function() {
	var list = new System.Collections.Generic.List$1().$ctor();
	list.Add("one");
};
