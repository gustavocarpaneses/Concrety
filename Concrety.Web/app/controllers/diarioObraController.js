'use strict';
app.controller('diarioObraController', function ($scope, $http, diarioObraService, accountService) {
    
    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

    var columns = [
            { field: "id", title: "Id" },
            { field: "data", title: "Data" },
            { field: "houveTrabalho", title: "Houve Trabalho?" },
            { field: "temperaturaMinima", title: "Temperatura Mínima" },
            { field: "temperaturaMaxima", title: "Temperatura Máxima" },
            { command: ["edit"], title: "&nbsp;", width: "250px" }];

    var model = kendo.data.Model.define({
        id: "id",
        fields: {
            id: { type: "number", editable: false, nullable: true },
            houveTrabalho: { type: "boolean", validation: { required: true } },
            temperaturaMinima: { type: "number", validation: { required: true, min: 1 } },
            temperaturaMaxima: { type: "number", validation: { required: true, min: 1 } },
            data: { type: "date", validation: { required: true } }
        }
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
                });
            },
            create: function (o) {
                o.data.models[0].idEmpreendimento = $scope.empreendimentoAtual.id;
                diarioObraService.create(o.data.models[0]).then(function (response) {
                    o.success(response.data);
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
        pageable: true,
        height: 550,
        toolbar: ["create"],
        columns: columns,
        editable: {
            mode: "popup",
            update: true,
            destroy: false,
            window: {
                title: "Editar"
            }
        },
    };

});