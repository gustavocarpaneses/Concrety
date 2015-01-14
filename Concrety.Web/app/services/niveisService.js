'use strict';
app.factory('niveisService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var niveisServiceFactory = {};

    var _obterNiveisDeServico = function (idMacroServico) {

        return $http.get(serviceBase + 'api/niveis/servico', {
            params: {
                idMacroServico: idMacroServico
            }
        }).then(function (response) {
            return response;
        });

    };

    var _obterNiveisDeVerificacaoDeMaterial = function (idMacroServico) {

        return $http.get(serviceBase + 'api/niveis/verificacaomaterial', {
            params: {
                idMacroServico: idMacroServico
            }
        }).then(function (response) {
            return response;
        });

    };

    var _obterNiveisAcima = function (idNivel) {

        return $http.get(serviceBase + 'api/niveis/acima', {
            params: {
                idNivel: idNivel
            }
        }).then(function (response) {
            return response;
        });

    };

    niveisServiceFactory.obterNiveisDeServico = _obterNiveisDeServico;
    niveisServiceFactory.obterNiveisDeVerificacaoDeMaterial = _obterNiveisDeVerificacaoDeMaterial;
    niveisServiceFactory.obterNiveisAcima = _obterNiveisAcima;

    return niveisServiceFactory;
}]);