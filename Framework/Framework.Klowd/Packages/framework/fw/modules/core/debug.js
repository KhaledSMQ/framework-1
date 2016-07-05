// ============================================================================
// Project: Framework
// Name/Class: Core module. Debug logging service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('core').service('debug', 'core.util', function ($util) {

    //
    // Turn ON debugging.
    //

    var _on = function () {
        return fw.debug(true);
    };

    //
    // Turn OFF debugging.
    //

    var _off = function () {
        return fw.debug(false);
    };

    //
    // Current state for debug flag.
    //

    var _flag = function () {
        return fw.debug();
    };

    //
    // Log a debug message.
    //

    var _log = function () {
        return fw.debug.apply(this, arguments);
    }

    //
    // API
    //

    return {
        on: _on,
        off: _off,
        flag: _flag,
        log: _log
    };
});