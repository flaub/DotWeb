$Namespace('H8');

H8.SourceTests_InnerClassTest = function() {
};

H8.SourceTests_InnerClassTest.prototype.set_Text = function(value /*System.String*/) {
	this._Text_k__BackingField = value;
};

H8.SourceTests_InnerClassTest.prototype.set_Value = function(value /*System.Int32*/) {
	this._Value_k__BackingField = value;
};

H8.SourceTests_InnerClassTest.prototype.$ctor = function(text /*System.String*/, value /*System.Int32*/) {
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

System.Console.WriteLine = function(format /*System.String*/, arg0 /*System.Object*/, arg1 /*System.Object*/) {
	console.log(format);
};

H8.SourceTests = function() {
};

H8.SourceTests.prototype.CreateInnerObject = function() {
	var loc0 = new H8.SourceTests_InnerClassTest().$ctor("Test1", 1);
	var loc2 = new H8.SourceTests_InnerClassTest().$ctor();
	loc2.set_Text("Test2");
	loc2.set_Value(2);
	var loc1 = loc2;
	System.Console.WriteLine("{0}, {1}", loc0.get_Text(), loc0.get_Value());
	System.Console.WriteLine("{0}, {1}", loc1.get_Text(), loc1.get_Value());
};
