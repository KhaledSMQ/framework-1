// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';

fw.feature('component', function () {

    var _value = function (deps, def) {

        //
        // Component value definitions are objects
        // that contain the following properties:
        //
        //    o- base :: string
        //    o- description :: string
        //    o- properties :: object
        //    o- model :: object
        //    o- resources :: object 
        //    o- events :: object
        //    o- template :: object | string
        //    o- placeholders :: object
        //    o- native : function
        //

       
        var api = null;

        if (typeof def == 'object') {

            def.deps = deps;

            if (fw.core.defined(def.native)) {

                //
                // Component defines a native code function,
                // use it to generate its API.
                //

                var args = [];
                args.push(null);
                $.each(def.deps, function (_, dep) { args.push(dep); });

                api = def.native.apply(def, args);
            }
            else {

                //
                // Component API will be the default api for 
                // components that do not define any custom
                // native code.
                //

                api = {};
            }

            api.$def = def;

            //
            // TODO: Check the generated component API,
            // components must define at least a render
            // method.
            //

            //
            // TODO: Check the generated API, methods are
            // not allowed to start with a '$' or '_' caracter.
            //
        }
        else {

            //
            // ERROR: Invalid component definition object.
            //
        }

        return def;
    };

    return {
        value: _value
    };

});

fw.feature('fragment', function () {

    var _value = function (deps, def) {

        //
        // Component value definitions are objects
        // that contain the following properties:
        //
        //    o- master :: string
        //    o- description :: string
        //    o- properties :: object
        //    o- model :: object
        //    o- resources :: object 
        //    o- events :: object
        //    o- placeholders :: object
        //    o- view :: object | array
        //    o- binding :: object | array
        //    o- rules : object
        //

        var fragment = null;

        if (typeof def == 'object') {

            fragment = def;
            fragment.deps = deps;            
        }

        return fragment;
    };

    return {
        value : _value
    };
});

fw.feature('package', function () {

    return {};

});