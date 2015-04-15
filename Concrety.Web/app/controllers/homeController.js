'use strict';
app.controller('homeController', function ($scope, $location, $modal, authService, accountService, ocorrenciasService) {

    if (!authService.authentication.isAuth) {
        $location.path('/login');
    }

    configurarGridOcorrencias();

    configurarGraficos();
    
    function editarOcorrencia(e) {
        e.preventDefault();

        var ocorrencia = this.dataItem(angular.element(e.currentTarget).closest("tr"));

        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalOcorrencia.html?v=' + new Date(),
            controller: 'ocorrenciasController',
            size: 'lg',
            resolve: {
                ocorrencia: function () {
                    return ocorrencia;
                }
            }
        });

        modalInstance.result.then(function (ocorrencia) {
            angular.element("#grid_ocorrencias").data("kendoGrid").dataSource.read();
        });
    }

    function excluirOcorrencia(e) {
        e.preventDefault();

        if (confirm("Deseja realmente excluir esse registro?")) {
            var ocorrencia = this.dataItem(angular.element(e.currentTarget).closest("tr"));
            ocorrenciasService.delete(ocorrencia);
            angular.element("#grid_ocorrencias").data("kendoGrid").dataSource.remove(ocorrencia);
        }
    }

    function configurarGridOcorrencias() {


        var columns = [
                {
                     command: [{
                         name: "view",
                         iconClass: "glyphicon glyphicon-search",
                         text: "",
                         click: editarOcorrencia
                },{
                    name: "edit",
                    iconClass: "glyphicon glyphicon-pencil",
                    text: "",
                    click: editarOcorrencia
                },{
                    name: "delete",
                    iconClass: "glyphicon glyphicon-trash",
                    text: "",
                    click: excluirOcorrencia
                }],
                title: "Ações"
                },
                {
                    field: "nomeUnidade",
                    title: "Unidade"
                },
                {
                    field: "nomeFichaVerificacaoServico",
                    title: "FVS"
                },
                {
                    field: "nomeItemVerificacaoServico",
                    title: "Item"
                },
                {
                    field: "dataAbertura",
                    title: "Data Abertura",
                    format: "{0:dd/MM/yyyy}"
                },
                {
                    field: "nomePatologia",
                    title: "Patologia"
                }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number" },
                nomeUnidade: { type: "string" },
                nomeFichaVerificacaoServico: { type: "string" },
                nomeItemVerificacaoServico: { type: "string" },
                dataAbertura: { type: "date" },
                nomePatologia: { type: "string" }
            }
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    ocorrenciasService.obterPendentes(accountService.macroServicoAtual.id).then(function (response) {
                        o.success(response.data);
                    });
                }
            },
            pageSize: 10,
            schema: {
                model: model
            }
        });

        $scope.ocorrenciasGridOptions = {
            dataSource: dataSource,
            sortable: true,
            pageable: {
                refresh: true
            },
            filterable: {
                extra: false
            },
            columns: columns
        };

    }

    function configurarGraficos() {

        configurarGraficoCondicoesClimaticas();

    }

    function configurarGraficoCondicoesClimaticas() {

    }

});