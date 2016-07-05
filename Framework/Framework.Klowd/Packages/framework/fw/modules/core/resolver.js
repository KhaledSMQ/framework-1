// ============================================================================
// Project: Framework
// Name/Class: core.resolver
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('core').service('resolver', 'core.util, core.error', function ($util, $error) {

    //
    // Library name.
    //

    var __LIB = 'core.resolver';

    //
    // Error Messages.
    //

    var __ERR = {
        'INVALID_INSTANCE': 'Invalid resolver instance!',
        'INVALID_RESOLVER_TAG': 'Invalid resolver tag \'{arg0}\''
    };

    //
    // Initialize url resolver library.
    // @param config Initial configuration.
    // @param success The success handler.
    // @param error The error handler.
    //

    var _init = function (config, success, error) {

        var instance = { domain: {}, defaultBaseUrl: '' };
        success(instance);
        return instance;
    };

    //
    // Register a new base url in resolver instance.
    // @param instance The instance where to define the new base url.
    // @param name The name of the base url.
    // @param baseUrl The base url value.
    //

    var _register = function (instance, name, baseUrl) {

        if ($util.isDefined(instance)) {

            if (typeof (name) == 'undefined' || null == name || '' == name) {

                instance.defaultBaseUrl = baseUrl;
            }
            else {

                instance.domain[name] = baseUrl;
            }
        }
        else {

            //
            // ERROR: Invalid instance.
            //

            $error.msg(__LIB, __ERR, 'INVALID_INSTANCE');
        }
    };

    //
    // Import a list of base urls. This function accepts a
    // list of strings. Even indexes are the base url tags,
    // and odd indexes are the actual base urls. The base 
    // urls are resolved before inserting them.
    // @param instance The instance where to import the list.
    // @param list The list of base urls to import.
    //

    var _import = function (instance, list) {

        if ($util.isDefined(instance)) {

            if ($util.isDefined(list)) {

                var name = '';

                $util.apply(list, function (idx, elm) {

                    //
                    // if index is an odd number.
                    //

                    if (idx & 1) {
                        if ($util.isDefined(name) && $util.isDefined(elm)) {
                            _register(instance, name, _resolve(instance, elm));
                        }
                    }
                    else {
                        name = elm;
                    }
                });
            }
        }
        else {

            //
            // ERROR: Invalid instance.
            //

            $error.msg(__LIB, __ERR, 'INVALID_INSTANCE');
        }
    };

    //
    // Resolve a relative url.
    // Urls can be prefixed with the resolve name, ex: [<RESOLVER>]:<URL>
    //

    var _resolve = function (instance, relUrl) {

        var resolved = '';

        if ($util.isDefined(instance)) {

            if ($util.isDefined(relUrl)) {

                var trimmed = relUrl.trim();
                resolved = trimmed;
                var base = instance.defaultBaseUrl;

                var sIndex = trimmed.indexOf('[');
                var eIndex = trimmed.indexOf(']:');

                //
                // Url contains a resolver tag, fetch the 
                // the base url for it.
                //

                if (0 == sIndex && eIndex > 1) {

                    var resolver = trimmed.substring(1, eIndex);

                    if ($util.isDefined(instance.domain[resolver])) {

                        base = instance.domain[resolver];
                        resolved = trimmed.substring(eIndex + 2);
                    }
                    else {

                        //
                        // ERROR: The resolver tag is not defined.
                        //

                        $error.msg(__LIB, __ERR, 'INVALID_RESOLVER_TAG', resolver);
                    }
                }

                //
                // If urll needs resolving, apply the base url.
                //

                if (resolved.indexOf("~/") == 0) {

                    resolved = base + resolved.substring(2);
                }
            }

        }
        else {

            //
            // ERROR: Invalid instance.
            //

            $error.msg(__LIB, __ERR, 'INVALID_INSTANCE');
        }

        return resolved;
    };

    //
    // API
    //

    return {
        init: _init,
        register: _register,
        'import': _import,
        resolve: _resolve
    };
});