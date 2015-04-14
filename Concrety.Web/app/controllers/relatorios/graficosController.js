'use strict';
app.controller('graficosController', function ($scope, accountService, graficosService) {

    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

    configurarGraficos();
    
    function configurarGraficos() {

        configurarGraficoCondicoesClimaticas();

    }

    function configurarGraficoCondicoesClimaticas() {
        $scope.condicoesClimaticas = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    graficosService.obterDeCondicoesClimaticas($scope.empreendimentoAtual.id).then(function (response) {
                        o.success(response.data);
                    });
                }
            }
        });
    }

});