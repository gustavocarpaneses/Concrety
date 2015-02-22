'use strict';
app.factory('unidadesService', ['$http', '$q', 'concretySettings', function ($http, $q, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var unidadesServiceFactory = {};

    var _obterDoNivel = function (idNivel) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/unidades/getByNivel', {
            params: {
                idNivel: idNivel
            }
        }).then(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;

    };
    
    unidadesServiceFactory.obterDoNivel = _obterDoNivel;

    return unidadesServiceFactory;
}]);