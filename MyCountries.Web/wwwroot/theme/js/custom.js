/* ************************************** */
/* Way Point JS  */
/* ************************************** */

$(document).ready(function(){
	
	// Boxes Animation
	$('.box').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInUp');
	}, { offset: '100%' });
	
	// Counter For Services Box
	$('.s-counter').waypoint(function(down){
		if(!$(this).hasClass('stop-counter'))
		{
			$(this).countTo();
			$(this).addClass('stop-counter');
		}
	}, { 
		offset: '100%' 
	});
	
	// Inner Page Sidebar Links Animation
	$('.sidebar-link ul a').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInLeft');
	}, { offset: '100%' });
	
	// Inner Page Pricing Animation
	$('.feature .feature-details').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeIn');
	}, { offset: '80%' });
	
	// Inner Page Services Animation
	$('.service .service-item').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('bounceInUp');
	}, { offset: '80%' });
	
	// Inner Page Pricing Animation
	$('.pricing .p-plan-item').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('flipInY');
	}, { offset: '80%' });
	
	// Inner Page Pricing Animation
	$('.testimonial .testimonial-item').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInRight');
	}, { offset: '80%' });
		
	// Inner Page Blog Animation
	$('.blog-post .entry').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeIn');
	}, { offset: '80%' });
		
	// Inner Page Landing Animation
	$('.landing .landing-item').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInUp');
	}, { offset: '100%' });
		
	// Inner Page Resume Animation
	$('.resume .resume-details').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInRight');
	}, { offset: '90%' });
	
	// Grid Item Way Points
	$('.grid .grid-entry').waypoint(function(down){
		$(this).addClass('animation');
		$(this).addClass('fadeInUp');
	}, { 
		offset: '90%' 
	});
	
});

/* *************************************** */ 
/* PrettyPhoto for Grid Image */
/* *************************************** */  

	$(".grid-img-link").prettyPhoto({
	   overlay_gallery: false, social_tools: false
	});
	
/* *************************************** */ 
/* Progress Bar [ Inner Page About Us ] JS */
/* *************************************** */  

$('.aboutus-skill .progress-bar').waypoint(function(down) {
	
	if(!$(this).hasClass('progress-stop')){
		
		setTimeout(function(){

			$('.aboutus-skill .progress-bar').each(function() {
				var me = $(this);
				var perc = me.attr("data-end");
				var current_perc = 0;
				var progress = setInterval(function() {

					if (current_perc>=perc) {
						clearInterval(progress);
					} else {
						current_perc +=2;
						me.css('width', (current_perc)+'%');
					}
					
				}, 40);

			});

		},40);  
		
		$(this).addClass('progress-stop');
	}
	
},{ offset: '100%' });

/* ************************************** */
/* Tool Tip JS  */
/* ************************************** */

$('.my-tooltip').tooltip();

/* *************************************** */  
/* JS for Portfolio Image Caption */
/* *************************************** */  

$(document).ready(function(){
	$(".slide-up").hover(function(){
		$(this).children(".movetoup").slideDown(500); 
		}, function(){
		$(this).children(".movetoup").slideUp(500);
	});
		
	$(".slide-down").hover(function(){
		$(this).children(".movetodown").slideDown(500); 
		}, function(){
		$(this).children(".movetodown").slideUp(500);
	});
 });
 
/* *************************************** */ 
/* Scroll to Top */
/* *************************************** */  
		
$(document).ready(function() {
	$(".totop").hide();
	
	$(window).scroll(function(){
	if ($(this).scrollTop() > 300) {
		$('.totop').fadeIn();
	} else {
		$('.totop').fadeOut();
	}
	});
	$(".totop a").click(function(e) {
		e.preventDefault();
		$("html, body").animate({ scrollTop: 0 }, "slow");
		return false;
	});
		
});
/* *************************************** */