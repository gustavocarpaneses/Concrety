'use strict';
app.controller('indexController',
    ['$rootScope', '$scope', '$location', 'authService', 'accountService', 'niveisService',
        function ($rootScope, $scope, $location, authService, accountService, niveisService) {

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

        var idMacroServicoAtual = accountService.macroServicoAtual.id;

        niveisService.getNiveisVerificacaoMaterial(idMacroServicoAtual).then(function (response) {
            $scope.niveisVerificacaoMaterial = response.data;
        });

        //niveisService.getNiveisServico(idMacroServicoAtual).then(function (response) {
        //    $scope.niveisServico = response.data;
        //});
    }

}]);