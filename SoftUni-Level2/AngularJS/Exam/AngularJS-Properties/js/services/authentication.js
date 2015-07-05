"use strict";

app.service("authentication", function () {
    var getUserData = function () {
        return JSON.parse(localStorage.getItem("propertiesApp.user"));
    };

    var isLoggedIn = function () {
        return getUserData() != null;
    };

    var setUserData = function (user) {
        localStorage.setItem("propertiesApp.user", JSON.stringify(user));
    };

    var removeUserData = function () {
        delete localStorage['propertiesApp.user'];
    };

    return {
        getUserData: getUserData,
        isLoggedIn: isLoggedIn,
        setUserData: setUserData,
        removeUserData: removeUserData
    };
});