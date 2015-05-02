'use strict';
app.controller('modalFeedbackController', function ($scope, $timeout, $modalInstance, emailService) {

    $scope.feedback = {
        mensagem: ''
    };

    $scope.salvoComSucesso = false;
    $scope.mensagem = "";

    $scope.fechar = function () {
        $modalInstance.dismiss();
    };

    $scope.enviar = function () {
        emailService.enviarFeedback($scope.feedback).then(salvoSucesso, erroSalvar);
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

        if (response.data.modelState) {
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
        }
        else {
            errors.push("Ocorreu um erro ao enviar o Feedback. Por favor, verifique se todos os campos estão preenchidos corretamente e tente novamente. Caso o erro persista, entre em contato através do e-mail: suporte@concrety.com.br");
        }
        $scope.mensagem = errors.join(' ');
    }

});