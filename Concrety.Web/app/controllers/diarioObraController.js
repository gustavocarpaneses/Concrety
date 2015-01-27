'use strict';
app.controller('diarioObraController', function ($scope, $q, $http, diariosObraService, condicoesClimaticasService, accountService) {

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
        configurarGrid();
    });

    function configurarGrid() {

        var columns = [
                {
                    field: "dataDiario",
                    title: "Data",
                    format: "{0:dd/MM/yyyy}"
                },
                {
                    field: "houveTrabalho",
                    title: "Houve Trabalho?",
                    template: '<input type="checkbox" #= houveTrabalho ? "checked=checked" : "" # disabled="disabled" ></input>'
                },
                {
                    field: "temperaturaMinima",
                    title: "Temperatura Mínima"
                },
                {
                    field: "temperaturaMaxima",
                    title: "Temperatura Máxima"
                },
                {
                    field: "idCondicaoClimatica",
                    title: "Condição Climática",
                    values: $scope.condicoesClimaticas
                },
                {
                    field: "efetivoTotal",
                    title: "Efetivo Total",
                    template: "#= efetivoTotal() #"
                },
                {
                    command: ["edit"],
                    title: "&nbsp;"
                }];

        var model = kendo.data.Model.define({
            id: "id",
            fields: {
                id: { type: "number", defaultValue: 0 },
                dataDiario: { type: "date" },
                houveTrabalho: { type: "boolean" },
                temperaturaMinima: { type: "number" },
                temperaturaMaxima: { type: "number" },
                idCondicaoClimatica: { type: "number" }
            },
            efetivoTotal: function () {
                return this.get("totalMontadores") + this.get("totalArmadores") + this.get("totalCarpinteiros") + this.get("totalEletricistas")
                + this.get("totalEncanadores") + this.get("totalEncarregados") + this.get("totalMestres") + this.get("totalAjudantes") + this.get("totalPedreiros");
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
                        o.success(response.data);
                    }, function (response) {
                        ObterErros(response.data);
                    });
                },
                create: function (o) {
                    o.data.models[0].idEmpreendimento = $scope.empreendimentoAtual.id;
                    diariosObraService.create(o.data.models[0]).then(function (response) {
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

});