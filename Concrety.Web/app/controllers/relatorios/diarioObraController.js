'use strict';
app.controller('relatoriosDiarioObraController', function ($scope, $modalInstance, diariosObra, condicoesClimaticas, accountService) {

    $scope.nomeEmpreendimento = accountService.empreendimentoAtual.nome;
    $scope.diariosObra = diariosObra;
    $scope.condicoesClimaticas = condicoesClimaticas;

    $scope.fechar = function () {
        $modalInstance.dismiss();
    };

});