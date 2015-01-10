﻿'use strict';
app.factory('accountService', ['$http', '$q', 'localStorageService', 'concretySettings', function ($http, $q, localStorageService, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var accountServiceFactory = {};

    var _empreendimentosUsuario = [];

    var _empreendimentoAtual = {
        id: 0,
        nome: ""
    };

    var _fillEmpreendimentosUsuario = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/account/empreendimentos').then(function (response) {

            localStorageService.set('empreendimentoAtual', response.data[0]);
            fillEmpreendimentoAtual(response.data[0]);

            localStorageService.set('empreendimentosUsuario', response.data);
            _empreendimentosUsuario = response.data;

            deferred.resolve();

        }, function (err, status) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _getEmpreendimentosUsuario = function () {
        return _empreendimentosUsuario;
    }

    var _alterarEmpreendimentoAtual = function (empreendimentoAtual) {
        localStorageService.set('empreendimentoAtual', empreendimentoAtual);
        fillEmpreendimentoAtual(empreendimentoAtual);
    };
        
    var _fillData = function () {

        var empreendimentoAtual = localStorageService.get('empreendimentoAtual');
        if (empreendimentoAtual) {
            fillEmpreendimentoAtual(empreendimentoAtual);
        }

        var empreendimentosUsuario = localStorageService.get('empreendimentosUsuario');
        if (empreendimentosUsuario) {
            _empreendimentosUsuario = empreendimentosUsuario;
        }

    }

    function fillEmpreendimentoAtual(empreendimento) {
        _empreendimentoAtual.id = empreendimento.id;
        _empreendimentoAtual.nome = empreendimento.nome;
    }

    accountServiceFactory.alterarEmpreendimentoAtual = _alterarEmpreendimentoAtual;
    accountServiceFactory.fillEmpreendimentosUsuario = _fillEmpreendimentosUsuario;
    accountServiceFactory.fillData = _fillData;
    accountServiceFactory.empreendimentoAtual = _empreendimentoAtual;
    accountServiceFactory.getEmpreendimentosUsuario = _getEmpreendimentosUsuario;

    return accountServiceFactory;
}]);