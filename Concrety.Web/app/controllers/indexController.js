'use strict';
app.controller('indexController', function ($scope, $location, $modal, authService, accountService, niveisService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login');
    }

    $scope.alterarEmpreendimento = function (empreendimentoAtual) {
        accountService.alterarEmpreendimentoAtual(empreendimentoAtual);
        recarregarEmpreendimentoAtual();
        if ($location.path() === '/home') {
            angular.element("#grid_ocorrencias").data("kendoGrid").dataSource.read();
        }
        else {
            $location.path('/home');
        }
    }

    $scope.authentication = authService.authentication;

    if (authService.authentication.isAuth) {
        carregarDadosComLogin();
    }

    $scope.$on('loginEvent', function (event, args) {
        carregarDadosComLogin();
    });

    $scope.abrirModalFeedback = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalFeedback.html?v=' + new Date(),
            controller: 'modalFeedbackController',
            size: 'lg'
        });
    };

    function carregarDadosComLogin() {
        $scope.empreendimentosUsuario = accountService.getEmpreendimentosUsuario();
        recarregarEmpreendimentoAtual();
    }

    function recarregarEmpreendimentoAtual() {
        $scope.empreendimentoAtual = accountService.empreendimentoAtual;

        var idMacroServicoAtual = accountService.macroServicoAtual.id;

        niveisService.obterNiveisDeVerificacaoDeMaterial(idMacroServicoAtual).then(function (response) {
            $scope.niveisVerificacaoMaterial = response.data;
        });

        niveisService.obterNiveisDeServico(idMacroServicoAtual).then(function (response) {
            $scope.niveisServico = response.data;
        });
    }

});