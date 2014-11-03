﻿/* Problem 2. DOM Traversal
You are given an HTML file. Write a function that traverses all child elements
of an element by a given CSS selector and prints all found elements in the format:
<Element name>: id="<id>", class="<class>"
Print each element on a new line. Indent child elements. */

function traverse(selector) {
    'use strict';

    var element = document.querySelector(selector);
    traverseElement(element, '');

    function traverseElement(element, spacing) {

        spacing = spacing || "  ";
        var elementAsString = spacing + element.nodeName.toLowerCase() + ':';

        if (element.hasAttribute('id')) {
            elementAsString += ' id="' + element.id;
        }

        if (element.hasAttribute('class')) {
            elementAsString += ' class="' + element.className + '"';
        }

        console.log(elementAsString);

        [].forEach.call(element.childNodes, function (child) {
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseElement(child, spacing + "  ");
            }

        });

    }
}

var selector = ".birds";
traverse(selector);