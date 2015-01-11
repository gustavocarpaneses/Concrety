'use strict';
app.controller('servicosController', ['$scope', '$routeParams', 'unidadesService', 'niveisService', function ($scope, $routeParams, unidadesService, niveisService) {

    var idNivel = $routeParams.id;

    $scope.dropDownOptions = [];

    niveisService.getNiveisAcima(idNivel).then(function (response) {
        $scope.niveis = response.data;

        angular.forEach($scope.niveis, function(value, key){

            this.push({
                dataTextField: "nome",
                dataValueField: "id",
                cascadeFrom: key == 0 ? "" : "nivel" + (key - 1),
                cascadeFromField: key == 0 ? "" : "idUnidadePai",
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
            
}]);