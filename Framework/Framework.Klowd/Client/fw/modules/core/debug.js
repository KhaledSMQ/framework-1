// ============================================================================
// Project: Framework
// Name/Class: Core module. Debug logging service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('debug', 'core.util', function ($util) {

    //
    // Turn ON debugging.
    //

    var _on = function () {
        fw.debug(true);
    };

    //
    // Turn OFF debugging.
    //

    var _off = function () {
        fw.debug(false);
    };

    //
    // Log a debug message.
    //

    var _log = function () {
        fw.debug.apply(this, arguments);
    }

    //
    // API
    //

    return {
        on: _on,
        off: _off,
        log: _log
    };
});