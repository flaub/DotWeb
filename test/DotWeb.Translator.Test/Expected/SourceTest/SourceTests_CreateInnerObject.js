$Namespace('H8');

H8.SourceTests_InnerClassTest = function() {
};

H8.SourceTests_InnerClassTest.prototype.set_Text = function(/*System.String*/ value) {
	this._Text_k__BackingField = value;
};

H8.SourceTests_InnerClassTest.prototype.set_Value = function(/*System.Int32*/ value) {
	this._Value_k__BackingField = value;
};

H8.SourceTests_InnerClassTest.prototype.$ctor = function(/*System.String*/ text, /*System.Int32*/ value) {
	this.set_Text(text);
	this.set_Value(value);
	return this;
};

H8.SourceTests_InnerClassTest.prototype.$ctor = function() {
	return this;
};

H8.SourceTests_InnerClassTest.prototype.get_Text = function() {
	return this._Text_k__BackingField;
};

H8.SourceTests_InnerClassTest.prototype.get_Value = function() {
	return this._Value_k__BackingField;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(/*System.String*/ format, /*System.Object*/ arg0, /*System.Object*/ arg1) {
	console.log(format);
};

H8.SourceTests = function() {
};

H8.SourceTests.prototype.CreateInnerObject = function() {
	var test1 = new H8.SourceTests_InnerClassTest().$ctor("Test1", 1);
	var __g__initLocal0 = new H8.SourceTests_InnerClassTest().$ctor();
	__g__initLocal0.set_Text("Test2");
	__g__initLocal0.set_Value(2);
	var test2 = __g__initLocal0;
	System.Console.WriteLine("{0}, {1}", test1.get_Text(), test1.get_Value());
	System.Console.WriteLine("{0}, {1}", test2.get_Text(), test2.get_Value());
};
