/* Problem 3.	DOM Manipulation
Create an IIFE module for working with the DOM tree. The module should support the following operations:
•	Adding а DOM element to a parent element specified by selector
•	Removing a child element from a parent specified by selector
•	Attaching an event to a given selector by given event type and event hander
•	Retrieving elements by a given CSS selector
The module should reveal only its methods (i.e. everything else should be encapsulated). */

var domModule = (function() {

    return {
        appendChild: function (child, parentSelector) {

            var parent = document.querySelector(parentSelector);
            parent.appendChild(child);

        },

        removeChild: function (parentSelector, childSelector) {

            var parent = document.querySelector(parentSelector);
            var child = parent.querySelector(childSelector);
            parent.removeChild(child);

        },

        addHandler: function(attributeSelector, event, func) {
            var selector = document.querySelectorAll(attributeSelector);

            for (var i = 0; i < selector.length; i++) {
                selector[i].addEventListener(event, func);
            }

        },

        retrieveElements: function(selector) {
            var elements = document.querySelectorAll(selector);

            for (var index in elements) {
                console.log(elements[index]);
            }

        }

    }

}());

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");

// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function () { alert("I'm a bird!"); });

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");