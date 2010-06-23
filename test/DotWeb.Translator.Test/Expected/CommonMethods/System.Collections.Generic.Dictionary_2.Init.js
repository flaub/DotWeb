System.Collections.Generic.Dictionary$2.prototype.Init = function(capacity, hcp) {
	var CS$4$0000 = capacity >= 0;
	if (!CS$4$0000) {
		throw new System.ArgumentOutOfRangeException().$ctor$1("capacity");
	}
	var R_1 = this;
	if (!hcp) {
		var R_2 = System.Collections.Generic.EqualityComparer$1.get_Default();
	}
	else {
		R_2 = hcp;
	}
	R_1.hcp = R_2;
	CS$4$0000 = capacity != 0;
	if (!CS$4$0000) {
		capacity = 10;
	}
	capacity = Math.floor(capacity / 0.9) + 1;
	this.InitArrays(capacity);
	this.generation = 0;
};
