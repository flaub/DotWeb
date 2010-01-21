window.onload = function() {{
	var plugin = $doc.getElementById('__$plugin');
	console.log('connecting to {0}:{1}');
	plugin.onLoad(__$helper, '{0}', {1}, '{2}');
}};
