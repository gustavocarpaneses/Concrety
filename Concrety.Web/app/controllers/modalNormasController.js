'use strict';
app.controller('modalNormasController', function ($scope, $modalInstance, servico) {

    $scope.servico = servico;

    $scope.fechar = function () {
        $modalInstance.close();
    };

});