'use strict';
app.controller('servicoUnidadeController', function ($scope, $modal, servicoUnidadeService) {

    if ($scope.servico.desabilitado) {
        return;
    }
    //Sugestão: se não for atual, setTimeout pra carregar

    servicoUnidadeService.obter($scope.unidadeSelecionada, $scope.servico.id).then(function (response) {
        $scope.servicoUnidade = response.data;
    });
    
    $scope.abrirModalNorma = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalNorma.html',
            controller: 'modalNormasController',
            resolve: {
                servico: function () {
                    return $scope.servico;
                }
            }
        });
    };

    $scope.dataOptions = {
        culture: 'pt-BR'
    };

    $scope.$watch('servicoUnidade.testeDataInicio', function (newValue, oldValue) {

        var start = $scope.dataInicioPicker;
        var end = $scope.dataConclusaoPicker;

        if (!start || !end) {
            return;
        }

        var startDate = start.value(),
        endDate = end.value();

        if (startDate) {
            startDate = new Date(startDate);
            startDate.setDate(startDate.getDate());
            end.min(startDate);
        } else if (endDate) {
            start.max(new Date(endDate));
        } else {
            endDate = new Date();
            start.max(endDate);
            end.min(endDate);
        }
    });

    $scope.$watch('servicoUnidade.testeDataConclusao', function (newValue, oldValue) {

        var start = $scope.dataInicioPicker;
        var end = $scope.dataConclusaoPicker;

        if (!start || !end) {
            return;
        }

        var endDate = end.value(),
        startDate = start.value();

        if (endDate) {
            endDate = new Date(endDate);
            endDate.setDate(endDate.getDate());
            start.max(endDate);
        } else if (startDate) {
            end.min(new Date(startDate));
        } else {
            endDate = new Date();
            start.max(endDate);
            end.min(endDate);
        }
    });

});