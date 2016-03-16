window.onload = function() {
	function setWidth() {
		var leftBox = document.getElementById('left-box');
		var h = document.getElementById('right-box').offsetHeight - 25;
		leftBox.style.height = h + 'px';
	}
	setWidth();
	window.onresize = function() {
		setWidth();
	}
}