'use strict';
app.controller('ocorrenciasController', function ($scope, $timeout, $modal, $modalInstance, ocorrencia, ocorrenciasService, patologiasService, concretySettings, localStorageService, accountService) {

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
        $modalInstance.dismiss();
    };

    $scope.salvar = function () {
        if ($scope.isNew()) {
            ocorrenciasService.create($scope.ocorrencia).then(salvoSucesso, erroSalvar);
        }
        else {
            ocorrenciasService.update($scope.ocorrencia).then(salvoSucesso, erroSalvar);
        }
    };

    $scope.anexoSelecionado = function (e) {
        
        angular.forEach(e.files, function (anexo, index) {

            var filtro = /^(.bmp|.gif|.jpg|.jpeg|.png|.tiff)$/i;
            if (!filtro.test(anexo.extension)) {
                $scope.mensagem = "Por favor, selecione apenas anexos de imagem (bmp, gif, jpg, jpeg, png ou tiff)";
                e.preventDefault();
            }
        });
    };

    $scope.uploadIniciado = function (e) {

        var saveUrl = concretySettings.apiServiceBaseUri + 'api/anexos/create';
        e.sender.options.async.saveUrl = saveUrl + "?idObra=" + accountService.empreendimentoAtual.id;

        var xhr = e.XMLHttpRequest;
        if (xhr) {
            xhr.addEventListener("readystatechange", function (e) {
                if (xhr.readyState == 1 /* OPENED */) {
                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        xhr.setRequestHeader("Authorization", 'Bearer ' + authData.token);
                    }
                }
            });
        }
    };

    $scope.uploadConcluido = function (e) {
        if (e.operation == "upload") {
            $scope.ocorrencia.anexos.push({
                idOcorrencia: $scope.ocorrencia.id,
                anexo: e.response,
                idAnexo: e.response.id
            });
            $scope.$apply();
        }
    };

    $scope.excluirAnexo = function (ocorrenciaAnexo) {
        $scope.ocorrencia.anexos.remove(ocorrenciaAnexo);
        ocorrenciaAnexo.anexo.idObra = accountService.empreendimentoAtual.id;
        ocorrenciasService.removerAnexo(ocorrenciaAnexo);
    };

    $scope.abrirModalNorma = function () {
        var modalInstance = $modal.open({
            templateUrl: '/app/partials/modalNorma.html?v=' + new Date(),
            controller: 'modalNormasController',
            size: 'lg',
            resolve: {
                servico: function () {
                    return $scope.ocorrencia.patologia.solucoes[0];
                }
            }
        });
    };

    function salvoSucesso(response) {
        $scope.salvoComSucesso = true;
        if ($scope.isNew()) {
            $scope.mensagem = "Ocorrência criada com sucesso.";
        }
        else {
            $scope.mensagem = "Ocorrência atualizada com sucesso.";
        }

        $timeout(function () {
            $modalInstance.close($scope.ocorrencia);
        }, 1000);
    }

    function erroSalvar(response) {
        var errors = [];
        for (var key in response.data.modelState) {
            for (var i = 0; i < response.data.modelState[key].length; i++) {
                errors.push(response.data.modelState[key][i]);
            }
        }
        $scope.mensagem = errors.join(' ');
    }

});