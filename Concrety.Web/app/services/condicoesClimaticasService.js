'use strict';
app.factory('condicoesClimaticasService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var condicoesClimaticasServiceFactory = {};

    var _get = function () {
        return $http.get(serviceBase + 'api/condicoesClimaticas/get').then(function (response) {
            return response;
        });
    };

    condicoesClimaticasServiceFactory.get = _get;

    return condicoesClimaticasServiceFactory;

});