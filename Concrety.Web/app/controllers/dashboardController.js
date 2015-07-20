'use strict';
app.controller('dashboardController', function ($scope, $location, $modal, authService, accountService, ocorrenciasService) {

    if (!authService.authentication.isAuth) {
        $location.path('/login');
    }

    configurarGraficos();
 
    function configurarGraficos() {

        configurarGraficoCondicoesClimaticas();

    }

    function configurarGraficoCondicoesClimaticas() {

    }

});