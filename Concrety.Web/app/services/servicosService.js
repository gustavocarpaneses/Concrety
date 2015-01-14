'use strict';
app.factory('servicosService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var servicosServiceFactory = {};

    var _obterDaUnidade = function (idUnidade, idNivel) {

        return $http.get(serviceBase + 'api/servicos/unidade', {
            params: {
                idNivel: idNivel,
                idUnidade: idUnidade
            }
        }).then(function (response) {
            return response;
        });

    };
    
    servicosServiceFactory.obterDaUnidade = _obterDaUnidade;

    return servicosServiceFactory;
}]);