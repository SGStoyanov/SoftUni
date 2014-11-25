﻿$(document).ready(function() {
    "use strict";

    var currentPosition = 0;
    var slideWidth = 1000;
    var slides = $('.slide');
    var numberOfSlides = slides.length;
    var speed = 6000;
    var slideShowInterval = setInterval(changePosition, speed);


    // Wrapping the slides in another parent div
    slides.wrapAll('<div id = "slidesHolder" />');

    slides.css('float', 'left');
    $('#slidesHolder').css('width', slideWidth * numberOfSlides);

    function changePosition() {
        if (currentPosition == numberOfSlides - 1) {
            currentPosition = 0;
            manageNav(currentPosition);
        } else {
            currentPosition++;
            manageNav(currentPosition);
        }
        moveSlide();
    }

    function moveSlide() {
        $('#slidesHolder').animate({'marginLeft' : slideWidth * (-currentPosition)});
    }

    // Navigation
    function manageNav(position) {
        //hide left arrow if position is first slide
        if (position == 0) {
            $('#leftNav').hide();
        } else {
            $('#leftNav').show();
        }
        
        if (position == numberOfSlides - 1) {
            $('#rightNav').hide();
        } else {
            $('#rightNav').show();
        }
    }
    
    $('#slideshow')
	.prepend('<span class="nav" id="leftNav">Move Left</span>')
	.append('<span class="nav" id="rightNav">Move Right</span>');

    manageNav(currentPosition);

    $('.nav').bind('click', function() {
        //determine new position
        currentPosition = ($(this).attr('id') == 'leftNav') ? currentPosition - 1 : currentPosition + 1;

        //hide/show controls
        manageNav(currentPosition);
        clearInterval(slideShowInterval);
        slideShowInterval = setInterval(changePosition, speed);
        moveSlide();
    });

});