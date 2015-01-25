'use strict';
app.factory('fornecedoresService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var fornecedoresServiceFactory = {};

    var _get = function () {
        return $http.get(serviceBase + 'api/fornecedores/get').then(function (response) {
            return response;
        });
    };

    fornecedoresServiceFactory.get = _get;

    return fornecedoresServiceFactory;

});