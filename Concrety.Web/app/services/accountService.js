'use strict';
app.factory('accountService', ['$http', '$q', 'localStorageService', 'concretySettings', function ($http, $q, localStorageService, concretySettings) {

    var serviceBase = concretySettings.apiServiceBaseUri;
    var accountServiceFactory = {};

    var _empreendimentosUsuario = [];

    var _empreendimentoAtual = {
        id: 0,
        nome: "",
        macrosServicos: []
    };

    var _macroServicoAtual = {
        id: 0,
        nome: ""
    };

    var _fillEmpreendimentosUsuario = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'api/account/getEmpreendimentos').then(function (response) {

            if (response.data.length) {

                localStorageService.set('empreendimentoAtual', response.data[0]);
                fillEmpreendimentoAtual(response.data[0]);

                localStorageService.set('macroServicoAtual', response.data[0].macrosServicos[0]);
                fillMacroServicoAtual(response.data[0].macrosServicos[0]);

                localStorageService.set('empreendimentosUsuario', response.data);
                _empreendimentosUsuario = response.data;

                deferred.resolve();
            }
            else {
                deferred.reject("Este usuário não possui nenhuma obra associada");
            }

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

        localStorageService.set('macroServicoAtual', empreendimentoAtual.macrosServicos[0]);
        fillMacroServicoAtual(empreendimentoAtual.macrosServicos[0]);
    };
        
    var _fillData = function () {

        var empreendimentoAtual = localStorageService.get('empreendimentoAtual');
        if (empreendimentoAtual) {
            fillEmpreendimentoAtual(empreendimentoAtual);
        }

        var macroServicoAtual = localStorageService.get('macroServicoAtual');
        if (macroServicoAtual) {
            fillMacroServicoAtual(macroServicoAtual);
        }

        var empreendimentosUsuario = localStorageService.get('empreendimentosUsuario');
        if (empreendimentosUsuario) {
            _empreendimentosUsuario = empreendimentosUsuario;
        }

    }

    function fillEmpreendimentoAtual(empreendimento) {
        _empreendimentoAtual.id = empreendimento.id;
        _empreendimentoAtual.nome = empreendimento.nome;
        _empreendimentoAtual.macrosServicos = empreendimento.macrosServicos;
    }

    function fillMacroServicoAtual(macroServico) {
        _macroServicoAtual.id = macroServico.id;
        _macroServicoAtual.nome = macroServico.nome;
    }

    accountServiceFactory.alterarEmpreendimentoAtual = _alterarEmpreendimentoAtual;
    accountServiceFactory.fillEmpreendimentosUsuario = _fillEmpreendimentosUsuario;
    accountServiceFactory.fillData = _fillData;
    accountServiceFactory.empreendimentoAtual = _empreendimentoAtual;
    accountServiceFactory.macroServicoAtual = _macroServicoAtual;
    accountServiceFactory.getEmpreendimentosUsuario = _getEmpreendimentosUsuario;

    return accountServiceFactory;
}]);