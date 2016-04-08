// ============================================================================
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
        return fw.core.defined(variable);
    };

    //
    // Check if a variable is not defined.
    //

    var _isNotDefined = function (variable) {
        return !_isDefined(variable);
    };

    //
    // Mapping for values.
    //

    var _map = function (val, fun) {
        return fw.core.map(val, fun);
    }

    //
    // Transform values into arrays.
    //

    var _toArray = function (val, fun) {
        return fw.core.toArray(val, fun);
    }

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

            if ($util.isDefined(path)) {

                var splitPatt = path.split('.');

                var retValue = obj;

                $.each(splitPatt, function (idx, property) {

                    var tempValue = retValue[property];

                    if ($util.isDefined(tempValue)) {

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
        map: _map,
        toArray:_toArray,
        getValue: _getValue,
        count: _count,
        clone: _clone
    };
});