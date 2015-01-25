var app = angular.module('concretyApp', ['ngRoute', 'ngSanitize', 'LocalStorageModule', 'kendo.directives', 'ui.bootstrap', 'angular-loading-bar']);

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

    $routeProvider.when("/servicos/:id", {
        controller: "servicosController",
        templateUrl: "/app/partials/servicos.html"
    });

    $routeProvider.when("/materiais/:id", {
        controller: "materiaisController",
        templateUrl: "/app/partials/materiais.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

//var serviceBase = 'http://concrety.azurewebsites.net/';
var serviceBase = 'http://localhost:51503/';
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

app.config(['datepickerConfig', 'datepickerPopupConfig', function (datepickerConfig, datepickerPopupConfig) {
    datepickerPopupConfig.datepickerPopup = 'dd/MM/yyyy';
    datepickerPopupConfig.currentText = 'Hoje';
    datepickerPopupConfig.clearText = 'Limpar';
    datepickerPopupConfig.closeText = 'Fechar';
    datepickerPopupConfig.closeOnDateSelection = true;
    
    datepickerConfig.showWeeks = false;

}]);