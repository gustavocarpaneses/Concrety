'use strict';
app.factory('niveisService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var niveisServiceFactory = {};

    var _getNiveisServico = function (idMacroServico) {

        return $http.get(serviceBase + 'api/niveis/servico', {
            params: {
                idMacroServico: idMacroServico
            }
        }).then(function (response) {
            return response;
        });

    };

    var _getNiveisVerificacaoMaterial = function (idMacroServico) {

        return $http.get(serviceBase + 'api/niveis/verificacaomaterial', {
            params: {
                idMacroServico: idMacroServico
            }
        }).then(function (response) {
            return response;
        });

    };

    niveisServiceFactory.getNiveisServico = _getNiveisServico;
    niveisServiceFactory.getNiveisVerificacaoMaterial = _getNiveisVerificacaoMaterial;

    return niveisServiceFactory;
}]);