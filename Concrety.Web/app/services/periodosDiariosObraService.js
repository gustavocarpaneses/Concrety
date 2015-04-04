'use strict';
app.factory('periodosDiariosObraService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var periodosDiariosObraServiceFactory = {};

    var _get = function (idEmpreendimento) {

        return $http.get(serviceBase + 'api/periodosDiarioObra/getByEmpreendimento', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            return response;
        });
    };

    periodosDiariosObraServiceFactory.get = _get;

    return periodosDiariosObraServiceFactory;

});