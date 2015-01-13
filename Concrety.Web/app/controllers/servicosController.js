'use strict';
app.controller('servicosController', ['$scope', '$routeParams', 'unidadesService', 'niveisService', function ($scope, $routeParams, unidadesService, niveisService) {

    var idNivel = $routeParams.id;

    $scope.dropDownOptions = [];

    $scope.unidadeSelecionada = '';
    $scope.urlsServicos = [];
    $scope.servicos = [];

    niveisService.getNiveisAcima(idNivel).then(function (response) {
        $scope.niveis = response.data;

        angular.forEach($scope.niveis, function(value, key){

            this.push({
                dataTextField: "nome",
                dataValueField: "id",
                cascadeFrom: key == 0 ? "" : "nivel" + (key - 1),
                cascadeFromField: key == 0 ? "" : "idUnidadePai",
                optionLabel: key == $scope.niveis.length - 1 ? "Selecione..." : "",
                dataSource: new kendo.data.DataSource({
                    type: "json",
                    transport: {
                        read: function (o) {
                            unidadesService.getByIdNivel(value.id).then(function(response){
                                o.success(response.data)
                            })
                        }
                    }
                }),
            });

        }, $scope.dropDownOptions);

    });

    $scope.$watch('unidadeSelecionada', function (newValue, oldValue) {
        alert(newValue + "-" + oldValue);
    });
            
}]);