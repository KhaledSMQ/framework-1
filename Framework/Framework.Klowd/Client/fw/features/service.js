// ============================================================================
// Project: Framework
// Name/Class: fw service feature.
// Created On: 23/Jan/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.feature('service', {

    value: function (deps, def) {
        return def.apply(null, deps);
    }

});