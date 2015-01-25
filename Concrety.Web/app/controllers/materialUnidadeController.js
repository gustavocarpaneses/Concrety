'use strict';
app.controller('materialUnidadeController', function ($scope, materiaisService) {

    $scope.$watch("fvm.idFichaVerificacaoMaterial", function (newValue, oldValue) {

        if ($scope.fvm.idFichaVerificacaoMaterial) {

            if ($scope.fvm.isNew()) {

                materiaisService.criarItens($scope.fvm.idFichaVerificacaoMaterial).then(function (response) {
                    $scope.fvm.itens = response.data;
                });
            }

            materiaisService.obterCriterioAceite($scope.fvm.idFichaVerificacaoMaterial).then(function (response) {
                $scope.criterioAceite = response.data;
            });

        }

    });

});