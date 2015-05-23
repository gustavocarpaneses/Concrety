'use strict';
app.controller('servicoUnidadeController', function ($scope, $rootScope, $modal, servicosService, servicoUnidadeService, ocorrenciasService) {

    //if ($scope.servico.desabilitado) {
    //    return;
    //}
    //Sugestão: se não for atual, setTimeout pra carregar

    $scope.servicoUnidade = [];
    $scope.ocorrenciasGridOptions = [];
    $scope.salvoComSucesso = false;
    $scope.mensagem = "";
    
    ocorrenciasService.obterPossiveisStatus().then(function (response) {

        $scope.possiveisStatusOcorrencias = [];

        angular.forEach(response.data, function (status, index) {
            this.push({
                text: status.nome,
                value: status.id
            });
        }, $scope.possiveisStatusOcorrencias);

        servicoUnidadeService.obter($scope.unidadeSelecionada, $scope.servico.id).then(function (response) {
            $scope.servicoUnidade = response.data;
            LimparDatas();
            configurarGridOcorrencias();
        });

    });
    
    $scope.abrirModalNorma = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalNorma.html?v=' + new Date(),
            controller: 'modalNormasController',
            size: 'lg',
            resolve: {
                servico: function () {
                    return $scope.servico;
                }
            }
        });
    };

    $scope.novaOcorrencia = function (itemVerificacao) {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalOcorrencia.html?v=' + new Date(),
            controller: 'ocorrenciasController',
            size: 'lg',
            resolve: {
                ocorrencia: function () {
                    return obterNovaOcorrencia(itemVerificacao);
                }
            }
        });

        modalInstance.result.then(function (ocorrencia) {
            itemVerificacao.quantidadeOcorrencias++;
            angular.element("#grid_ocorrencias").data("kendoGrid").dataSource.read();
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
            if(response.data.modelState){
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
            }
            else{
                errors.push("Ocorreu um erro ao salvar os dados. Por favor, verifique se todos os campos estão preenchidos corretamente e tente novamente. Caso o erro persista, entre em contato conosco através da ferramenta de feedback (localizada no canto superior direito).");
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
        $scope.servicoUnidade.dataFim.opened = false;
    };

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

    function LimparDatas() {
        if ($scope.servicoUnidade.dataInicio == '0001-01-01T00:00:00') {
            $scope.servicoUnidade.dataInicio = '';
        }
        if ($scope.servicoUnidade.dataFim == '0001-01-01T00:00:00') {
            $scope.servicoUnidade.dataFim = '';
        }
    }


    function obterNovaOcorrencia(itemVerificacao) {
        return {
            id: 0,
            descricao: '',
            dataAbertura: new Date(),
            dataConclusao: '',
            nomeUnidade: obterNomeUnidadeSelecionada(),
            status: 10,
            itemVerificacao: itemVerificacao,
            idItemVerificacaoUnidade: itemVerificacao.id,
            anexos: []
        };
    }

    function obterNomeUnidadeSelecionada() {
        var nomeUnidadeSelecionada = '';
        angular.forEach($scope.niveis[1], function (nivel, index) {
            if (index === $scope.niveis.length - 1) {
                nomeUnidadeSelecionada += nivel.nome;
            } else {
                nomeUnidadeSelecionada += nivel.nome + ' - ';
            }
        });
        return nomeUnidadeSelecionada;
    }

    function excluirOcorrencia(e) {
        e.preventDefault();

        if (confirm("Deseja realmente excluir esse registro?")) {
            var ocorrencia = this.dataItem(angular.element(e.currentTarget).closest("tr"));
            ocorrenciasService.delete(ocorrencia).then(function (response) {
                angular.element("#grid_ocorrencias").data("kendoGrid").dataSource.remove(ocorrencia);
            }, function (response) {
                alert("Ocorreu um erro ao excluir o registro. Por favor, tente novamente. Caso o erro persista, entre em contato conosco através da ferramenta de feedback (localizada no canto superior direito).");
            });
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
                    }, {
                        name: "edit",
                        iconClass: "glyphicon glyphicon-pencil",
                        text: "",
                        click: editarOcorrencia
                    }, {
                        name: "delete",
                        iconClass: "glyphicon glyphicon-trash",
                        text: "",
                        click: excluirOcorrencia
                    }],
                    title: "Ações"
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
                    field: "status",
                    title: "Status",
                    values: $scope.possiveisStatusOcorrencias
                },
                {
                    field: "nomePatologia",
                    title: "Patologia"
                }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number" },
                nomeFichaVerificacaoServico: { type: "string" },
                nomeItemVerificacaoServico: { type: "string" },
                nomeUnidade: {type: "string"},
                dataAbertura: { type: "date" },
                dataConclusao: { type: "date" },
                status: { type: "number" },
                nomePatologia: { type: "string" }
            }
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    ocorrenciasService.obterDoServicoUnidade($scope.servicoUnidade.id).then(function (response) {
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