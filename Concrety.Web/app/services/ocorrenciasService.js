'use strict';
app.factory('ocorrenciasService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var ocorrenciasServiceFactory = {};
    
    var _obterPossiveisStatus = function () {
        return $http.get(serviceBase + 'api/ocorrencias/possiveisStatus').then(function (response) {
            return response;
        });
    };

    var _update = function (ocorrencia) {
        return $http.post(serviceBase + 'api/ocorrencias/update', ocorrencia).then(function (response) {
            return response;
        });
    };

    var _create = function (ocorrencia) {
        return $http.post(serviceBase + 'api/ocorrencias/create', ocorrencia).then(function (response) {
            return response;
        });
    };

    var _obterDoServicoUnidade = function (idServicoUnidade) {
        return $http.get(serviceBase + 'api/ocorrencias/obterDoServicoUnidade', {
            params: {
                idServicoUnidade: idServicoUnidade
            }
        }).then(function (response) {
            return response;
        });
    }

    var _obterPendentes = function (idMacroServico) {
        return $http.get(serviceBase + 'api/ocorrencias/obterPendentes', {
            params: {
                idMacroServico: idMacroServico
            }
        }).then(function (response) {
            return response;
        });
    }

    var _removerAnexo = function (anexo) {
        return $http.post(serviceBase + 'api/ocorrenciasAnexos/remover', anexo).then(function (response) {
            return response;
        });
    };

    ocorrenciasServiceFactory.obterPossiveisStatus = _obterPossiveisStatus;
    ocorrenciasServiceFactory.create = _create;
    ocorrenciasServiceFactory.update = _update;
    ocorrenciasServiceFactory.obterDoServicoUnidade = _obterDoServicoUnidade;
    ocorrenciasServiceFactory.obterPendentes = _obterPendentes;
    ocorrenciasServiceFactory.removerAnexo = _removerAnexo;

    return ocorrenciasServiceFactory;
}]);