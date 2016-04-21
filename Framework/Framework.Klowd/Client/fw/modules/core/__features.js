// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.feature('service', function () {
    return {
        value: function (feature, id, deps, def) {
            return (typeof def == 'function') ? def.apply(def, deps) : null;
        }
    };
});

fw.feature('factory', function () {
    return {
        singleton: false,
        value: function (feature, id, deps, def) {
            return (typeof def == 'function') ? def.apply(def, deps) : null;
        }
    };
});

fw.feature('object', function () {
    return {
        value: function (feature, id, deps, def) {
            return (typeof def == 'function') ? def.apply(def, deps) : null;
        }
    };
});