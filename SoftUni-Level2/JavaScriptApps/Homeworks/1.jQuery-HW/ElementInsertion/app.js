$(document).ready(function () {
    "use strict";

    var MINIMUM_NUMBER_OF_LIs = 1; // The first pre-created li will never be deleted

    var liCount = $("li").length;

    var afterItemNumber = 0;
    $(".addAfter").click(function () {
        ++afterItemNumber;
        $("li").parent().append("<li>Added li element <strong>After</strong> the first number: " 
            + afterItemNumber + "</li>");

        liCount++;
    });

    var beforeItemNumber = 0;
    $(".addBefore").click(function () {
        ++beforeItemNumber;
        $("li").parent().prepend("<li>Added li element <strong>Before</strong> the first number: " 
            + beforeItemNumber + "</li>");

        liCount++;
    });

    $(".removeAfter").click(function () {

        if (liCount > MINIMUM_NUMBER_OF_LIs && afterItemNumber > 0) {
            $("li:last").remove();
            liCount--;
            afterItemNumber--;
        }
        
    });

    $(".removeBefore").click(function() {
        if (liCount > MINIMUM_NUMBER_OF_LIs && beforeItemNumber > 0) {
            $("li:first").remove();
            liCount--;
            beforeItemNumber--;
        }
    });

});