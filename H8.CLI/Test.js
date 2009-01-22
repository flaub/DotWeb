H8.SourceTests = {
	HelloWorld: function() {
		console.log("Hello World!");
	}
	, WhileLoop: function() {
		loc0 = 0;
		while(loc0 < 10) {
			console.log(loc0);
			loc0 = loc0 + 1;
		}
	}
	, ForLoop: function() {
		loc0 = 0;
		while(loc0 < 10) {
			console.log(loc0);
			loc0 = loc0 + 1;
		}
	}
	, DoWhileLoop: function() {
		loc0 = 0;
		do {
			console.log(loc0);
			loc0 = loc0 + 1;
		} while(loc0 < 10);
	}
	, WhileBreakLoop: function() {
		loc0 = 0;
		while(loc0 != 10) {
			console.log(loc0);
			loc0 = loc0 + 1;
		}
	}
	, WhileCondBreakLoop: function() {
		loc0 = 0;
		while(loc0 < 9) {
			if (loc0 == 10) {
				return;
			}
			else {
				console.log(loc0);
				loc0 = loc0 + 1;
			}
		}
	}
	, If: function() {
		loc0 = 0;
		if (loc0 == 1) {
			console.log("True");
		}
	}
	, IfElse: function() {
		loc0 = 0;
		if (loc0 == 1) {
			console.log("True");
		}
		else {
			console.log("False");
		}
		console.log("Yep");
	}
	, IfElseIf: function() {
		loc0 = 0;
		if (loc0 == 1) {
			console.log("True");
			return;
		}
		else {
			if (loc0 == 2) {
				console.log("False");
			}
			return;
		}
	}
	, IfIf: function() {
		loc0 = 0;
		if (loc0 == 1) {
			console.log("True");
		}
		if (loc0 == 2) {
			console.log("False");
		}
	}
	, Cifuentes: function() {
		loc0 = 5;
		loc1 = loc0 * 5;
		if (loc0 < loc1) {
			loc0 = loc0 * loc1;
			if ((loc0 * 2) <= loc1) {
				loc1 = loc1 << 3;
			}
			else {
				loc0 = loc0 << 3;
			}
		}
		loc2 = 0;
		while(loc2 < 10) {
			loc3 = loc2;
			do {
				loc3 = loc3 + 1;
				console.log("{0}, {1}", loc2, loc3);
			} while(loc3 < 5);
			loc2 = loc2 + 1;
		}
		if ((loc0 < loc1) || ((loc1 * 2) > loc0)) {
			loc0 = (loc0 + loc1) - 10;
			loc1 = loc1 / 2;
		}
	}
	, EnumArray: function() {
		System.Runtime.CompilerServices.RuntimeHelpers.InitializeArray(new System.Int32[4], [ 1, 2, 3, 4 ]);
		loc0 = new System.Int32[4];
		loc2 = loc0;
		loc3 = 0;
		while(loc3 < loc2.length) {
			loc1 = loc2[loc3];
			console.log(loc1);
			loc3 = loc3 + 1;
		}
	}
	, CreateObject: function() {
		loc0 = new H8.SourceTests.Test("Test1", 1);
		loc2 = new H8.SourceTests.Test();
		loc2.Text = "Test2";
		loc2.Value = 2;
		loc1 = loc2;
		console.log("{0}, {1}", loc0.Text, loc0.Value);
		console.log("{0}, {1}", loc1.Text, loc1.Value);
	}
	, Linq: function() {
		loc0 = "ABCDE99F-J74-12-89A";
		if (!H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2) {
			H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2 = null._Linq_b__1;
		}
		loc1 = System.Linq.Enumerable.Where(loc0, H8.SourceTests.CS$__9__CachedAnonymousMethodDelegate2);
		loc3 = loc1.GetEnumerator();
		while(loc3.MoveNext()) {
			loc2 = loc3.Current;
			console.log(loc2);
		}
	}
	, add_SimpleEvent: function(value /*H8.SourceTests.SimpleDelegate*/) {
		this.SimpleEvent = /*(H8.SourceTests.SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, value);
	}
	, remove_SimpleEvent: function(value /*H8.SourceTests.SimpleDelegate*/) {
		this.SimpleEvent = /*(H8.SourceTests.SimpleDelegate)*/System.Delegate.Remove(this.SimpleEvent, value);
	}
	, TakeParameters: function(str /*System.String*/, value /*System.Int32*/, rad /*System.Double[]*/) {
		console.log(str);
		loc0 = System.Math.Sin(rad[value] * 1.5707963267949);
		return System.Math.Cosh(loc0);
	}
	, Callback: function(del /*H8.SourceTests.SimpleDelegate*/) {
		if (del) {
			del.Invoke();
		}
		if (this.SimpleEvent) {
			this.SimpleEvent.Invoke();
		}
		this.SimpleEvent = /*(H8.SourceTests.SimpleDelegate)*/System.Delegate.Combine(this.SimpleEvent, this.SourceTests_SimpleEvent);
	}
	, SourceTests_SimpleEvent: function() {
		throw new System.NotImplementedException()
	}
	, TryCatch: function() {
		console.log("Try this");
	}
	, Switch: function(val /*System.Int32*/) {
		console.log("Hello");
		loc0 = val;
		switch(loc0 - 1) {
			default:
				console.log("default");
				break;
			case 0:
				console.log("1");
				break;
			case 1:
				console.log("2");
				break;
			case 2:
				console.log("3");
				break;
			case 3:
			case 4:
				console.log("4, 5");
				break;
		}
		console.log("Bye");
	}
	, AnonymousType: function() {
		loc0 = new __f__AnonymousType0$2("Hi", 1);
		console.log("{0}: {1}", loc0.Key.Length, loc0.Value);
	}
	, _Linq_b__1: function(ch /*System.Char*/) {
		return System.Char.IsDigit(ch);
	}
	, init: function() {
		H8.SourceTests.superclass.init.call(this);
	}
};

H8.SourceTests.Test = {
	get_Text: function() {
		return this._Text_k__BackingField;
	}
	, set_Text: function(value /*System.String*/) {
		this._Text_k__BackingField = value;
	}
	, get_Value: function() {
		return this._Value_k__BackingField;
	}
	, set_Value: function(value /*System.Int32*/) {
		this._Value_k__BackingField = value;
	}
	, init: function() {
		H8.SourceTests.Test.superclass.init.call(this);
	}
	, init: function(text /*System.String*/, value /*System.Int32*/) {
		H8.SourceTests.Test.superclass.init.call(this);
		this.Text = text;
		this.Value = value;
	}
};

__f__AnonymousType0$2 = {
	get_Key: function() {
		return this._Key_i__Field;
	}
	, get_Value: function() {
		return this._Value_i__Field;
	}
	, ToString: function() {
		loc0 = new System.Text.StringBuilder();
		return loc0.ToString();
	}
	, Equals: function(value /*System.Object*/) {
		loc0 = value instanceof __f__AnonymousType0$2;
		if ((loc0) && (EqualityComparer$1.Default.Equals(this._Key_i__Field, loc0._Key_i__Field))) {
			return EqualityComparer$1.Default.Equals(this._Value_i__Field, loc0._Value_i__Field);
		}
		return 0;
	}
	, GetHashCode: function() {
		loc0 = -1625202643;
		loc0 = (-1521134295 * loc0) + EqualityComparer$1.Default.GetHashCode(this._Key_i__Field);
		loc0 = (-1521134295 * loc0) + EqualityComparer$1.Default.GetHashCode(this._Value_i__Field);
		return loc0;
	}
	, init: function(Key /*_Key_j__TPar*/, Value /*_Value_j__TPar*/) {
		__f__AnonymousType0$2.superclass.init.call(this);
		this._Key_i__Field = Key;
		this._Value_i__Field = Value;
	}
};

