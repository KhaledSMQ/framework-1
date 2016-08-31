// ============================================================================
// Project: Framework
// Name/Class: mvc.engine.scope
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('mvc.engine').service('scope', 'core.util', function ($util) {

    //
    // Library name.
    //

    var __LIB = 'mvc.engine.scope';

    //
    // Get the root scope for app.
    //

    var _root = function () {

        var scope = {

            //
            // Parent scope value.
            //

            parent: null
        };

        return scope;
    };

    //
    // Get a new scope object based on am existing scope.
    //

    var _new = function (parent, container, fragment) {

        var scope = {

            //
            // Parent scope value.
            //

            parent: parent,

            //
            // Container for fragment.
            //

            container: container,

            //
            // Fragment reference for scope.
            //

            fragment: fragment,

            //
            // Processed fragment model.
            //

            model: null,

            //
            // Processed and original view.
            //

            view: null,

            //
            // List of bindings definition.
            //

            binding: null,

            //
            // Tree of components.
            //

            tree: null,

            //
            // Generated html
            //

            html: null
        };

        return scope;
    }

    //
    // API
    //

    return {
        'root': _root,
        'new': _new
    };
});