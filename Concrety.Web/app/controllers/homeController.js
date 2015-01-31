'use strict';
app.controller('homeController', function ($scope, $location, $modal, authService, accountService, ocorrenciasService) {

    if (!authService.authentication.isAuth) {
        $location.path('/login');
    }

    configurarGridOcorrencias();

    function editarOcorrencia(e) {
        e.preventDefault();

        var ocorrencia = this.dataItem(angular.element(e.currentTarget).closest("tr"));

        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalOcorrencia.html',
            controller: 'ocorrenciasController',
            size: 'lg',
            resolve: {
                ocorrencia: function () {
                    return ocorrencia;
                }
            }
        });

        modalInstance.result.then(function (ocorrencia) {
            $scope.ocorrenciasGrid.refresh();
        });
    }

    function configurarGridOcorrencias() {


        var columns = [
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
                    field: "dataConclusao",
                    title: "Data Conclusão",
                    format: "{0:dd/MM/yyyy}"
                },
                {
                    field: "descricaoStatus",
                    title: "Status"
                },
                {
                    field: "nomePatologia",
                    title: "Patologia"
                },
                {
                    command: [{
                        text: "Editar",
                        //template: '<a class="k-button k-button-icontext k-grid-edit"><span class="k-icon k-edit"></span>Editar</a>',
                        click: editarOcorrencia
                    }],
                    title: "&nbsp;"
                }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number" },
                nomeUnidade: { type: "string" },
                nomeFichaVerificacaoServico: { type: "string" },
                nomeItemVerificacaoServico: { type: "string" },
                dataAbertura: { type: "date" },
                dataConclusao: { type: "date" },
                descricaoStatus: { type: "string" },
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



});