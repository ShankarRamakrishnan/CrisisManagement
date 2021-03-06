﻿var app = angular.module("CrisisManagement", ['ngRoute'])
    .config(function ($routeProvider, $locationProvider, $httpProvider) {

        $routeProvider.when('/home',
        {
            templateUrl: 'home.html',
            controller: 'HomeCtrl'
        });

        $routeProvider.when('/contact',
        {
            templateUrl: 'contact.html',
            controller: 'ContactCtrl'
        });

        $routeProvider.when('/createIncident',
        {
            templateUrl: 'createIncident.html',
            controller: 'IncidentCtrl'
        });

        $routeProvider.when('/manageIncident',
        {
            templateUrl: 'manageIncident.html',
            controller: 'IncidentCtrl'
        });

        $routeProvider.otherwise(
        {
            redirectTo: '/home',
            controller: 'HomeCtrl',
        });
    });