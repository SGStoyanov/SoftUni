"use strict";

app.controller('RegisterCtrl', ['$scope', '$http', '$location', 'userData',
    function ($scope, $http, $location, userData) {

        var defaultRegisterForm = {
            username: '',
            password: '',
        };

        $scope.register = function (user) {
            //console.log(user);
            userData.register(user)
                .then(function (data) {
                    //console.log(data);
                    noty({ text: 'You have registered successfully!', type: 'success', timeout: 2000 });
                    noty({ text: 'Please login!', type: 'success', timeout: 2000 });
                    $location.path('/login');
                }, function (err) {
                    console.log(err);
                    noty({ text: err.error, type: 'error', timeout: 2000 });
                    $scope.registerForm.$setPristine();
                    $scope.user = defaultRegisterForm;
                    $scope.rePassword = '';
                });
        }
    }
]);