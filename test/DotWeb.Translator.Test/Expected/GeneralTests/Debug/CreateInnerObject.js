$Class(null, 'H8', 'GeneralTests_InnerClassTest');

H8.GeneralTests_InnerClassTest.prototype.set_Text = function(value) {
	this._Text_k__BackingField = value;
};

H8.GeneralTests_InnerClassTest.prototype.set_Value = function(value) {
	this._Value_k__BackingField = value;
};

H8.GeneralTests_InnerClassTest.prototype.$ctor$1 = function(text, value) {
	this.set_Text(text);
	this.set_Value(value);
	return this;
};

H8.GeneralTests_InnerClassTest.prototype.$ctor$0 = function() {
	return this;
};

H8.GeneralTests_InnerClassTest.prototype.get_Text = function() {
	var V_0 = this._Text_k__BackingField;
	return V_0;
};

H8.GeneralTests_InnerClassTest.prototype.get_Value = function() {
	var V_0 = this._Value_k__BackingField;
	return V_0;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$3 = function(format, arg0, arg1) {
	console.log(format);
};

$Class(null, 'H8', 'GeneralTests');

H8.GeneralTests.prototype.CreateInnerObject = function() {
	var test1 = new H8.GeneralTests_InnerClassTest().$ctor$1("Test1", 1);
	var __g__initLocal0 = new H8.GeneralTests_InnerClassTest().$ctor$0();
	__g__initLocal0.set_Text("Test2");
	__g__initLocal0.set_Value(2);
	var test2 = __g__initLocal0;
	System.Console.WriteLine$3("{0}, {1}", test1.get_Text(), test1.get_Value());
	System.Console.WriteLine$3("{0}, {1}", test2.get_Text(), test2.get_Value());
};
