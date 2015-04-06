﻿'use strict';
app.controller('diarioObraController', function ($scope, $q, $http, $modal, diariosObraService, periodosDiariosObraService, condicoesClimaticasService, accountService) {

    $scope.mensagem = "";
    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

    $scope.condicoesClimaticas = [];
    $scope.dropDownCondicoesClimaticasOptions = [];

    $scope.optionsTemperatura = {
        decimals: 0,
        spinners: false,
        min: -50,
        max: 50,
        format: "#"
    };

    $scope.optionsHoras = {
        decimals: 0,
        spinners: false,
        min: 0,
        max: 23,
        format: "#"
    };

    $scope.optionsTotais = {
        decimals: 0,
        spinners: false,
        min: 0,
        format: "#"
    };

    obterCondicoesClimaticas().then(function () {
        obterPeriodosDiarioObra().then(function (periodos) {
            configurarGrid(periodos);
        });
    });

    function configurarGrid(periodos) {

        var columns = [
                {
                    command: ["edit"],
                    title: "Ações"
                },
                {
                    field: "dataDiario",
                    title: "Data",
                    format: "{0:dd/MM/yyyy}"
                },
                {
                    field: "houveTrabalho",
                    title: "Houve Trabalho?",
                    template: '#= houveTrabalho() #'
                //},
                //{
                //    field: "temperaturaMinima",
                //    title: "Temp. Mínima"
                //},
                //{
                //    field: "temperaturaMaxima",
                //    title: "Temp. Máxima"
                //},
                //{
                //    field: "idCondicaoClimatica",
                //    title: "Condição Climática",
                //    values: $scope.condicoesClimaticas
                },
                {
                    field: "efetivoTotal",
                    title: "Efetivo Total",
                    template: "#= efetivoTotal() #"
                }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number", defaultValue: 0 },
                dataDiario: { type: "date", defaultValue: new Date() },
                diariosPeriodos: { defaultValue: periodos }
            },
            houveTrabalho: function() {
                var houveTrabalho = "";
                var periodos = this.get("diariosPeriodos");

                for (var i = 0; i < periodos.length; i++) {
                    if (periodos[i].get("houveTrabalho")) {
                        houveTrabalho += periodos[i].empreendimentoPeriodo.nome + ", ";
                    }
                }

                if (houveTrabalho) {
                    houveTrabalho = houveTrabalho.substring(0, houveTrabalho.length - 2);
                }
                else {
                    houveTrabalho = "Não";
                }

                return houveTrabalho;
            },
            efetivoTotal: function () {

                var total = 0;
                var periodos = this.get("diariosPeriodos");

                for(var i=0; i<periodos.length; i++)
                {
                    total += periodos[i].get("totalMontadores") + periodos[i].get("totalArmadores") + periodos[i].get("totalCarpinteiros") + 
                        periodos[i].get("totalEletricistas") + periodos[i].get("totalEncanadores") + periodos[i].get("totalEncarregados") + 
                        periodos[i].get("totalMestres") + periodos[i].get("totalAjudantes") + periodos[i].get("totalPedreiros");
                }

                return total;
            }
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    diariosObraService.get($scope.empreendimentoAtual.id).then(function (response) {
                        o.success(response.data);
                    });
                },
                update: function (o) {
                    diariosObraService.update(o.data.models[0]).then(function (response) {
                        $scope.mensagem = '';
                        o.success(response.data);
                    }, function (response) {
                        ObterErros(response.data);
                    });
                },
                create: function (o) {
                    o.data.models[0].idEmpreendimento = $scope.empreendimentoAtual.id;
                    diariosObraService.create(o.data.models[0]).then(function (response) {
                        $scope.mensagem = '';
                        o.success(response.data);
                    }, function (response) {
                        ObterErros(response.data);
                    });
                }
            },
            batch: true,
            pageSize: 10,
            schema: {
                model: model
            }
        });

        $scope.diariosObraGridOptions = {
            dataSource: dataSource,
            sortable: true,
            pageable: {
                refresh: true
            },
            filterable: {
                extra: false
            },
            toolbar: kendo.template(angular.element("#toolbarTemplate").html()),
            columns: columns,
            editable: {
                mode: "popup",
                template: kendo.template(angular.element("#editTemplate").html()),
                destroy: true,
                window: {
                    title: "Diário da Obra",
                    width: "800px",
                    height: "600px"
                }
            },
        };
    }

    function ObterErros(data) {
        var errors = [];
        for (var key in data.modelState) {
            for (var i = 0; i < data.modelState[key].length; i++) {
                errors.push(data.modelState[key][i]);
            }
        }
        $scope.mensagem = errors.join(' ');
    }

    function condicaoClimaticaFilter(element) {
        element.kendoDropDownList($scope.dropDownCondicoesClimaticasOptions);
    }
    
    function obterCondicoesClimaticas() {

        var deferred = $q.defer();

        condicoesClimaticasService.get().then(function (response) {

            angular.forEach(response.data, function (condicaoClimatica, index) {
                this.push({
                    text: condicaoClimatica.descricao,
                    value: condicaoClimatica.id
                });
            }, $scope.condicoesClimaticas);

            $scope.dropDownCondicoesClimaticasOptions = {
                dataTextField: "text",
                dataValueField: "value",
                optionLabel: "Selecione...",
                dataSource: new kendo.data.DataSource({
                    type: "json",
                    transport: {
                        read: function (o) {
                            o.success($scope.condicoesClimaticas);
                        }
                    }
                })
            };

            deferred.resolve();

        });

        return deferred.promise;

    }

    function obterPeriodosDiarioObra() {
        var deferred = $q.defer();

        periodosDiariosObraService.get($scope.empreendimentoAtual.id).then(function (response) {
            deferred.resolve(response.data);
        });

        return deferred.promise;
    }

    $scope.gerarRelatorio = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/relatorios/diarioObra.html?v=' + new Date(),
            controller: 'relatoriosDiarioObraController',
            size: 'lg',
            resolve: {
                diariosObra: function () {
                    var dataSource = $scope.diariosObraGrid.dataSource;
                    var filters = dataSource.filter();
                    var allData = dataSource.data();
                    var query = new kendo.data.Query(allData);
                    return query.filter(filters).data;
                },
                condicoesClimaticas: function () {
                    return $scope.condicoesClimaticas;
                }
            }
        });
    };

});