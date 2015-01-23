'use strict';
app.controller('diarioObraController', function ($scope, $http, diarioObraService, accountService) {

    //var crudServiceBaseUrl = "http://demos.telerik.com/kendo-ui/service",
    //    dataSource = new kendo.data.DataSource({
    //        transport: {
    //            read: {
    //                url: crudServiceBaseUrl + "/Products",
    //                dataType: "jsonp"
    //            },
    //            update: {
    //                url: crudServiceBaseUrl + "/Products/Update",
    //                dataType: "jsonp"
    //            },
    //            destroy: {
    //                url: crudServiceBaseUrl + "/Products/Destroy",
    //                dataType: "jsonp"
    //            },
    //            create: {
    //                url: crudServiceBaseUrl + "/Products/Create",
    //                dataType: "jsonp"
    //            },
    //            parameterMap: function (options, operation) {
    //                if (operation !== "read" && options.models) {
    //                    return { models: kendo.stringify(options.models) };
    //                }
    //            }
    //        },
    //        batch: true,
    //        pageSize: 20,
    //        schema: {
    //            model: {
    //                id: "ProductID",
    //                fields: {
    //                    ProductID: { editable: false, nullable: true },
    //                    ProductName: { validation: { required: true } },
    //                    UnitPrice: { type: "number", validation: { required: true, min: 1 } },
    //                    Discontinued: { type: "boolean" },
    //                    UnitsInStock: { type: "number", validation: { min: 0, required: true } }
    //                }
    //            }
    //        }
    //    });



    $scope.empreendimentoAtual = accountService.empreendimentoAtual;

    var columns = [
            { field: "data", title: "Data" },
            { field: "houveTrabalho", title: "Houve Trabalho?" },
            { field: "temperaturaMinima", title: "Temperatura Mínima" },
            { field: "temperaturaMaxima", title: "Temperatura Máxima" },
            { command: ["edit"], title: "&nbsp;", width: "250px" }];

    var model = {
        id: "id",
        fields: {
            id: { editable: false, nullable: true },
            //idEmpreendimento: { visible: false },
            houveTrabalho: { type: "boolean", validation: { required: true } },
            temperaturaMinima: { type: "number", validation: { required: true, min: 1 } },
            temperaturaMaxima: { type: "number", validation: { required: true, min: 1 } },
            data: { type: "date", validation: { required: true } }
        }
    };

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
        //batch: true,
        pageSize: 10,
        schema: {
            model: model
        }
    });


    //$scope.diariosObraGridOptions = {
    //    dataSource: dataSource,
    //    pageable: true,
    //    height: 550,
    //    toolbar: ["create"],
    //    columns: [
    //        { field: "ProductName", title: "Product Name" },
    //        { field: "UnitPrice", title: "Unit Price", format: "{0:c}", width: "120px" },
    //        { field: "UnitsInStock", title: "Units In Stock", width: "120px" },
    //        { field: "Discontinued", width: "120px" },
    //        { command: ["edit", "destroy"], title: "&nbsp;", width: "250px" }],
    //    editable: "popup"
    //};

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