'use strict';
app.factory('servicosService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var servicosServiceFactory = {};

    var _obterDaUnidade = function (idUnidade, idNivel) {

        return $http.get(serviceBase + 'api/servicos/getByUnidade', {
            params: {
                idNivel: idNivel,
                idUnidade: idUnidade
            }
        }).then(function (response) {
            return response;
        });

    };
    
    var _obterPossiveisStatus = function () {

        return $http.get(serviceBase + 'api/servicos/getPossiveisStatus').then(function (response) {
            return response;
        });

    };

    var _obterPossiveisResultados = function () {

        return $http.get(serviceBase + 'api/servicos/getPossiveisResultados').then(function (response) {
            return response;
        });

    };

    servicosServiceFactory.obterPossiveisStatus = _obterPossiveisStatus;
    servicosServiceFactory.obterDaUnidade = _obterDaUnidade;
    servicosServiceFactory.obterPossiveisResultados = _obterPossiveisResultados;

    return servicosServiceFactory;
}]);