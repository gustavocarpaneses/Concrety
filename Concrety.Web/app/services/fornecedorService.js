'use strict';
app.factory('fornecedorService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var fornecedorServiceFactory = {};

    var _get = function () {
        return $http.get(serviceBase + 'api/fornecedores/get').then(function (response) {
            return response;
        });
    };

    fornecedorServiceFactory.get = _get;

    return fornecedorServiceFactory;

});