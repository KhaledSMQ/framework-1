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

        //
        // Setup the component instance value.
        //

        var instance = {

            //
            // unique identifier and DOM container where 
            // the component is attached, could be a string or
            // a jQuery object.
            //

            __dom: {
                id: null,
                root: null
            },

            //
            // State of the component. This object
            // forms all known data for the instance,
            // the apis retrieve and store values 
            // from this state value.
            //

            __state: {

                //
                // Properties. Hash mapping the name
                // and runtime value for a specific
                // property.
                //

                properties: {},

                //
                // Model. Hash mapping the name and
                // the runtime model value.
                //

                model: {},

                //
                // Resources. Mapping between resource name
                // and its value.
                //

                resources: {},

                //
                // Hash with the event handlers and the event names.
                //

                events: {},

                //
                // Geenric custom user data store.
                //

                data: {}
            },

            //
            // APIs.
            //

            $dom: {},
            $property: {},
            $model: {},
            $resource: {},
            $event: {},
            $data: {}
        };


        //
        // Get the component definition.
        //

        var def = fw.get(name);

        //
        // Import the API defined by the component to
        // the component instance. This makes up for
        // a very clean instance interface.        
        //

        /*
        $.each(api, function (name, def) {

            instance[name] = function () { def.apply(api.$def.native, arguments); };
        });
        */

        instance.run = function () {

            var args = [];
            args.push(instance);
            $.each(def.deps, function (_, dep) { args.push(dep); });

            var api = def.native.apply(def, args);

            var name = arguments[0];

            api[name].apply(def, arguments);

        };

        //
        // Return the component instance to caller.
        //

        return instance;
    };


    //
    // API
    //

    return {
        'new': _new
    };
});