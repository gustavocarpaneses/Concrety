'use strict';
app.controller('materialUnidadeController', function ($scope, materiaisService) {

    $scope.$watch("fvm.idFichaVerificacaoMaterial", function (newValue, oldValue) {

        if ($scope.fvm.isNew()) {

            materiaisService.obterItens($scope.fvm.idFichaVerificacaoMaterial).then(function (response) {
                $scope.fvm.itens = response.data;
            });

        }

    });

});