﻿'use strict';
app.controller('loginController', ['$rootScope', '$scope', '$location', 'authService', 'accountService', function ($rootScope, $scope, $location, authService, accountService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            accountService.fillEmpreendimentosUsuario().then(function () {
                $rootScope.$broadcast('loginEvent', []);
            });
            $location.path('/home');

        }, function (err) {
             $scope.message = err.error_description;
        });
    };

}]);