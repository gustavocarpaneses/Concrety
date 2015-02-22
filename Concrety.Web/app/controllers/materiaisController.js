'use strict';
app.controller('materiaisController', function ($scope, $routeParams, $sce, unidadesService, niveisService, materiaisService, fornecedoresService) {

    var idNivel = $routeParams.id;

    $scope.mensagem = "";
    
    $scope.unidadeSelecionada = "";

    $scope.niveis = [];
    $scope.dropDownNiveisOptions = [];

    $scope.fichas = [];
    $scope.dropDownFichasOptions = [];

    $scope.fornecedores = [];
    $scope.dropDownFornecedoresOptions = [];
    
    obterNiveis(idNivel);
    obterFichas(idNivel);
    obterFornecedores();

    $scope.$watch('unidadeSelecionada', function (newValue, oldValue) {
        if (!newValue) {
            return;
        }

        CarregarMateriais();
    });

    function CarregarMateriais() {
        var columns = [
                     {
                         command: ["edit"],
                         title: "Ações"
                     },
                    {
                        field: "idFichaVerificacaoMaterial",
                        title: "Material",
                        values: $scope.fichas
                    }, 
                    {
                        field: "dataFicha",
                        title: "Data",
                        format: "{0:dd/MM/yyyy}"
                    },
                    {
                        field: "idFornecedor",
                        title: "Fornecedor",
                        values: $scope.fornecedores
                    },
                    {
                        field: "aprovado",
                        title: "Aprovado",
                        template: '<input type="checkbox" #= aprovado ? "checked=checked" : "" # disabled="disabled" ></input>'
                    }
                    ];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number", defaultValue: 0 },
                dataFicha: { type: "date", defaultValue: new Date() },
                aprovado: { type: "boolean" },
                idFichaVerificacaoMaterial: { type: "number" },
                idFornecedor: { type: "number" }
            }
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    materiaisService.obterDaUnidade($scope.unidadeSelecionada).then(function (response) {
                        o.success(response.data);
                    });
                },
                update: function (o) {
                    PrepararNovoFornecedor(o.data.models[0]);
                    materiaisService.update(o.data.models[0]).then(function (response) {
                        obterFornecedores();
                        o.success(response.data);
                    }, function (response) {
                        ObterErros(response.data);
                    });
                },
                create: function (o) {
                    PrepararNovoFornecedor(o.data.models[0]);
                    o.data.models[0].idUnidade = $scope.unidadeSelecionada;
                    materiaisService.create(o.data.models[0]).then(function (response) {
                        obterFornecedores();
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

        $scope.materiaisGridOptions = {
            dataSource: dataSource,
            sortable: true,
            pageable: {
                refresh: true
            },
            filterable: {
                extra: false
            },
            toolbar: ["create"],
            columns: columns,
            editable: {
                mode: "popup",
                template: kendo.template(angular.element("#editTemplate").html()),
                destroy: false,
                window: {
                    title: "Ficha de Verificação de Material",
                    width: "800px",
                    height: "600px"
                }
            }
        };

    }

    function PrepararNovoFornecedor(fvm) {
        if (isNaN(fvm.idFornecedor)) {
            fvm.nomeNovoFornecedor = fvm.idFornecedor;
            fvm.idFornecedor = 0;
        }
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

    function obterFichas(idNivel) {
        materiaisService.obterDoNivel(idNivel).then(function (response) {

            angular.forEach(response.data, function (ficha, index) {
                this.push({
                    text: ficha.nomeCompleto,
                    value: ficha.id
                });
            }, $scope.fichas);

            $scope.dropDownFichasOptions = {
                dataTextField: "text",
                dataValueField: "value",
                optionLabel: "Selecione...",
                dataSource: new kendo.data.DataSource({
                    type: "json",
                    transport: {
                        read: function (o) {
                            o.success($scope.fichas);
                        }
                    }
                })
            };

        });
    }

    function obterFornecedores() {
        fornecedoresService.get().then(function (response) {

            $scope.fornecedores = [];

            angular.forEach(response.data, function (fornecedor, index) {
                this.push({
                    text: fornecedor.nome,
                    value: fornecedor.id
                });
            }, $scope.fornecedores);

            $scope.dropDownFornecedoresOptions = {
                dataTextField: "text",
                dataValueField: "value",
                placeholder: "Selecione...",
                dataSource: new kendo.data.DataSource({
                    type: "json",
                    transport: {
                        read: function (o) {
                            o.success($scope.fornecedores);
                        }
                    }
                })
            }

        });
    }

    function obterNiveis(idNivel) {
        niveisService.obterNiveisAcima(idNivel).then(function (response) {
            $scope.niveis = response.data;

            angular.forEach($scope.niveis, function (nivel, index) {

                this.push({
                    dataTextField: "nome",
                    dataValueField: "id",
                    cascadeFrom: index == 0 ? "" : "nivel" + (index - 1),
                    cascadeFromField: index == 0 ? "" : "idUnidadePai",
                    optionLabel: index == $scope.niveis.length - 1 && $scope.niveis.length > 1 ? "Selecione..." : "",
                    dataSource: new kendo.data.DataSource({
                        type: "json",
                        transport: {
                            read: function (o) {
                                unidadesService.obterDoNivel(nivel.id).then(function (response) {
                                    o.success(response.data)
                                })
                            }
                        }
                    })
                });

            }, $scope.dropDownNiveisOptions);

        });
    }

});