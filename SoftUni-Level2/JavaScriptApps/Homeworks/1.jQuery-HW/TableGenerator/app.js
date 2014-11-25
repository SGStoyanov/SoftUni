$(document).ready(function() {
    "use strict";

    var inputString = [
        { "manufacturer": "BMW", "model": "E92 320i", "year": 2011, "price": 50000, "class": "Family" },
        { "manufacturer": "Porsche", "model": "Panamera", "year": 2012, "price": 100000, "class": "Sport" },
        { "manufacturer": "Peugeot", "model": "305", "year": 1978, "price": 1000, "class": "Family" }
    ];

    $("main").append("<table><thead><tr></tr></thead></table");

    var firstObject = inputString[0];

    $.each(firstObject, function (key, value) {
        $("tr").append("<th>" + key + "</th>");
    });
    
    $("table").css("border-spacing", "0px");

    $("th").css({
        "text-transform": "capitalize",
        "width": "120px",
        "border": "1px solid black"
    });

    $("thead").css("background", "olive");

    $("table").append("<tbody></tbody>");

    $.each(inputString, function(key, value) {
        var currentObject = value;
        $("tbody").append("<tr>");
        $.each(currentObject, function(childKey, childValue) {
            $("tr:last").append("<td>" + childValue + "</td>");
        });

        $("tbody").append("</tr>");
    });

    $("td").css("border", "1px solid black");
});