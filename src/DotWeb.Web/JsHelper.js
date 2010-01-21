// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

$wnd = window;
$doc = $wnd.document;

JsHelper = function() {
	this.functions = {};
}

JsHelper.prototype.getWindow = function() { return $wnd; }
JsHelper.prototype.createObject = function() { return {}; }
JsHelper.prototype.createArray = function() { return []; }
JsHelper.prototype.createArgs = function() { return arguments; }

JsHelper.prototype.defineFunction = function(name, args, body) {
	var str = 'function (' + args + ') { ' + body + ' }';
	//debug.log(name + ' = ' + str);
	var def = eval('(' + str + ')');
	this.functions[name] = def;
}

JsHelper.prototype.invokeFunction = function(name, scope) {
	try {
		var def = this.functions[name];
		var args = Array.prototype.slice.call(arguments, 2);
		//debug.log(name + '(' + scope + ', ' + args + ')');
		var ret = def.apply(scope, args);
		return [false, ret];
	} 
	catch(e) {
		//debug.log('exception: ' + e);
		return [true, e];
	}
}

JsHelper.prototype.invokeDelegate = function(f_) {
	try {
		var args = Array.prototype.slice.call(arguments, 1);
		alert(args);
		var ret = f_.apply(args);
		return [false, ret];
	} 
	catch(e) {
		//debug.log('exception: ' + e);
		return [true, e];
	}
}

JsHelper.prototype.wrapDelegate = function(f_) {
	return function() { return f_(arguments); };
}

__$helper = new JsHelper();
