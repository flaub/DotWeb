$Namespace('H8');

H8.OuterClassTest = function() {
};

H8.OuterClassTest.prototype.set_Text = function(value /*System.String*/) {
	this._Text_k__BackingField = value;
};

H8.OuterClassTest.prototype.set_Value = function(value /*System.Int32*/) {
	this.m_value = value;
};

H8.OuterClassTest.prototype.$ctor = function(text /*System.String*/, value /*System.Int32*/) {
	this.set_Text(text);
	this.set_Value(value);
	return this;
};

H8.OuterClassTest.prototype.$ctor = function() {
	return this;
};

H8.OuterClassTest.prototype.get_Text = function() {
	return this._Text_k__BackingField;
};

H8.OuterClassTest.prototype.get_Value = function() {
	return this.m_value;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(format /*System.String*/, arg0 /*System.Object*/, arg1 /*System.Object*/) {
	// nop
};

H8.SourceTests = function() {
};

H8.SourceTests.prototype.CreateOuterObject = function() {
	var loc0 = new H8.OuterClassTest().$ctor("Test1", 1);
	var loc2 = new H8.OuterClassTest().$ctor();
	loc2.set_Text("Test2");
	loc2.set_Value(2);
	var loc1 = loc2;
	System.Console.WriteLine("{0}, {1}", loc0.get_Text(), loc0.get_Value());
	System.Console.WriteLine("{0}, {1}", loc1.get_Text(), loc1.get_Value());
};
