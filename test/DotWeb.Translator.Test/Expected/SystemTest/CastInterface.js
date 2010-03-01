$Class(null, 'H8', 'SystemTests');

H8.SystemTests.prototype.box_OnMouseOver = function(evt) {
};

H8.SystemTests.prototype.CastInterface = function() {
	var element = $doc.getElementById("box");
	var box = element;
	box.onmouseover = $Delegate(this, this.box_OnMouseOver);
};
