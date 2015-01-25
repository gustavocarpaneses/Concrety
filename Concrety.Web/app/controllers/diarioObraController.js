'use strict';
app.controller('diarioObraController', function ($scope, $http, diarioObraService, condicaoClimaticaService, accountService) {

    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

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
        //format: "00':'00"
    };

    $scope.optionsTotais = {
        decimals: 0,
        spinners: false,
        min: 0,
        format: "#"
    };

    $scope.dropDownCondicoesClimaticasOptions = {
        dataTextField: "text",
        dataValueField: "value",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    condicaoClimaticaService.get().then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    };

    //condicaoClimaticaService.get().then(function (response) {

        var columns = [
                { field: "data", title: "Data", format: "{0:d}" },
                { field: "houveTrabalho", title: "Houve Trabalho?" },
                { field: "temperaturaMinima", title: "Temperatura Mínima" },
                { field: "temperaturaMaxima", title: "Temperatura Máxima" },
                { field: "textoCondicaoClimatica", title: "Condição Climática" },
                { field: "efetivoTotal", title: "Efetivo Total" },
                { command: ["edit"], title: "&nbsp;" }];

        var model = kendo.data.Model.define({
            id: "id",
            //fields: {
                //id: { type: "number", editable: false, nullable: true },
                //data: { type: "date", defaultValue: new Date() },
                //houveTrabalho: { type: "boolean" },
                //temperaturaMinima: { type: "number", validation: {} },
                //temperaturaMaxima: { type: "number", validation: {} },
                //efetivoTotal: { type: "number", editable: false },
                //idCondicaoClimatica: { type: "number", defaultValue: 1, field: "idCondicaoClimatica", validation: { required: true } },
                //horasTrabalhadas: { type: "number", validation: { min: 0 } },
                //horasParadas: { type: "number", validation: { min: 0 } },
                //servicosExecutados: { type: "string", validation: {} },
                //totalMontadores: { type: "number", validation: { min: 0 } },
                //totalArmadores: { type: "number", validation: { min: 0 } },
                //totalCarpinteiros: { type: "number", validation: { min: 0 } },
                //totalEletricistas: { type: "number", validation: { min: 0 } },
                //totalEncarregados: { type: "number", validation: { min: 0 } },
                //totalEncanadores: { type: "number", validation: { min: 0 } },
                //totalMestres: { type: "number", validation: { min: 0 } },
                //totalAjudantes: { type: "number", validation: { min: 0 } },
                //totalPedreiros: { type: "number", validation: { min: 0 } },
                //totalFaltas: { type: "number", validation: { min: 0 } },
                //totalAcidentados: { type: "number", validation: { min: 0 } },
                //totalNovosFuncionarios: { type: "number", validation: { min: 0 } },
                //totalDoentes: { type: "number", validation: { min: 0 } },
                //totalDemitidos: { type: "number", validation: { min: 0 } }
            //}
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (options) {
                    diarioObraService.get($scope.empreendimentoAtual.id).then(function (response) {
                        options.success(response.data);
                    });
                },
                update: function (o) {
                    diarioObraService.update(o.data.models[0]).then(function (response) {
                        o.success(response.data);
                    }, function (response) {
                        o.errors(response.data);
                    });
                },
                create: function (o) {
                    o.data.models[0].idEmpreendimento = $scope.empreendimentoAtual.id;
                    diarioObraService.create(o.data.models[0]).then(function (response) {
                        o.success(response.data);
                    }, function (response) {
                        o.errors(response.data);
                    });
                }
            },
            batch: true,
            pageSize: 10,
            schema: {
                model: model,
                //parse: function (response) {
                //    $.each(response, function (idx, elem) {
                //        if (elem.data && typeof elem.data === "string") {
                //            elem.data = kendo.parseDate(elem.data);
                //        }
                //    });
                //    return response;
                //}
            }
        });

        $scope.diariosObraGridOptions = {
            dataSource: dataSource,
            sortable: true,
            pageable: true,
            filterable: true,
            toolbar: ["create"],
            columns: columns,
            editable: {
                mode: "popup",
                template: kendo.template(angular.element("#editTemplate").html()),
                destroy: false,
                window: {
                    title: "Diário da Obra",
                    width: "800px",
                    height: "600px"
                }
            },
        };

    //});

});