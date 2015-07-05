"use strict";

app.service('estateEditor',
    function () {
        var getEditedEstate = function () {
            return JSON.parse(localStorage.getItem("estatesApp.editedItem"));
        };

        var setEditedEstate = function (estate) {
            localStorage.setItem("estatesApp.editedItem", JSON.stringify(estate));
        };

        return {
            getEditedEstate: getEditedEstate,
            setEditedEstate: setEditedEstate
        };
    }
);