'use strict';
app.factory('ocorrenciasService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var ocorrenciasServiceFactory = {};
    
    var _obterPossiveisStatus = function () {
        return $http.get(serviceBase + 'api/ocorrencias/possiveisStatus').then(function (response) {
            return response;
        });
    };

    ocorrenciasServiceFactory.obterPossiveisStatus = _obterPossiveisStatus;

    return ocorrenciasServiceFactory;
}]);