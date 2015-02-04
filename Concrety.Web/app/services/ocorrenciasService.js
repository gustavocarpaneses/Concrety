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

    var _uploadArquivo = function (data) {

    };

    ocorrenciasServiceFactory.obterPossiveisStatus = _obterPossiveisStatus;
    ocorrenciasServiceFactory.create = _create;
    ocorrenciasServiceFactory.update = _update;
    ocorrenciasServiceFactory.obterDoServicoUnidade = _obterDoServicoUnidade;
    ocorrenciasServiceFactory.obterPendentes = _obterPendentes;
    ocorrenciasServiceFactory.uploadArquivo = _uploadArquivo;

    return ocorrenciasServiceFactory;
}]);