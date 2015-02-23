'use strict';
app.factory('emailService', function ($http, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var emailServiceFactory = {};

    var _enviarFeedback = function (feedback) {
        return $http.post(serviceBase + 'api/email/postFeedback', feedback).then(function (response) {
            return response;
        });
    };


    emailServiceFactory.enviarFeedback = _enviarFeedback;

    return emailServiceFactory;

});