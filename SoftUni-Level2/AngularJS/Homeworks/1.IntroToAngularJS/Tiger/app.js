(function() {
    'use strict';

    var tigerPesho = {
        'Name': 'Pesho',
        'Born': 'Asia',
        'Birthday': 2006,
        'Live': 'Sofia Zoo'
    };

    var app = angular.module('tigerApp', []);
    app.controller('TigerMainCtrl', function($scope) {
        $scope.name = tigerPesho.Name;
        $scope.birthLocation = tigerPesho.Born;
        $scope.birthday = tigerPesho.Birthday;
        $scope.livingLocation = tigerPesho.Live;
        $scope.photoUrl = 'http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg';

        $scope.paragraphStyle = {
            fontWeight: 'bold',
            fontSize: '1.5em'
        }
    });

}());