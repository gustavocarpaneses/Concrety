'use strict';
app.factory('diarioObraService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var diariosObraServiceFactory = {};

    var _get = function (idEmpreendimento) {

        return $http.get(serviceBase + 'api/diariosObra/get', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            return response;
        });
    };

    diariosObraServiceFactory.get = _get;

    return diariosObraServiceFactory;

}]);