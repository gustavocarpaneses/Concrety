'use strict';
app.factory('unidadesService', ['$http', '$q', 'concretySettings', function ($http, $q, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var unidadesServiceFactory = {};

    var _getByIdNivel = function (idNivel) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/unidades/getByIdNivel', {
            params: {
                idNivel: idNivel
            }
        }).then(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;

    };
    
    unidadesServiceFactory.getByIdNivel = _getByIdNivel;

    return unidadesServiceFactory;
}]);