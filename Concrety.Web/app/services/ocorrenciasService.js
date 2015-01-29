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

    ocorrenciasServiceFactory.obterPossiveisStatus = _obterPossiveisStatus;
    ocorrenciasServiceFactory.create = _create;
    ocorrenciasServiceFactory.update = _update;

    return ocorrenciasServiceFactory;
}]);