// ============================================================================
// Project: Framework
// Name/Class: Core module. String service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('string', function () {

    //
    // Check if a string starts with another string.
    // @param str The string to check
    // @param val The value to check for
    // @return true if string starts with value, false otherwise.
    //

    var _startsWith = function (str, val) {
        return str.slice(0, val.length) == val;
    };

    //
    // Check if a string ends with another string.
    // @param str The string to check
    // @param val The value to check for
    // @return true if string ends with value, false otherwise.
    //

    var _endsWith = function (str, val) {
        return str.slice(-val.length) == val;
    };

    //
    // Take a string with a set of placeholder, e.g. {0}, {1},
    // .. {n} and replace them with the actual values passed
    // in the rest of the arguments.
    //

    var _format = function () {
        return fw.core.format.apply(this, arguments);
    };

    //
    // API
    //

    return {
        startsWith: _startsWith,
        endsWith: _endsWith,
        format: _format
    };
});