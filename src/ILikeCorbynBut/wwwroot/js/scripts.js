$(document).ready(function() {
	if($(window).width() >= 1024)
		{
		$(".share-controls").css({
				position:"fixed", 
				bottom: "20px",   
				right: "20px",
				zIndex: 0
			}).removeClass('display-inline');
		}
	$(window).resize(function()
		{		
		if($(window).width() < 1024)
			{
			$(".share-controls").css({
					position: "static"
				}).addClass('display-inline');
			$(".table-of-contents").css("left", 10 - $(".table-of-contents").width() + "px");
			}
		else
			{
			$(".share-controls").css({
					position:"fixed", 
					bottom: "20px",   
					right: "20px",
					zIndex: 0
				}).removeClass('display-inline');
			}
		});
	faq.forEach(function(entry, index) {
		generateEntry(entry, index);
	});
	var followScroll = true;
	$(".toc-entry").click(function() {
		var index = this.id.match(/toc-entry-(.*)/);
		if (index) {
			$('html, body').animate({
				scrollTop: $("#entry-" + index[1]).offset().top - 20
			}, 500);
		} else if (this.id == "top") {
			$('html, body').animate({
				scrollTop: $("html").offset().top
			}, 500);
		}
		$(".toc-entry.selected").removeClass("selected");
		$(this).addClass("selected");

		if (index) {
			window.location.hash = $(this).data("question") + "?";
		} else {
			window.location.hash = "";
		}
	});
	$(document).scroll(function() {
		if (followScroll) {
			for (var i = 0; i < faq.length; i++) {
				if ($(this).scrollTop() >= $("#entry-" + i).position().top + $("#entry-" + i - 1 + " .question").height() - 70) {
					$(".toc-entry.selected").removeClass("selected");
					$("#toc-entry-" + i).addClass("selected");
				}
			}
		}
		if ($(this).scrollTop() < $(".header").height()) {
			$(".table-of-contents").css("top", $(".header").height() - $(this).scrollTop() + 50 + "px");
		}
		else if ($(".table-of-contents").css("top") !== "50px") {
			$(".table-of-contents").css("top", "50px");
		}
		if ($(this).scrollTop() > $(".footer").position().top - $(window).height() + 150) {
			$(".share-controls").css({
					position: "static"
				}).addClass('display-inline');
			$(".table-of-contents").css("left", 10 - $(".table-of-contents").width() + "px");
		}
		else
		{
			 if ($(".share-controls").hasClass("display-inline"))
				 {
				 if($(window).width() >= 1024)
					{
					$(".share-controls").css({
							position:"fixed", 
							bottom: "20px",   
							right: "20px",
							zIndex: 0
						}).removeClass('display-inline');
					}
				$(".table-of-contents").css("left", 0);
				}
		}
	});
	$(".created-by").click(function() {
		//ga('send', 'event', 'Outbound', 'click', "http://www.codersforcorbyn.com");
		window.open("http://www.codersforlabour.com", "_blank");
	});
	$(".convinced-button").click(function() {
		//ga('send', 'event', 'Convinced', 'click', "http://www.jeremyforlabour.com/volunteer");
		window.open("https://join.labour.org.uk", "_blank");
	});
	$("a").click(function() {
		//ga('send', 'event', 'Outbound', 'click', $(this).attr("href"));
		return true;
	});
});


if (window.location.hash) {
	// Scroll to pre-selected question
	setTimeout(function(){
		var entryClass = window.location.hash.replace(/#/g,'').replace(/\?/g,'');
		$("div[data-question=" + entryClass + "]").click();
	}, 300);
};
var generateEntry = function(entry, index) {
	$(".faq").append("<div class='entry clearfix' id='entry-" + index + "'>\
		<div class='question-container'>\
			<div class='question'>" + entry.question + "</div>\
		</div>\
		<div class='answer-container'>\
			<div class='answer'>" + entry.answer + "</div>\
		</div>\
	</div>");

	if (entry.question.indexOf("learn more") < 0) {
		$(".table-of-contents .questions").append("<div class='toc-entry' id='toc-entry-" + index + "' data-question='" + entry.id + "'>" + entry.question + "</div>");
	}	
}