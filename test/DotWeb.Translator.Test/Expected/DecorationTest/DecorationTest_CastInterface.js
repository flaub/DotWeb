$Namespace('DotWeb.Client');

DotWeb.Client.JsScript = function() {
};

DotWeb.Client.JsScript.prototype.get_Window = function() {
	return $wnd;
};

$Namespace('H8');

H8.DecorationTests = function() {
	this.$super.constructor();
};
H8.DecorationTests.$extend(DotWeb.Client.JsScript);

H8.DecorationTests.prototype.box_OnMouseOver = function(evt /*DotWeb.Client.Dom.Events.MouseEvent*/) {
};

H8.DecorationTests.prototype.TestCastInterface = function() {
	var element = this.get_Window().document.getElementById("box");
	var box = /*(DotWeb.Client.Dom.Html.HtmlDivElement)*/element;
	box.onmouseover = $Delegate(this, this.box_OnMouseOver);
};
