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
    // Inherit an API set to a new component instance.
    // @param instance The component instance where to import the API.
    // @param api The API to import.
    //

    var _inherit_API = function (instance, api) {

        fw.core.apply(api, function (name, fun) {

            if ((typeof fun === 'function') && !fw.core.defined(instance[name])) {

                instance[name] = function () {

                    //
                    // Attach the component instance object, this means that all
                    // functions must declare first the component instance.
                    // Add other arguments that are sent to function by the invocation.
                    //

                    var args = [instance].concat(Array.prototype.slice.call(arguments));

                    //
                    // Call the function.
                    //

                    return fun.apply(fun, args);
                };
            }
        });
    };

    //
    // Inherit a model definition to a new component instance.
    // @param instance The component instance where to inherit the model definition
    // @param model the model properties object.
    //

    var _inherit_Model = function (instance, model) {

        instance.$model = fw.core.defined(instance.$model) ? instance.$model : {};

        fw.core.apply(model, function (name, def) {

            if (!fw.core.defined(instance.$model[name])) {

                instance.$model[name] = def;
            }
        });
    };

    //
    // Inherit a component definition.
    // @param instance The target component instance
    // @param component The component definition
    //

    var _inherit = function (instance, component) {
        if (fw.core.defined(component)) {
            _inherit_API(instance, component.api);
            _inherit_Model(instance, component.model);
        }
    }

    //
    // Get the value of a new feature element.
    // @param feature 
    // @param id The unique identifier for the feature artifact
    // @param deps The list of instantiated dependencies
    // @param fun The function for getting the artificat definition.
    // @return A new, instantiated and initialized component instance.
    //

    var _value = function (feature, id, deps, fun) {

        //
        // Start with building the component
        // instance basic structure.
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
            // Model definition, set of model properties
            // includes all accessible properties, from current
            // instance to all inherited ones.
            //

            $model: {},

            //
            // APIs.
            //

            
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
        // inherit the component to the new instance.
        // Implies adding model, api, etc.
        //

        _inherit(instance, component);

        //
        // Inherit the base definitions,
        // we need to inherit all the components
        // up the chain.
        //

        let base = fw.get(component.base);
        instance.$base = base;

        while (fw.core.defined(base)) {

            //
            // Inherit the base component definition
            // and move the current base up the chain.
            //

            _inherit(instance, base.$def);
            base = fw.get(base.$def.base);
        }

        //
        // Initialize component.
        // Run init function.
        //

        instance.$constructor();

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

