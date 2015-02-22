'use strict';
app.factory('servicoUnidadeService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var servicoUnidadeServiceFactory = {};

    var _obter = function (idUnidade, idServico) {

        return $http.get(serviceBase + 'api/servicounidade/getByUnidadeServico', {
            params: {
                idServico: idServico,
                idUnidade: idUnidade
            }
        }).then(function (response) {
            return response;
        });

    };

    var _salvar = function (servicoUnidade) {

        return $http.put(serviceBase + 'api/servicounidade', servicoUnidade).then(function (response) {
            return response;
        });
        
    };
    
    servicoUnidadeServiceFactory.salvar = _salvar;
    servicoUnidadeServiceFactory.obter = _obter;

    return servicoUnidadeServiceFactory;
}]);