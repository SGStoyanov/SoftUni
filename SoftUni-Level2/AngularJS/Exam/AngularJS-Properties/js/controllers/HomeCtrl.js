"use strict";

app.controller('HomeCtrl', ['$scope', 'authentication',
    function ($scope, authentication) {
        $scope.isLoggedIn = authentication.isLoggedIn();
        //console.log($scope.isLoggedIn);
        $scope.isAnonymous = !authentication.isLoggedIn();
        //console.log($scope.isAnonymous);

        if ($scope.isLoggedIn) {
            $scope.loggedUsername = authentication.getUserData().username;
        }

        $scope.logout =
            function () {
                var logout = authentication.removeUserData();
                if (logout === true) {
                    console.log('logged out!');
                }
            }
    }
]);