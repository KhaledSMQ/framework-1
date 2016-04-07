// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';

fw.feature('component', function () {

    //
    // Internal state, count the number of
    // component instances that were created
    // and define the prefix value for component
    // instance unique identifier.
    //

    var __INSTANCE__COUNT = 0;
    var __INSTANCE__PREFIX = 'c';

    return {

        singleton: false,

        value: function (deps, fun) {

            //
            // TODO: Check the generated component API,
            // components must define at least a render
            // method.
            //

            //
            // TODO: Check the generated API, methods are
            // not allowed to start with a '$' or '_' caracter.
            //

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
                    id: __INSTANCE__PREFIX + __INSTANCE__COUNT++,
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

            var compDef = fun.apply(fun, deps);

            //
            // Attach to the instance the component
            // definition object. Add the name value
            // also.
            //

            instance.$def = compDef;
            instance.$def.name = name;

            //
            // Process the component instance API.
            // Create a function for every native method
            // found in the component definition.
            //

            if (fw.core.defined(compDef.api)) {

                $.each(compDef.api, function (name, fun) {

                    instance[name] = function () {

                        //
                        // Attach the component instance
                        // object, this means that all
                        // function must declare first the
                        // component instance.
                        //

                        var args = [instance];

                        //
                        // Add other arguments that are sent 
                        // to function by the invocation.
                        //

                        //
                        // Call the function.
                        //

                        fun.apply(fun, args);
                    };
                });
            }

            //
            // Return a newly create component
            // instance to caller. This instance
            // can be used independently...
            //

            return instance;
        }
    };
});

fw.feature('fragment', function () {
    return {
        value: function (deps, fun) {
            return { deps: deps, def: fun };
        }
    };
});

fw.feature('package', function () {
    return {
    };
});