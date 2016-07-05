// ============================================================================
// Project: Framework
// Name/Class: mvc.engine.instance
// Created On: 09/Abr/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('mvc.engine').service('component', 'core.util, core.string', function ($util, $string) {

    //
    // Constants
    // Kind of model property.
    //

    var _IN = 'IN';
    var _OUT = 'OUT';
    var _INOUT = 'INOUT';

    //
    // Constants
    // For defining required and optional properties.
    //

    var _REQUIRED = true;
    var _OPTIONAL = false;

    //
    // Define a component model property.
    // @param display The display name for the property.
    // @param kind The kind for the property, e.g. IN, OUT, INOUT
    // @param required Wheter the property is required o have a value or not.
    // @param dftValue The default value for the property.
    //

    var _property = function (display, kind, type, required, dftValue) {
        return {
            display: display,
            kind: kind,
            type: type,
            required: required,
            dft: dftValue
        };
    };

    //
    // API
    //

    return {
        property: _property,

        IN: _IN,
        OUT: _OUT,
        INOUT: _INOUT,

        REQUIRED: _REQUIRED,
        OPTIONAL: _OPTIONAL
    };
});