

$(document).ready(function () 
{
    var nav = $('#main-menu-container');

    $(window).scroll(function () {
        if ($(this).scrollTop() > 125) {
            nav.addClass("f-nav");
        } else {
            nav.removeClass("f-nav");
        }
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 125) {
            nav.addClass("sitef-nav");
        } else {
            nav.removeClass("sitef-nav");
        }
    });

    $(function () {
        $(".dropdown").hover(
            function () {
                $('.dropdown-menu', this).stop(true, true).fadeIn("fast");
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");
            },
            function () {
                $('.dropdown-menu', this).stop(true, true).fadeOut("fast");
                $(this).toggleClass('open');
                $('b', this).toggleClass("caret caret-up");
            });
    });

    $('.bxslider').bxSlider({
        auto: true,
        autoControls: true
    });
    
    $(function () {

        jQuery.scrollSpeed(80, 1500);

    });
    $("#owl-demo").owlCarousel({
        items: 2,
        itemsDesktop: [1000, 3], //5 items between 1000px and 901px
        itemsDesktopSmall: [900, 1], // betweem 900px and 601px
        itemsTablet: [600, 1], //2 items between 600 and 0
        autoplayHoverPause: true
    });

    var owl = $("#owl-demos");
    owl.owlCarousel({
        items: 4, //10 items above 1000px browser width
        itemsDesktop: [1000, 2], //5 items between 1000px and 901px
        itemsDesktopSmall: [900, 2], // betweem 900px and 601px
        itemsTablet: [600, 1], //2 items between 600 and 0
        navigation: true,
        autoPlay: 4000,
        autoplayTimeout: 8000,
        pagination: false,
        itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
    });

    var owl = $("#owl-demos-clients");
    owl.owlCarousel({
        items: 5, //10 items above 1000px browser width
        itemsDesktop: [1000, 4], //5 items between 1000px and 901px
        itemsDesktopSmall: [900, 3], // betweem 900px and 601px
        itemsTablet: [600, 2], //2 items between 600 and 0
        navigation: false,
        autoPlay: 4000,
        autoplayTimeout: 8000,
        pagination: false,
        itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
    });
   
});