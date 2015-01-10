'use strict';
app.controller('indexController',
    ['$rootScope', '$scope', '$location', 'authService', 'accountService', 'materiaisService', 'servicosService',
        function ($rootScope, $scope, $location, authService, accountService, materiaisService, servicosService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.alterarEmpreendimento = function (empreendimentoAtual) {
        accountService.alterarEmpreendimentoAtual(empreendimentoAtual);
        recarregarEmpreendimentoAtual();
    }

    $scope.authentication = authService.authentication;

    if (authService.authentication.isAuth) {
        carregarDadosComLogin();
    }

    $scope.$on('loginEvent', function (event, args) {
        carregarDadosComLogin();
    });

    function carregarDadosComLogin() {
        $scope.empreendimentosUsuario = accountService.getEmpreendimentosUsuario();
        recarregarEmpreendimentoAtual();
    }

    function recarregarEmpreendimentoAtual() {
        $scope.empreendimentoAtual = accountService.empreendimentoAtual;

        materiaisService.getNiveis(accountService.empreendimentoAtual.id).then(function (response) {
            $scope.niveisMaterial = response.data;
        });

        servicosService.getNiveis(accountService.empreendimentoAtual.id).then(function (response) {
            $scope.niveisServico = response.data;
        });
    }

}]);