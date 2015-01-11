﻿var app = angular.module('concretyApp', ['ngRoute', 'LocalStorageModule', 'kendo.directives', 'ui.bootstrap', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/partials/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/partials/login.html"
    });
    
    $routeProvider.when("/diarioObra", {
        controller: "diarioObraController",
        templateUrl: "/app/partials/diarioObra.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

var serviceBase = 'http://concrety.azurewebsites.net/';
app.constant('concretySettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'concretyApp'
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

app.run(['accountService', function (accountService) {
    accountService.fillData();
}]);

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});