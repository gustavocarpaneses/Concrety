'use strict';
app.factory('servicoUnidadeService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var servicoUnidadeServiceFactory = {};

    var _obter = function (idUnidade, idServico) {

        return $http.get(serviceBase + 'api/servicounidade/get', {
            params: {
                idServico: idServico,
                idUnidade: idUnidade
            }
        }).then(function (response) {
            return response;
        });

    };

    var _salvar = function (servicoUnidade) {

        return $http.post(serviceBase + 'api/servicounidade/post', servicoUnidade).then(function (response) {
            return response;
        });

    };
    
    servicoUnidadeServiceFactory.salvar = _salvar;
    servicoUnidadeServiceFactory.obter = _obter;

    return servicoUnidadeServiceFactory;
}]);