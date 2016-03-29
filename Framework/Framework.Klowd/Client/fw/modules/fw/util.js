﻿// ============================================================================
// Project: Framework
// Name/Class: Core module. Util service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('util', function () {

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
    // Get a value for a particular object.
    // @param obj The data object where to extract.
    // @param path the path for the value, e.g: a.b.c
    //

    var _getValue = function (obj, path) {

        var output = null;

        if (!(obj instanceof Object)) {

            output = obj;
        }
        else {

            if (toolkit.util.IsDefined(path)) {

                var splitPatt = path.split('.');

                var retValue = obj;

                $.each(splitPatt, function (idx, property) {

                    var tempValue = retValue[property];

                    if (toolkit.util.IsDefined(tempValue)) {

                        retValue = tempValue;

                    } else {

                        retValue = null;
                        return false;
                    }
                });

                output = retValue;
            }
            else {

                output = obj;
            }
        }

        return output;
    };

    //
    // Clone a javascript value. 
    // @param value The value to clone.
    // @param deep Wheter the clonnig is deep or not.
    //

    var _clone = function (value, deep) {
        var deepCloning = _isDefined(deep) ? deep : true;
        var target = null;
        target = $.extend(deepCloning, target, value);
        return target;
    };

    //
    // Count the number of properties on a object.
    // @param obj The object to count the number of properties.
    // @param The number of properties in an object.
    //

    var _count = function (obj) {
        var count = 0;
        for (var k in obj) { if (obj.hasOwnProperty(k)) { count++; } }
        return count;
    };

    //
    // API
    //

    return {
        isDefined: _isDefined,
        isNotDefined: _isNotDefined,
        getValue: _getValue,
        count: _count,
        clone: _clone
    };
});