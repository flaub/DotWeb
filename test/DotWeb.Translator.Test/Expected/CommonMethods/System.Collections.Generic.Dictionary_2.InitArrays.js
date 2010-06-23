System.Collections.Generic.Dictionary$2.prototype.InitArrays = function(size) {
	this.table = $Array(size, 0);
	this.linkSlots = $Array(size, null);
	this.emptySlot = -1;
	this.keySlots = $Array(size, null);
	this.valueSlots = $Array(size, null);
	this.touchedSlots = 0;
	this.threshold = Math.floor(this.table.length * 0.9);
	if (!this.threshold) {
		var R_1 = this.table.length <= 0;
	}
	else {
		R_1 = 1;
	}
	var CS$4$0000 = R_1;
	if (!CS$4$0000) {
		this.threshold = 1;
	}
};
