'use strict';
app.factory('materiaisService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var materiaisServiceFactory = {};

    var _obterDaUnidade = function (idUnidade) {

        return $http.get(serviceBase + 'api/materialUnidade/unidade', {
            params: {
                idUnidade: idUnidade
            }
        }).then(function (response) {
            return response;
        });

    };

    var _obterDoNivel = function (idNivel) {

        return $http.get(serviceBase + 'api/materiais/nivel', {
            params: {
                idNivel: idNivel
            }
        }).then(function (response) {
            return response;
        });

    };

    var _update = function (fvm) {
        return $http.post(serviceBase + 'api/materialUnidade/update', fvm).then(function (response) {
            return response;
        });
    };

    var _create = function (fvm) {
        return $http.post(serviceBase + 'api/materialUnidade/create', fvm).then(function (response) {
            return response;
        });
    };

    materiaisServiceFactory.obterDaUnidade = _obterDaUnidade;
    materiaisServiceFactory.obterDoNivel = _obterDoNivel;
    materiaisServiceFactory.update = _update;
    materiaisServiceFactory.create = _create;

    return materiaisServiceFactory;
});