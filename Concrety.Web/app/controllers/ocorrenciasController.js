'use strict';
app.controller('ocorrenciasController', function ($scope, $modalInstance, ocorrencia, ocorrenciasService, patologiasService) {

    $scope.patologias = [];
    $scope.ocorrencia = ocorrencia;

    $scope.salvoComSucesso = false;
    $scope.mensagem = "";

    $scope.isNew = function () {
        return !$scope.ocorrencia.id;
    }

    $scope.dropDownPatologiasOptions = [];

    $scope.dropDownStatusOptions = {
        dataTextField: "nome",
        dataValueField: "id",
        dataSource: new kendo.data.DataSource({
            type: "json",
            transport: {
                read: function (o) {
                    ocorrenciasService.obterPossiveisStatus().then(function (response) {
                        o.success(response.data)
                    })
                }
            }
        })
    };

    var idItemVerificacaoServico = $scope.ocorrencia.itemVerificacao.idItemVerificacaoServico;

    patologiasService.obter(idItemVerificacaoServico).then(function (response) {
        $scope.patologias = response.data;

        $scope.dropDownPatologiasOptions = {
            dataTextField: "nome",
            dataValueField: "id",
            optionLabel: "Selecione...",
            dataSource: new kendo.data.DataSource({
                type: "json",
                transport: {
                    read: function (o) {
                        o.success($scope.patologias);
                    }
                }
            })
        };
    });

    $scope.$watch('ocorrencia.idPatologia', function (newValue, oldValue) {
        if (!newValue) {
            return;
        }

        for (var i = 0; i < $scope.patologias.length; i++) {

            if ($scope.patologias[i].id == $scope.ocorrencia.idPatologia) {
                $scope.ocorrencia.patologia = $scope.patologias[i];
                break;
            }

        }

    });

    $scope.fechar = function () {
        $modalInstance.close();
    };

    $scope.salvar = function () {
        if ($scope.isNew()) {
            ocorrenciasService.create($scope.ocorrencia).then(function (response) {
                $scope.salvoComSucesso = true;
                $scope.mensagem = "Ocorrência criada com sucesso.";
            }, function (response) {
                var errors = [];
                for (var key in response.data.modelState) {
                    for (var i = 0; i < response.data.modelState[key].length; i++) {
                        errors.push(response.data.modelState[key][i]);
                    }
                }
                $scope.mensagem = errors.join(' ');
            });
        }
        else {
            ocorrenciasService.update($scope.ocorrencia);
        }
    };

});