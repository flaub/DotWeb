$Namespace('H8');

H8.IndexerTest = function() {
};

H8.IndexerTest.prototype.$ctor = function() {
	return this;
};

$Namespace('System');

System.Console = function() {
};

System.Console.WriteLine$0 = function(value) {
	console.log(value);
};

H8.GeneralTests = function() {
};

H8.GeneralTests.prototype.Indexer = function() {
	var indexer = new H8.IndexerTest().$ctor();
	indexer["Test"] = 1;
	var value = indexer["Test"];
	System.Console.WriteLine$0(value);
};
