'use strict';
app.controller('diarioObraController', function ($scope, diarioObraService, accountService) {

    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

    var columns = [
        { field: "data", title: "Data" },
        { field: "houveTrabalho", title: "Houve Trabalho?" },
        { field: "temperaturaMinima", title: "Temperatura Mínima" },
        { field: "temperaturaMaxima", title: "Temperatura Máxima" },
        { command: ["edit", "destroy"], title: "&nbsp;", width: "250px" }];

    var model = {
        id: "id",
        fields: {
            id: { editable: false, nullable: true },
            houveTrabalho: { type: "boolean", validation: { required: true } },
            temperaturaMinima: { type: "number", validation: { required: true, min: 1 } },
            temperaturaMaxima: { type: "number", validation: { required: true, min: 1 } },
            data: { type: "date", validation: { required: true } }
        }
    };

    $scope.diariosObraGridOptions = {
        dataSource: {
            type: "json",
            transport: {
                read: function (o) {
                    diarioObraService.get($scope.empreendimentoAtual.id).then(function (response) {
                        o.success(response.data)
                    })
                },
                update: function (o) {
                    diarioObraService.update(o.data.models).then(function (response) {
                        o.success(response.data)
                    })
                },
                create: function (o) {
                    diarioObraService.create(o.data.models).then(function (response) {
                        o.success(response.data)
                    })
                },
                parameterMap: function (options, operation) {
                    if (operation !== "read" && options.models) {
                        return { models: kendo.stringify(options.models) };
                    }
                }
            },
            batch: true,
            pageSize: 10,
            schema: {
                model: model
            }
        },
        sortable: true,
        pageable: true,
        toolbar: ["create"],
        editable: {
            mode: "popup"
        },
        columns: columns
    };

});