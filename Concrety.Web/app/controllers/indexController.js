'use strict';
app.controller('indexController', ['$rootScope', '$scope', '$location', 'authService', 'accountService', function ($rootScope, $scope, $location, authService, accountService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.alterarEmpreendimento = function (empreendimentoAtual) {
        $rootScope.empreendimentoAtual = empreendimentoAtual;
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

    $scope.empreendimentosUsuario = [];

    $scope.$on('loginEvent', function (event, args) {

        accountService.getEmpreendimentos().then(function (results) {
            $scope.empreendimentosUsuario = results.data;
            $rootScope.empreendimentoAtual = $scope.empreendimentosUsuario[0];
        });

    });

}]);