window.onload = function() {
	function setWidth() {
	    var h = $("#left-box").height()+25;
	    $("#right-box").height(h-12);
		$("#mainFrame").height(h-103);
	}
	setWidth();
	window.onresize = function() {
		setWidth();
	}
}