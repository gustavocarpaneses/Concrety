﻿'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.salvoComSucesso = false;
    $scope.mensagem = "";

    $scope.registration = {
        nome: "",
        telefone: "",
        email: "",
        password: "",
        confirmPassword: ""
    };

    $scope.signUp = function () {

        authService.saveRegistration($scope.registration).then(function (response) {

            $scope.salvoComSucesso = true;
            $scope.mensagem = "Usuário registrado com sucesso, você será redirecionado para a página de login em 2 segundos.";
            startTimer();

        },
         function (response) {
             var errors = [];
             if (response.data.modelState) {
                 for (var key in response.data.modelState) {
                     for (var i = 0; i < response.data.modelState[key].length; i++) {
                         errors.push(response.data.modelState[key][i]);
                     }
                 }
             }
             else {
                 errors.push("Por favor, verifique se todos os campos estão preenchidos corretamente e tente novamente. Caso o erro persista, entre em contato conosco através da ferramenta de feedback (localizada no canto superior direito).");
             }
             $scope.mensagem = "Falha ao registrar o usuário:" + errors.join(' ');
         });
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

}]);