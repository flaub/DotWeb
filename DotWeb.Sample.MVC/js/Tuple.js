function Tuple(config) {
	console.log(config);
	for(var key in config){
		this[key] = config[key];
	}
};

Tuple.prototype.fireEvent = function() { console.log('firing'); this.handler(this, this.id); }
Tuple.StaticMethod = function(x, y) { console.log(x * y); };
Tuple.Sum = function(args) {
	var ret = 0;
	for(var i = 0, len = args.length; i < len; i++) {
		var arg = args[i];
		console.log(typeof(arg));
		console.log(arg);
		ret = ret + arg;
	}
	return ret;
};
Tuple.Factory = function() {
	return new Tuple({
		id: 59,
		value: 'hi'
	});
};
Tuple.Callback1 = function(cb) { cb('a', 1, 1.1); };
Tuple.Callback2 = function(cb) { cb(1.1, 'a', 1); };
