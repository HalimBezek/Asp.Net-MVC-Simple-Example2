/*
 *
 *		STYLE-SWITHER.JS
 *
 */

$(document).ready(function() {
    
	var style_switch_content = ' \
		<h4>Theme Options Panel</h4> \
		<a href="#"></a> \
		<br> \
		<h5>Change Color</h5> \
		<div class="colors clearfix"> \
			<a id="default" href="#" data-style="default"></a> \
			<a id="color1" href="#" data-style="color1"></a> \
			<a id="color2" href="#" data-style="color2"></a> \
		</div><!-- colors --> \
	\ ';
	
	$("#style-switcher").prepend(style_switch_content);
	
	$("#style-switcher > a").on("click", function(e) {
        
		e.preventDefault();
		$("#style-switcher").toggleClass("open");
		
    });
	
	
	var link = $('link[data-style="styles"]');
	var colors = $.cookie('colors-bergen');
		
	if (!($.cookie('colors-bergen'))) {
		
		$.cookie('colors-bergen', 'default', 365);
		colors = $.cookie('colors-bergensss');
		$('#style-switcher .colors a[data-style="'+colors+'"]');
		
	} else {
		
		link.attr('href','assets/css/alternative-styles/' + colors + '.css');
		$('#style-switcher .colors a[data-style="'+colors+'"]');
		
	};
	
	// CHANGE COLOR //
	$("#style-switcher .colors a").on("click",function(e) {
		
		var $this = $(this),
			colors = $this.data('style');
			
		e.preventDefault();
		
		link.attr('href', 'assets/css/alternative-styles/' + colors + '.css');
		$.cookie('colors-bergen', colors, 365);
				
	});

});    	