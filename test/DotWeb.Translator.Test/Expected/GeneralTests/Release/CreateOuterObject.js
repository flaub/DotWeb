$Class(null, 'H8', 'OuterClassTest', { m_value: 0, _Text_k__BackingField: null });

H8.OuterClassTest.prototype.set_Text = function(value) {
	this._Text_k__BackingField = value;
};

H8.OuterClassTest.prototype.set_Value = function(value) {
	this.m_value = value;
};

H8.OuterClassTest.prototype.$ctor$1 = function(text, value) {
	this.set_Text(text);
	this.set_Value(value);
	return this;
};

H8.OuterClassTest.prototype.$ctor$0 = function() {
	return this;
};

H8.OuterClassTest.prototype.get_Text = function() {
	return this._Text_k__BackingField;
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

H8.OuterClassTest.prototype.get_Value = function() {
	return this.m_value;
};

//>System.Console.WriteLine$0 

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.CreateOuterObject = function() {
	var test1 = new H8.OuterClassTest().$ctor$1("Test1", 1);
	var __g__initLocal1 = new H8.OuterClassTest().$ctor$0();
	__g__initLocal1.set_Text("Test2");
	__g__initLocal1.set_Value(2);
	var test2 = __g__initLocal1;
	System.Console.WriteLine$1(test1.get_Text());
	System.Console.WriteLine$0(test1.get_Value());
	System.Console.WriteLine$1(test2.get_Text());
	System.Console.WriteLine$0(test2.get_Value());
};
