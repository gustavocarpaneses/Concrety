'use strict';
app.controller('indexController',
    ['$rootScope', '$scope', '$location', 'authService', 'accountService', 'materiaisService', 'servicosService',
        function ($rootScope, $scope, $location, authService, accountService, materiaisService, servicosService) {

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

        materiaisService.getNiveis($rootScope.empreendimentoAtual.id).then(function (results) {
            $scope.niveisMaterial = results.data;
        });

        servicosService.getNiveis($rootScope.empreendimentoAtual.id).then(function (results) {
            $scope.niveisServico = results.data;
        });

    });

}]);