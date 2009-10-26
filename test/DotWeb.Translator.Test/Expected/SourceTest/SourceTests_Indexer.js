$Namespace('H8');

H8.IndexerTest = function() {
};

H8.IndexerTest.prototype.$ctor = function() {
	return this;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine = function(value /*System.Object*/) {
	console.log(value);
};

H8.SourceTests = function() {
};

H8.SourceTests.prototype.Indexer = function() {
	var loc0 = new H8.IndexerTest().$ctor();
	loc0["Test"] = 1;
	var loc1 = loc0["Test"];
	System.Console.WriteLine(loc1);
};
