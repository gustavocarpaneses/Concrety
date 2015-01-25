'use strict';
app.controller('materiaisController', function ($scope, $routeParams, unidadesService, niveisService, materiaisService, fornecedoresService) {

    var idNivel = $routeParams.id;

    $scope.dropDownOptions = [];
    $scope.unidadeSelecionada = '';
    $scope.materiaisDaUnidade = [];

    $scope.dropDownFichasOptions = {
        dataTextField: "nomeCompleto",
        dataValueField: "id",
        optionLabel: "Selecione...",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    var idNivel = $scope.niveis[$scope.niveis.length - 1].id;
                    materiaisService.obterDoNivel(idNivel).then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    };

    $scope.dropDownFornecedoresOptions = {
        dataTextField: "nome",
        dataValueField: "id",
        optionLabel: "Selecione...",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    fornecedoresService.get().then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    }

    niveisService.obterNiveisAcima(idNivel).then(function (response) {
        $scope.niveis = response.data;

        angular.forEach($scope.niveis, function(nivel, index){

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

        }, $scope.dropDownOptions);

    });

    $scope.$watch('unidadeSelecionada', function (newValue, oldValue) {
        if (!newValue) {
            return;
        }

        CarregarMateriais();
    });

    function CarregarMateriais() {
        var idUnidade = $scope.unidadeSelecionada;
        var idNivel = $scope.niveis[$scope.niveis.length - 1].id;

        var columns = [
                    {
                        field: "fichaVerificacaoMaterial",
                        title: "Material"
                    },
                    {
                        field: "data",
                        title: "Data",
                        format: "{0:d}"
                    },
                    {
                        field: "fornecedor",
                        title: "Fornecedor"
                    },
                    {
                        field: "aprovado",
                        title: "Aprovado",
                        template: '<input type="checkbox" #= aprovado ? "checked=checked" : "" # disabled="disabled" ></input>'
                    },
                    {
                        command: ["edit"],
                        title: "&nbsp;"
                    }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                data: { type: "date" },
                aprovado: { type: "boolean" }
            }
        });

        var dataSource = new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    materiaisService.obterDaUnidade(idUnidade).then(function (response) {
                        o.success(response.data);
                    });
                },
                update: function (o) {
                    materiaisService.update(o.data.models[0]).then(function (response) {
                        o.success(response.data);
                    }, function (response) {
                        ObterErros(response.data);
                    });
                },
                create: function (o) {
                    materiaisService.create(o.data.models[0]).then(function (response) {
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
            pageable: true,
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

});