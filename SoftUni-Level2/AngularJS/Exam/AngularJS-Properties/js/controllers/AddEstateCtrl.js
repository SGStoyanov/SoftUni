"use strict";

app.controller('AddEstateCtrl', ['$scope', '$location', 'estatesData',
    function ($scope, $location, estatesData) {

        function getEstateCategories() {
            estatesData.getCategories()
                .then(function (data) {
                    $scope.categories = data.results;
                    if ($scope.categories.length === 0) {
                        noty({
                            layout: 'center',
                            text: 'You don\'t have any categories yet!',
                            type: 'success',
                            timeout: 1500
                        });
                    }

                    return $scope.categories;
                }, function (err) {
                    console.log(err);
                });
        }

        getEstateCategories();

        $scope.addEstate = function (estate) {
            if (!estate || !estate.name || !estate.price || !estate.category) {
                return;
            }

            estatesData.addEstate(estate)
                .then(function (data) {
                    noty({ text: 'You have added estate successfully!', type: 'success', timeout: 1600 });
                    $location.path('/user/estates');
                }, function (err) {
                    noty({ text: 'Error adding estate!', type: 'error', timeout: 1600 });
                });
        };
    }
]);