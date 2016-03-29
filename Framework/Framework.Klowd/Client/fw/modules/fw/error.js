// ============================================================================
// Project: Framework
// Name/Class: Core module. String service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('error', 'core.util', function ($util) {

    var _errMsg = function (lib, bag, descriptor, error) {

        //
        // Base message.
        //

        var msg = '[' + lib + ']:' + bag[descriptor];

        //
        // Instantiate aditional parameters, placeholder: {argN}
        //

        if (arguments.length > 4) {

            for (var i = 4, j = 0; i < arguments.length; i++, j++) {

                msg = msg.replace('{arg' + j + '}', arguments[i]);
            }
        }

        //
        // If caller is defined, call it here.
        //

        if ($util.isDefined(error)) {
            error(msg);
        }

        //
        // dump to console.
        //

        console.error(msg);

        return false;
    };

    //
    // API
    //

    return {

    };
});