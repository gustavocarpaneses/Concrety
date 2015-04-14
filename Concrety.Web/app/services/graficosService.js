'use strict';
app.factory('graficosService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var graficosServiceFactory = {};

    var _obterDeCondicoesClimaticas = function (idEmpreendimento) {
        return $http.get(serviceBase + 'api/graficos/getOfCondicoesClimaticas', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            return response;
        });
    };

    graficosServiceFactory.obterDeCondicoesClimaticas = _obterDeCondicoesClimaticas;

    return graficosServiceFactory;

});