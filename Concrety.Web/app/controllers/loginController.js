'use strict';
app.controller('loginController', ['$rootScope', '$scope', '$location', 'authService', function ($rootScope, $scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {

            $rootScope.$broadcast('loginEvent', []);
            $location.path('/home');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

}]);