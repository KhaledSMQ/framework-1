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

    //
    // Import an API set to a new component instance.
    // @param instance The component instance where to import the API.
    // @param api The API to import.
    //

    var _importAPI = function (instance, api) {

        if (fw.core.defined(api)) {

            $.each(api, function (name, fun) {

                instance[name] = function () {

                    //
                    // Attach the component instance
                    // object, this means that all
                    // function must declare first the
                    // component instance.
                    //

                    var args = [instance];

                    //
                    // TODO: Add other arguments that are sent 
                    // to function by the invocation.
                    //

                    //
                    // Call the function.
                    //

                    fun.apply(fun, args);
                };
            });
        }
    };

    //
    // Initialize the model for a specific instance.
    // @param instance The component instance
    // @param model The model definition.
    //

    var _initModel = function (instance, model) {

        instance.$model = {};
        instance.__state.model = {};

        if (fw.core.defined(model)) {

            $.each(model, function (name, def) {

                //
                // Set the initial value for the model
                // property, take it from the component
                // model definition.
                //

                _setModel(instance, name, (fw.core.defined(def) && fw.core.defined(def.dft)) ? def.dft : null);

                //
                // Hookup the setters/getters for the property.
                //

                Object.defineProperty(instance, name, {
                    get: function () { return _getModel(instance, name); },
                    set: function (val) { return _setModel(instance, name, val); }
                });

            });
        }
    };

    //
    // Get/Set the value of a specific model property.
    //

    var _getModel = function (instance, name) {

        // #ifdef DEBUG

        fw.debug('COMPONENT: ' +instance.id + ' :: ' + instance.type + ' => ' + '[GET, ' + name + ']');

        // #endif

        return instance.__state.model[name];
    };

    var _setModel = function (instance, name, val) {

        instance.__state.model[name] = val;

        // #ifdef DEBUG

        fw.debug('COMPONENT: ' + instance.id + ' :: ' + instance.type + ' => ' + '[SET, ' + name + ', ' + JSON.stringify(instance.__state.model[name]) + ']');

        // #endif
    };

    //
    // Return the component feature
    // object API.
    //

    return {

        singleton: false,

        value: function (id, deps, fun) {

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

                id: __INSTANCE__PREFIX + __INSTANCE__COUNT++,

                //
                // instance type, this is the component id.
                //

                type: id,

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

            var base = null;
            if (fw.core.defined(component.base)) {
                base = fw.get(component.base);
            }

            instance.$base = base;

            //
            // Process the base component instance API.
            // If the base is null or undefined, do nothing.
            //

            if (fw.core.defined(base)) {

                _importAPI(instance, base.$def.api);
            }

            //
            // Process the component instance API.
            // Create a function for every native method
            // found in the component definition.
            //

            _importAPI(instance, component.api);

            _initModel(instance, component.model);

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