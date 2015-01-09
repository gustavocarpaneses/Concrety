'use strict';
app.factory('materiaisService', ['$http', 'concretySettings', function ($http,  concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var materiaisServiceFactory = {};

    var _getNiveis = function (idEmpreendimento) {

        return $http.get(serviceBase + 'api/materiais/niveis', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (results) {
            return results;
        });

    };

    materiaisServiceFactory.getNiveis = _getNiveis;

    return materiaisServiceFactory;
}]);