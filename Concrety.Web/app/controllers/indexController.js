'use strict';
app.controller('indexController', ['$rootScope', '$scope', '$location', 'authService', 'accountService', function ($rootScope, $scope, $location, authService, accountService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.alterarEmpreendimento = function (id, nome) {
        $rootScope.idEmpreendimentoAtual = id;
        $rootScope.nomeEmpreendimentoAtual = nome;
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

    $scope.empreendimentosUsuario = [];

    accountService.getEmpreendimentos().then(function (results) {
        $scope.empreendimentosUsuario = results.data;
    });

}]);