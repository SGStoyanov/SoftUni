"use strict";

app.controller('EstatesCtrl', ['$scope', '$location', 'estatesData', 'estateEditor',
    function ($scope, $location, estatesData, estateEditor) {

        function getEstateData() {
            estatesData.getMyEstates()
                .then(function (data) {
                    $scope.estates = data.results;
                    if ($scope.estates.length === 0) {
                        noty({
                            layout: 'center',
                            text: 'You don\'t have any estates yet!',
                            type: 'success',
                            timeout: 1500
                        });
                    }

                    //var category = estatesData.getCategories();

                    console.log($scope.estates);
                    return $scope.estates;
                }, function (err) {
                    console.log(err);
                });
        }

        getEstateData();

        $scope.editor = function (estate) {
            console.log(estate);
            estateEditor.setEditedEstate(estate);
        };

        $scope.deleteEstate = function (estate) {
            var estateId = estate.objectId;

            estatesData.deletePhone(estateId)
                .then(function (data) {
                    noty({ text: 'You have deleted an item successfully!', type: 'success', timeout: 2000 });
                    getEstateData();
                }, function (err) {
                    console.log(err);
                });
        };

        $scope.filterEstates = function (filter) {
            var filterNameValue = filter.name;
            var filterMinPrice = isNaN(filter.minPrice) ? 0 : filter.minPrice;
            var filterMaxPrice = isNaN(filter.maxPrice) ? Number.MAX_VALUE : filter.maxPrice;
            var category = (typeof filter.category === 'undefined') ? 'all' : filter.category;


            var filteredResults = $scope.estates.filter(function (estate) {
                var estateName = estate.name;

                return ((estateName.substr(0, filterNameValue.length).toLowerCase() ===
                    filterNameValue.toLowerCase()) || !filterNameValue) &&
                    (estate.price >= filterMinPrice && estate.price <= filterMaxPrice) &&
                    (estate.category === category || category === 'all');
            });

            $scope.estates = filteredResults;
        }
    }
]);