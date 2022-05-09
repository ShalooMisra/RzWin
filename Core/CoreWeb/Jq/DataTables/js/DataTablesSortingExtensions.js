jQuery.fn.dataTableExt.oSort['numeric-commaignore-asc']  = function(a,b) {
	var x = (a == "-") ? 0 : a.replace( /,/, "" );
	var y = (b == "-") ? 0 : b.replace( /,/, "" );
	x = parseFloat( x );
	y = parseFloat( y );
	return ((x < y) ? -1 : ((x > y) ?  1 : 0));
};

jQuery.fn.dataTableExt.oSort['numeric-commaignore-desc'] = function(a,b) {
	var x = (a == "-") ? 0 : a.replace( /,/, "" );
	var y = (b == "-") ? 0 : b.replace( /,/, "" );
	x = parseFloat( x );
	y = parseFloat( y );
	return ((x < y) ?  1 : ((x > y) ? -1 : 0));
};