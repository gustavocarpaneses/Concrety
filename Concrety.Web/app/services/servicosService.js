'use strict';
app.factory('servicosService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var servicosServiceFactory = {};

    var _getNiveis = function (idEmpreendimento) {

        return $http.get(serviceBase + 'api/servicos/niveis', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            return response;
        });

    };

    servicosServiceFactory.getNiveis = _getNiveis;

    return servicosServiceFactory;
}]);