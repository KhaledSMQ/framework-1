// ============================================================================
// Project: Framework
// Name/Class: Service feature.
// Created On: 23/Jan/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.feature('service', {

    value: function (deps, def) {

        var api = null;

        if (typeof def == 'function') {
            api = def.apply(def, deps);
        }
        
        return api;
    }

});