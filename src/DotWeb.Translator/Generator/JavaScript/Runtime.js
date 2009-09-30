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

function $(id) {
    return document.getElementById(id);
}

Object.prototype.$extend = function(superclass) {
	var tmp = function() {};
	tmp.prototype = superclass.prototype;
	this.prototype = new tmp();
	this.prototype.constructor = this;
	this.prototype.$super = tmp.prototype;
};

$Delegate = function(scope, target) {
	return function() {
		return target.apply(scope, arguments);
	};
};

$Namespace = function(name) {
	if (!$wnd.__namespaces) {
		$wnd.__namespaces = {};
	}

	if ($wnd.__namespaces[name]) {
		return;
	}

	var parent = $wnd;
	var parts = name.split('.');

	for (var i = 0; i < parts.length; i++) {
		var part = parts[i];
		var child = parent[part];
		if(!child) {
			parent[part] = child = {};
		}
		parent = child;
	}
	
	$wnd.__namespaces[name] = child;
}
