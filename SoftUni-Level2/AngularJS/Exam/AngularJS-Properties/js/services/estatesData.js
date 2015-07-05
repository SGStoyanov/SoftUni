"use strict";

app.service('estatesData', ['$http', '$q', 'baseServiceUrl', 'parseComHeaders', 'authentication',
    function ($http, $q, baseServiceUrl, parseComHeaders, authentication) {

        var headerWithTokens = parseComHeaders;

        parseComHeaders["X-Parse-Session-Token"] = authentication.getUserData().sessionToken;

        var getMyEstates = function () {

            var defer = $q.defer();

            var getEstatesRequest = {
                method: 'GET',
                url: baseServiceUrl + 'classes/Estate',
                headers: headerWithTokens
            };

            $http(getEstatesRequest).success(function (data) {
                defer.$$resolve(data);
            }).error(function (err) {
                defer.$$reject(err);
            });

            return defer.promise;
        };

        var getEstatesCategories = function () {
            var defer = $q.defer();

            var getCategoriesRequest = {
                method: 'GET',
                url: baseServiceUrl + 'classes/Category',
                headers: headerWithTokens
            };

            $http(getCategoriesRequest)
                .success(function (data) {
                    defer.$$resolve(data);
                })
                .error(function (err) {
                    defer.$$reject(err);
                });

            return defer.promise;
        }

        var addEstate = function (estate) {
            var defer = $q.defer();
            var userId = authentication.getUserData().objectId;

            estate["ACL"] = {};
            estate["price"] = Number(estate["price"]);
            estate["ACL"][userId] = { "write": true, "read": true };

            //console.log(estate);

            var addEstateRequest = {
                method: 'POST',
                url: baseServiceUrl + 'classes/Estate',
                headers: parseComHeaders,
                data: estate
            };

            $http(addEstateRequest)
                .success(function (data) {
                defer.$$resolve(data);
                })
                .error(function (err) {
                defer.$$reject(err);
            });

            return defer.promise;
        };

        var editEstate = function (estate) {

            var defer = $q.defer();

            var editEstateRequest = {
                method: 'PUT',
                url: baseServiceUrl + 'classes/Estate/' + estate.objectId,
                headers: headerWithTokens,
                data: estate
            };

            $http(editEstateRequest).success(function (data) {
                defer.$$resolve(data);
            }).error(function (err) {
                defer.reject(err);
            });

            return defer.promise;
        };

        var deletePhone = function (estateId) {
            var defer = $q.defer();

            var deleteEstateRequest = {
                method: 'DELETE',
                url: baseServiceUrl + 'classes/Estate/' + estateId,
                headers: headerWithTokens,
                data: null
            };

            $http(deleteEstateRequest).success(function (data) {
                defer.resolve(data);
            }).error(function (err) {
                defer.$$reject(err);
            });

            return defer.promise;
        };


        return {
            getMyEstates: getMyEstates,
            getCategories: getEstatesCategories,
            addEstate: addEstate,
            editEstate: editEstate,
            deletePhone: deletePhone
        }
    }
]);