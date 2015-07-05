"use strict";

app.controller('LoginCtrl', ['$scope', '$route', '$http', '$location', 'userData', 'authentication',
    function ($scope, $route, $http, $location, userData, authentication) {
        var defaultLoginForm = {
            username: '',
            password: ''
        };

        $scope.login = function (user) {
            userData.login(user)
                .then(function (user) {
                    //console.log(user);
                    authentication.setUserData(user);
                    noty({ text: 'You have logged in successfully!', type: 'success', timeout: 1500 });
                    $location.path('/user/');
                    //$route.reload();
                }, function (err) {
                    noty({ text: 'Invalid login!', type: 'error', timeout: 1500 });
                    $scope.loginForm.$setPristine();
                    $scope.user = defaultLoginForm;
                });
        }
    }
]);