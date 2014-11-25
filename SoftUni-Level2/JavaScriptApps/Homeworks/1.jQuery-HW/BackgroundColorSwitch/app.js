$(document).ready(function() {
    "use strict";

    // CSS Part
    $(".inputControls").css({
        "width": "12%",
        "display": "inline-block",
        "margin-top": "1.5%",
        "float": "left"
    });

    $(".listBox").css({
        "width": "10%",
        "padding": "0",
        "float": "left",
        "margin": "0"
    });

    $("#classInput").css({
        "width": "50%"
    });

    // Logic Part
    var targetClass = "";
    var targetColor = "";

    $("#classInput").change(function() {
        targetClass = $('#classInput').val();
    });
    
    $("#colorInput").change(function () {
        targetColor = $('#colorInput').val();
    });

    $('.paint').click(function () {
        $('.' + targetClass.toString()).css("background", targetColor.toString());
    });
});