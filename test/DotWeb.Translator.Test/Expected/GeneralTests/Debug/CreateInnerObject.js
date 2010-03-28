$Class(null, 'H8', 'GeneralTests_InnerClassTest', { _Text_k__BackingField: null, _Value_k__BackingField: 0 });

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
	return this._Text_k__BackingField;
};

$Class(null, 'System', 'Console');

System.Console.WriteLine$1 = function(value) {
	console.log(value);
};

H8.GeneralTests_InnerClassTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

System.Console.WriteLine$0 = function(value) {
	System.Console.WriteLine$1(value.toString());
};

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.CreateInnerObject = function() {
	var test1 = new H8.GeneralTests_InnerClassTest().$ctor$1("Test1", 1);
	var __g__initLocal0 = new H8.GeneralTests_InnerClassTest().$ctor$0();
	__g__initLocal0.set_Text("Test2");
	__g__initLocal0.set_Value(2);
	var test2 = __g__initLocal0;
	System.Console.WriteLine$1(test1.get_Text());
	System.Console.WriteLine$0(test1.get_Value());
	System.Console.WriteLine$1(test2.get_Text());
	System.Console.WriteLine$0(test2.get_Value());
};
