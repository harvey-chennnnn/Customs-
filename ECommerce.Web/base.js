window.onload = function() {
	function setWidth() {
	    var rightBox = document.getElementById('right-box');
		var h = document.getElementById('left-box').offsetHeight - 24;
		rightBox.style.height = h + 'px';
		$("#mainFrame").height(h-103);
	}
	setWidth();
	window.onresize = function() {
		setWidth();
	}
}