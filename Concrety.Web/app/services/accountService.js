'use strict';
app.factory('accountService', ['$http', 'concretySettings', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var accountServiceFactory = {};

    var _getEmpreendimentos = function () {

        return $http.get(serviceBase + 'api/account/empreendimentos').then(function (results) {
            return results;
        });

    };
    
    accountServiceFactory.getEmpreendimentos = _getEmpreendimentos;

    return accountServiceFactory;
}]);