// ============================================================================
// Project: Framework
// Name/Class: core module.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('fw').service('util', function () {

    //
    // Check if a variable is defined.
    // The variable is defined if is not undefined,
    // not null and has a non empty string value.
    //

    var _isDefined = function (variable) {

        //
        // Check if variable is defined and not null.
        //

        var defined = (typeof variable != 'undefined') && (variable != null);

        //
        // In case the variable is a string check if
        // it is not an empty string.
        //

        if (defined && typeof variable == 'string') {

            defined = variable != "";
        }

        return defined;
    };

    //
    // Check if a variable is not defined.
    //

    var _isNotDefined = function (variable) {

        return !_isDefined(variable);
    };

    //
    // Return the service protocol.
    //

    return {

        isDefined: _isDefined,
        isNotDefined: _isNotDefined
    };
});