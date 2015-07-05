"use strict";

var app = angular.module('propertiesApp', ['ngRoute', 'notyModule', 'ngMessages']);

app.constant('baseServiceUrl', 'https://api.parse.com/1/');
app.constant('parseComHeaders', {
    
});

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'templates/welcome-guest.html',
            controller: 'HomeCtrl'
        })
        .when('/login', {
            templateUrl: 'templates/login.html',
            controller: 'LoginCtrl'
        })
        .when('/register', {
            templateUrl: 'templates/register.html',
            controller: 'RegisterCtrl'
        })
        .when('/user/', {
            templateUrl: 'templates/welcome-user.html',
            controller: 'HomeCtrl'
        })
        .when('/user/estates', {
            templateUrl: 'templates/estates-list.html',
            controller: 'EstatesCtrl'
        })
        .when('/user/estate-add', {
            templateUrl: 'templates/estate-add.html',
            controller: 'AddEstateCtrl'
        })
        .when('/user/estate-edit', {
            templateUrl: 'templates/estate-edit.html',
            controller: 'EstatesCtrl'
        })
        .when('/user/estate-delete', {
            templateUrl: 'templates/estate-delete.html',
            controller: 'EstatesCtrl'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);