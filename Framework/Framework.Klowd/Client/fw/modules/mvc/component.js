// ============================================================================
// Project: Framework
// Name/Class: mvc.component
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc').service('component', 'core.util', function ($util) {

    //
    // Service name.
    //

    var __LIB = 'mvc.component'; 

    //
    // Get a new instance for a specific component.
    // @param name The unique name for the component.
    //

    var _new = function (name) {

    };


    //
    // API
    //

    return {
        'new' : _new
    };
});