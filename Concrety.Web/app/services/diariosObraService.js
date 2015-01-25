'use strict';
app.factory('diariosObraService', function ($http, $q, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var diariosObraServiceFactory = {};

    var _get = function (idEmpreendimento) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/diariosObra/get', {
            params: {
                idEmpreendimento: idEmpreendimento
            }
        }).then(function (response) {
            deferred.resolve(response);
        });

        return deferred.promise;
    };

    var _update = function (empreendimento) {
        return $http.post(serviceBase + 'api/diariosObra/update', empreendimento).then(function (response) {
            return response;
        });
    };

    var _create = function (empreendimento) {
        return $http.post(serviceBase + 'api/diariosObra/create', empreendimento).then(function (response) {
            return response;
        });
    };

    diariosObraServiceFactory.get = _get;
    diariosObraServiceFactory.update = _update;
    diariosObraServiceFactory.create = _create;

    return diariosObraServiceFactory;

});