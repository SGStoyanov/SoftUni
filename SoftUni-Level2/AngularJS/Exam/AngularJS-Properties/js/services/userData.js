"use strict";

app.service('userData', ['$http', '$q', 'baseServiceUrl', 'parseComHeaders',
    function ($http, $q, baseServiceUrl, parseComHeaders) {

        var login = function (user) {
            var defer = $q.defer();

            var loginRequest = {
                method: 'GET',
                url: baseServiceUrl + 'login?username=' + user.username + '&password=' + user.password,
                headers: parseComHeaders
            };

            $http(loginRequest)
                .success(function (data) {
                defer.resolve(data);
                })
                .error(function (err) {
                defer.reject(err);
            });

            return defer.promise;
        };

        var register = function (user) {
            var defer = $q.defer();

            var registerRequest = {
                method: 'POST',
                url: baseServiceUrl + 'users',
                headers: parseComHeaders,
                data: user
            };

            $http(registerRequest)
                .success(function (data) {
                //console.log(data);
                defer.resolve(data);
                })
                .error(function (err) {
                defer.reject(err);
            });

            return defer.promise;
        };

        return {
            login: login,
            register: register
        }
    }
]);