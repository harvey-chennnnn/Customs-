window.onload = function() {
	function setWidth() {
		var box = document.getElementById('right-box');
		var leftBox = document.getElementById('left-box');
		var h = document.getElementById('right-box').offsetHeight - 25;
		var w = document.documentElement.clientWidth - 203 - 12 * 2 - 39;
		leftBox.style.height = h + 'px';
		box.style.width = w + 'px';
	}
	setWidth();
	window.onresize = function() {
		setWidth();
	}
}