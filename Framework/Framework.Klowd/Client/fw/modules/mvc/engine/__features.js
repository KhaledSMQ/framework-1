// ============================================================================
// Project: Framework
// Name/Class: Component feature.
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

    //
    // Import an API set to a new component instance.
    // @param feature The feature api object.
    // @param instance The component instance where to import the API.
    // @param api The API to import.
    //

    var _importAPI = function (feature, instance, api) {

        if (fw.core.defined(api)) {

            $.each(api, function (name, fun) {

                instance[name] = function () {

                    //
                    // Attach the component instance
                    // object, this means that all
                    // function must declare first the
                    // component instance.
                    // Add other arguments that are sent 
                    // to function by the invocation.
                    //

                    var args = [instance].concat(Array.prototype.slice.call(arguments));

                    //
                    // Call the function.
                    //

                    return fun.apply(fun, args);
                };
            });
        }
    };

    //
    // Initialize the model for a specific instance.
    // @param instance The component instance
    // @param model The model definition.
    //

    var _initModel = function (feature, instance, model) {

        instance.$model = {};
        instance.$state.model = {};

        if (fw.core.defined(model)) {

            $.each(model, function (name, def) {

                //
                // Set the initial value for the model
                // property, take it from the component
                // model definition.
                //

                _setModel(feature, instance, name, (fw.core.defined(def) && fw.core.defined(def.dft)) ? def.dft : null);

                //
                // Hookup the setters/getters for the property.
                //

                Object.defineProperty(instance, name, {
                    get: function () { return _getModel(feature, instance, name); },
                    set: function (val) { return _setModel(feature, instance, name, val); }
                });
            });
        }
    };

    //
    // Get the value of a specific model property.
    //

    var _getModel = function (feature, instance, name) {

        // #ifdef DEBUG

        fw.debug('{0}: {1}::{2} => [GET, {3}]', feature.id.toUpperCase(), instance.$id, instance.$type, name);

        // #endif

        return instance.$state.model[name];
    };

    //
    // Set the value of a specific model property.
    //

    var _setModel = function (feature, instance, name, val) {

        instance.$state.model[name] = val;

        // #ifdef DEBUG

        fw.debug('{0}:: {1}::{2} => [SET, {3}, {4}]', feature.id.toUpperCase(), instance.$id, instance.$type, name, instance.$state.model[name]);

        // #endif

        //
        // Check if there are any event handlers,
        // and call them, by order.
        //

        instance.$trigger(name, 'change');
    };

    //
    // Get the value of a new feature element.
    //

    var _value = function (feature, id, deps, fun) {

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
            // Component instance unique identifier.
            //

            $id: __INSTANCE__PREFIX + __INSTANCE__COUNT++,

            //
            // instance type, this is the component id.
            //

            $type: id,

            //
            // State of the component. This object
            // forms all known data for the instance,
            // the apis retrieve and store values 
            // from this state value.
            //

            $state: {

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
                // Hash with object/event handlers.
                //

                events: {},

                //
                // Generic custom user data store.
                //

                data: {}
            },

            //
            // APIs.
            //

            $property: {},
            $model: {},
            $resource: {},
            $event: {},
            $data: {}
        };

        //
        // Get the component definition.
        //

        var component = fun.apply(fun, deps);

        //
        // Attach to the instance the component
        // definition object. Add the name value
        // also.
        //

        instance.$def = component;
        instance.$def.name = id;

        //
        // If component defines a base component
        // then instantiate it here.
        //

        let topComponent = 'mvc.framework.base';

        if (id != topComponent) {

            let baseID = fw.core.defined(component.base) ? component.base : topComponent;
            let base = fw.get(baseID);

            instance.$base = base;

            //
            // Process the base component instance API.
            // If the base is null or undefined, do nothing.
            //

            if (fw.core.defined(base)) {

                _importAPI(feature, instance, base.$def.api);
            }
        }

        //
        // Process the component instance API.
        // Create a function for every native method
        // found in the component definition.
        //

        _importAPI(feature, instance, component.api);

        _initModel(feature, instance, component.model);

        //
        // Return a newly create component
        // instance to caller. This instance
        // can be used independently...
        //

        return instance;
    };

    //
    // Return the component feature object API.
    //

    return {

        singleton: false,

        value: _value
    };
});

fw.feature('fragment', function () {
    return {
        value: function (feature, id, deps, fun) {
            return { deps: deps, def: fun };
        }
    };
});
