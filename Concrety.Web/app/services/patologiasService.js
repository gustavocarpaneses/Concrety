'use strict';
app.factory('patologiasService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var patologiasServiceFactory = {};
    
    var _obter = function (idItemVerificacaoServico) {
        return $http.get(serviceBase + 'api/patologias/get', {
            params: {
                idItemVerificacaoServico: idItemVerificacaoServico
            }
        }).then(function (response) {
            return response;
        });
    };

    patologiasServiceFactory.obter = _obter;

    return patologiasServiceFactory;
}]);