'use strict';
app.controller('modalFeedbackController', function ($scope, $timeout, $modal, $modalInstance) {

    $scope.feedback = [];

    $scope.salvoComSucesso = false;
    $scope.mensagem = "";

    $scope.fechar = function () {
        $modalInstance.dismiss();
    };

    $scope.salvar = function () {
    };

    function salvoSucesso(response) {
        $scope.salvoComSucesso = true;
        $scope.mensagem = "Feedback enviado com sucesso.";

        $timeout(function () {
            $modalInstance.close();
        }, 1000);
    }

    function erroSalvar(response) {
        var errors = [];
        for (var key in response.data.modelState) {
            for (var i = 0; i < response.data.modelState[key].length; i++) {
                errors.push(response.data.modelState[key][i]);
            }
        }
        $scope.mensagem = errors.join(' ');
    }

});