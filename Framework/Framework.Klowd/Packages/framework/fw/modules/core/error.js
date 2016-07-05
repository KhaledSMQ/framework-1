// ============================================================================
// Project: Framework
// Name/Class: Core module. Error service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('core').service('error', 'core.util', function ($util) {

    //
    // Write an error message.
    // @param lib the library/source where the error comes from.
    // @param bag The error bag where to fetch the error descriptor.
    // @param descriptor The error descriptor
    // @param args A list of values to merge with the error message.
    //

    var _msg = function (lib, bag, descriptor) {

        //
        // Base message.
        //

        var msg = '[' + lib + ']:' + bag[descriptor];

        //
        // Instantiate aditional parameters, placeholder: {argN}
        //

        if (arguments.length > 4) {
            for (var i = 3, j = 0; i < arguments.length; i++, j++) {
                msg = msg.replace('{arg' + j + '}', arguments[i]);
            }
        }    

        //
        // dump to console.
        //

        console.error(msg);
    };

    //
    // API
    //

    return {
        msg: _msg
    };
});