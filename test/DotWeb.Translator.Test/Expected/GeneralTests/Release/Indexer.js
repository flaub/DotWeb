$Class(null, 'H8', 'IndexerTest');

H8.IndexerTest.prototype.$ctor = function() {
	return this;
};

$Class(null, 'System', 'Console');

//>System.Console.WriteLine$1

//>System.Console.WriteLine$0 

$Class(null, 'H8', 'GeneralTests', { SimpleEvent: null });

H8.GeneralTests.prototype.Indexer = function() {
	var indexer = new H8.IndexerTest().$ctor();
	indexer["Test"] = 1;
	var value = indexer["Test"];
	System.Console.WriteLine$0(value);
};
