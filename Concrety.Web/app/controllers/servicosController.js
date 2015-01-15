'use strict';
app.controller('servicosController', ['$scope', '$routeParams', 'unidadesService', 'niveisService', 'servicosService', function ($scope, $routeParams, unidadesService, niveisService, servicosService) {

    var idNivel = $routeParams.id;

    $scope.dropDownOptions = [];
    $scope.unidadeSelecionada = '';
    $scope.servicosDaUnidade = [];

    niveisService.obterNiveisAcima(idNivel).then(function (response) {
        $scope.niveis = response.data;

        angular.forEach($scope.niveis, function(nivel, index){

            this.push({
                dataTextField: "nome",
                dataValueField: "id",
                cascadeFrom: index == 0 ? "" : "nivel" + (index - 1),
                cascadeFromField: index == 0 ? "" : "idUnidadePai",
                optionLabel: index == $scope.niveis.length - 1 ? "Selecione..." : "",
                dataSource: new kendo.data.DataSource({
                    type: "json",
                    transport: {
                        read: function (o) {
                            unidadesService.obterDoNivel(nivel.id).then(function (response) {
                                o.success(response.data)
                            })
                        }
                    }
                }),
            });

        }, $scope.dropDownOptions);

    });

    $scope.$watch('unidadeSelecionada', function (newValue, oldValue) {
        
        if (!newValue) {
            return;
        }

        var idUnidade = $scope.unidadeSelecionada;
        var idNivel = $scope.niveis[$scope.niveis.length - 1].id;

        $scope.abasServico = [];

        servicosService.obterDaUnidade(idUnidade, idNivel).then(function (response) {
            $scope.servicosDaUnidade = response.data;
        });

    });
            
}]);