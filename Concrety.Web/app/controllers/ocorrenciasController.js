'use strict';
app.controller('ocorrenciasController', function ($scope, $timeout, $modalInstance, ocorrencia, ocorrenciasService, patologiasService, anexosService) {

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

    $scope.anexoSelecionado = function () {

        var anexos = document.getElementById('file').files;

        angular.forEach(anexos, function (anexo, index) {

            var filtro = /^(image\/bmp|image\/gif|image\/jpeg|image\/png|image\/tiff)$/i;
            if (!filtro.test(anexo.type)) {
                $scope.mensagem = "Por favor, selecione apenas anexos de imagem (bmp, gif, jpg, jpeg, png ou tiff)";
            }
            else {
                var reader = new FileReader();

                reader.onloadend = function (e) {

                    $scope.ocorrencia.anexos.push({
                        nome: anexo.name,
                        tamanho: bytesToSize(anexo.size),
                        tipo: anexo.type,
                        conteudo: e.target.result,
                        novoUpload: true
                    });

                }
                reader.readAsDataURL(anexo);
            }
        });
    };

    $scope.excluirAnexo = function (anexo) {
        anexo.excluido = true;
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

    function bytesToSize(bytes) {
        var sizes = ['Bytes', 'KB', 'MB'];
        if (bytes == 0) return 'n/a';
        var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
        return (bytes / Math.pow(1024, i)).toFixed(1) + ' ' + sizes[i];
    };
    
});