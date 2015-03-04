'use strict';
app.controller('relatoriosMateriaisController', function ($scope, $modalInstance, fvms, accountService) {

    $scope.nomeEmpreendimento = accountService.empreendimentoAtual.nome;
    $scope.fvms = fvms;

    $scope.fechar = function () {
        $modalInstance.dismiss();
    };

});