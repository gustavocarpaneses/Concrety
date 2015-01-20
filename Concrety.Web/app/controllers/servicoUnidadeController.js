﻿'use strict';
app.controller('servicoUnidadeController', function ($scope, $rootScope, $modal, servicosService, servicoUnidadeService) {

    if ($scope.servico.desabilitado) {
        return;
    }
    //Sugestão: se não for atual, setTimeout pra carregar

    $scope.servicoUnidade = [];
    $scope.salvoComSucesso = false;
    $scope.mensagem = "";

    servicoUnidadeService.obter($scope.unidadeSelecionada, $scope.servico.id).then(function (response) {
        $scope.servicoUnidade = response.data;
        LimparDatas();
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

    $scope.salvar = function () {

        if ($scope.servicoUnidade.dataInicio == '') {
            $scope.servicoUnidade.dataInicio = '0001-01-01T00:00:00';
        }

        if ($scope.servicoUnidade.dataFim == '') {
            $scope.servicoUnidade.dataFim = '0001-01-01T00:00:00';
        }

        servicoUnidadeService.salvar($scope.servicoUnidade).then(function (response) {
            LimparDatas();
            $scope.salvoComSucesso = true;
            $scope.mensagem = "Alterações salvas com sucesso.";
            if (response.data.servicoConcluido) {
                $rootScope.$broadcast('servicoConcluidoEvent', []);
            }
        }, function (response) {
            LimparDatas();
            var errors = [];
            for (var key in response.data.modelState) {
                for (var i = 0; i < response.data.modelState[key].length; i++) {
                    errors.push(response.data.modelState[key][i]);
                }
            }
            $scope.mensagem = errors.join(' ');
        });

    };

    $scope.dropDownStatusOptions = {
        dataTextField: "nome",
        dataValueField: "id",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    servicosService.obterPossiveisStatus().then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    };

    $scope.dropDownResultadoOptions = {
        dataTextField: "nome",
        dataValueField: "id",
        optionLabel: "Selecione...",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    servicosService.obterPossiveisResultados().then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    }

    $scope.open = function ($event, datePicker) {
        $event.preventDefault();
        $event.stopPropagation();

        $scope.closeAllDatePickers();
        datePicker.opened = true;
    };

    $scope.closeAllDatePickers = function ($event) {
        $scope.servicoUnidade.dataInicio.opened = false;
        $scope.servicoUnidade.dataFimy.opened = false;
    };

    function LimparDatas() {
        if ($scope.servicoUnidade.dataInicio == '0001-01-01T00:00:00') {
            $scope.servicoUnidade.dataInicio = '';
        }
        if ($scope.servicoUnidade.dataFim == '0001-01-01T00:00:00') {
            $scope.servicoUnidade.dataFim = '';
        }
    }
        
});