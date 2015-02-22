'use strict';
app.factory('diariosObraService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var diariosObraServiceFactory = {};

    var _get = function (idEmpreendimento) {

        //var deferred = $q.defer();

        return $http.get(serviceBase + 'api/diariosObra/getByEmpreendimento', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            return response;
        });

        //return deferred.promise;
    };

    var _update = function (empreendimento) {
        return $http.put(serviceBase + 'api/diariosObra', empreendimento).then(function (response) {
            return response;
        });
    };

    var _create = function (empreendimento) {
        return $http.post(serviceBase + 'api/diariosObra', empreendimento).then(function (response) {
            return response;
        });
    };

    diariosObraServiceFactory.get = _get;
    diariosObraServiceFactory.update = _update;
    diariosObraServiceFactory.create = _create;

    return diariosObraServiceFactory;

});