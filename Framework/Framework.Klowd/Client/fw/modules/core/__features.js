// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';

fw.feature('service', function () {

    var _value = function (deps, def) {

        var api = null;

        if (typeof def == 'function') {
            api = def.apply(def, deps);
        }

        return api;
    };

    return {
        value: _value
    };

});

fw.feature('object', function () {

    return {};

});