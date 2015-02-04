'use strict';
app.factory('anexosService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var anexosServiceFactory = {};
    
    var _delete = function (anexo) {
        return $http.delete(serviceBase + 'api/anexos/delete', anexo).then(function (response) {
            return response;
        });
    };

    var _create = function (anexo) {
        return $http.post(serviceBase + 'api/anexos/create', anexo).then(function (response) {
            return response;
        });
    };

    anexosServiceFactory.create = _create;
    anexosServiceFactory.delete = _delete;

    return anexosServiceFactory;
}]);