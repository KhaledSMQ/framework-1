// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('core').service('dom', 'core.util', function ($util) {

    //
    // State
    //

    var _ID_BASE_NAME = 'w';
    var _ID_COUNT = 0;

    //
    // Generate a new unique identifier.
    // @return A new, unique, fantastic identifier.
    //

    var _getID = function () {
        return _ID_BASE_NAME + _ID_COUNT++;
    };

    //
    // API
    //

    return {
        getID : _getID
    };
});