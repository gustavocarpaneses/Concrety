'use strict';
app.factory('condicaoClimaticaService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var condicaoClimaticaServiceFactory = {};

    var _get = function () {
        return $http.get(serviceBase + 'api/condicoesClimaticas/get').then(function (response) {
            return response;
        });
    };

    condicaoClimaticaServiceFactory.get = _get;

    return condicaoClimaticaServiceFactory;

});