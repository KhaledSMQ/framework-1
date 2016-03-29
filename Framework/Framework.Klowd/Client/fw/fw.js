// ============================================================================
// Project: Framework
// Name/Class: fw
// Created On: 19/Jan/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
window.fw = undefined == window.fw ? {} : window.fw;
window.fw = jQuery.extend(true, window.fw, {

    //
    // Library name.
    //

    __LIB: 'fw',

    //
    // Error descriptors.
    //

    __ERRORS: {
    },

    //
    // Runtime values.
    //

    __MODULES: {},
    __FEATURES: {},
    __ARTIFACTS: {},
    __SINGLETON: {},

    //
    // CONFIG
    // Set of configuration settings for framework.
    //

    __CONFIG: {

        IDENTIFIER_SEPARATOR: '.',
        IDENTIFIER_PARCEL_RE: ''
    },

    //
    // Core API
    // Functions and function sets for basic
    // framework inner workings.
    //

    core: {

        //
        // MODULE
        //

        module: {

            add: function (id, deps) {

                //
                // If module does not exist, then create it,
                // setup the memory space for the new module,
                // initialize its artifact space.
                //

                if (!fw.core.module.has(id)) {

                    //
                    // Verify input arguments.
                    //

                    fw.core.verify(fw.core.verifyID(id), 'module identifier \'' + id + '\' is invalid!');

                    //
                    // Set the module object.
                    //

                    var val = {
                        name: id,
                        deps: deps
                    };

                    fw.core.module.set(id, val);
                }

                //
                // Return the API protocol for the module
                // this will allow the user to chain calls.
                //

                return fw.core.module.protocol(id);
            },

            get: function (id) { return fw.__MODULES[id]; },

            set: function (id, val) { fw.__MODULES[id] = val; },

            has: function (id) { return fw.core.defined(fw.core.module.get(id)); },

            list: function () {

                var lst = [];
                $.each(fw.__MODULES, function (name, _) { lst.push(name); });
                return lst;
            },

            protocol: function (module) {

                var protocol = {};

                //
                // Run all features and setup the 
                // protocol for the module.
                //

                $.each(fw.core.feature.list(), function (_, feature) {

                    //
                    // Add a new artifact for feature to an existing module.
                    // @param name The artifact name
                    // @param deps The artifact dependency list.
                    // @param value The artifact value.
                    //

                    protocol[feature] = function (name, deps, value) {
                        return fw.core.artifact.add(module, name, feature, deps, value);
                    };
                });

                return protocol;
            }
        },

        //
        // FEATURE
        //

        feature: {

            add: function (id, def) {

                //
                // Verify name.
                //

                fw.core.verify(fw.core.verifyID(id), 'invalid name for feature');

                if (!fw.core.feature.has(id)) {

                    //
                    // def :: {
                    //
                    //     //
                    //     // Function to get the value definition of the artifact.
                    //     // @param deps list of dependencies for artifact.
                    //     // @param def the definition object, dependent on the artifact.
                    //     // @return the runtime/singleton value for artififact.
                    //     //
                    //            
                    //     value :: function(deps, def) { ... }                                
                    // }
                    //

                    fw.core.feature.set(id, def);
                }

                return fw;
            },

            get: function (id) { return fw.__FEATURES[id]; },

            set: function (id, val) { fw.__FEATURES[id] = val; },

            list: function () {

                var lst = [];
                $.each(fw.__FEATURES, function (name, _) { lst.push(name); });
                return lst;
            },

            has: function (id) { return fw.core.defined(fw.core.feature.get(id)); }
        },

        //
        // ARTIFACTS
        //

        artifact: {

            add: function (module, name, feature, deps, def) {

                //
                // Verify input arguments.
                //

                fw.core.verify(fw.core.verifyID(module), 'invalid module identifier for artifact');
                fw.core.verify(fw.core.verifyID(name), 'invalid local name for artifact');

                //
                // Verify if module is valid.
                //

                fw.core.verify(fw.core.module.has(module), 'module is not defined');

                //
                // Verify if feature is valid.
                //

                fw.core.verify(fw.core.feature.has(feature), 'feature is not defined');

                //
                // In case the artifact has no dependencies.
                //

                if (!fw.core.defined(def)) {
                    def = deps;
                    deps = null;
                }

                //
                // Process request.
                //

                var id = fw.core.getID(module, name);

                if (!fw.core.artifact.has(id)) {

                    if (typeof deps == 'string') {
                        deps = [deps];
                    }

                    var defObj = {
                        feature: feature,
                        deps: deps,
                        def: def
                    };

                    fw.core.artifact.set(id, defObj);
                }

                return fw.core.module.protocol(module);
            },

            get: function (id) { return fw.__ARTIFACTS[id]; },

            set: function (id, val) { fw.__ARTIFACTS[id] = val; },

            list: function () {

                var lst = [];
                $.each(fw.__ARTIFACTS, function (name, _) { lst.push(name); });
                return lst;
            },

            has: function (id) { return fw.core.defined(fw.core.artifact.get(id)); },

            instance: function (id) {

                //
                // Check if value was already instantiated.
                //

                var value = fw.core.singleton.get(id);

                if (!fw.core.defined(value)) {

                    //
                    // Get the artifact definition.
                    //

                    var defObj = fw.core.artifact.get(id);

                    //
                    // Get the feature definition.
                    //

                    var featureDef = fw.core.feature.get(defObj.feature);
                    value = defObj.def;

                    if (fw.core.defined(featureDef) && fw.core.defined(featureDef.value)) {

                        //
                        // Instantiate the dependencies.
                        //

                        var deps = null;
                        if (fw.core.defined(defObj.deps)) {

                            deps = [];
                            $.each(defObj.deps, function (_, dep) {
                                deps.push(fw.core.artifact.instance(dep));
                            });
                        }

                        //
                        // Use the feature value definition to get the 
                        // actual artifact value.
                        //

                        value = featureDef.value(deps, value);
                    }

                    //
                    // Cache the value.
                    //

                    fw.core.singleton.set(id, value);
                }

                return value;
            }
        },

        //
        // SINGLETON       
        // Singleton are values indexed with an identifier.
        // This identifier will include the complete module
        // name and its local name.
        //

        singleton: {

            get: function (id) { return fw.__SINGLETON[id]; },

            set: function (id, val) { fw.__SINGLETON[id] = val; },

            list: function () {

                var lst = [];
                $.each(fw.__SINGLETON, function (name, _) { lst.push(name); });
                return lst;
            },

            has: function (id) { return fw.core.defined(fw.core.singleton.get(id)); }
        },

        //
        // Check if a value is defined or not.
        // @param obj The value to check.
        // @return true if the value os defined, false otherwise.
        //

        defined: function (obj) {

            //
            // Check if variable is defined and not null.
            //

            var defined = (typeof obj != 'undefined') && (obj != null);

            //
            // In case the variable is a string check 
            // if it is not an empty string.
            //

            if (defined && typeof obj == 'string') {
                defined = obj != "";
            }

            return defined;
        },

        //
        // Verify that a list of condition hold true,
        // if not throw a message, also defined in the
        // list of arguments.
        //

        verify: function () {

            var values = [];
            var msgs = [];

            $.each(arguments, function (idx, value) {
                if (typeof value == 'string') {
                    msgs.push(value);
                } else {
                    values.push(value);
                }
            });

            $.each(values, function (idx, condition) {
                if (!condition) {
                    throw msgs[idx];
                }
            });
        },

        //
        // Verify if the input value is a valid identifier.
        // @param id The identifier to verify
        // @return true if identifier is valid, false otherwise.
        //

        verifyID: function (id) {

            var output = true;
            var parcels = id.split(fw.__CONFIG.IDENTIFIER_SEPARATOR);

            if (parcels.length == 1) {
                output = fw.core.verifyIDParcel(id);
            }
            else {
                $.each(parcels, function (_, simple) {
                    output = output && fw.core.verifyIDParcel(simple);
                    return output;
                });
            }

            return output;
        },

        // 
        // Verify that a string satisfies the simple name spec.
        // @param name The name to verify
        // @return true if ok, false otherwise.
        //

        verifyIDParcel: function (parcel) {
            return fw.core.defined(parcel) && parcel.match(/[$a-zA-Z_][$a-zA-Z0-9_-]*/).length == 1;
        },

        //
        // Build an identifier from a list of arguments.
        // Join every argument separated by the identifier
        // separator character.
        //

        getID: function () {
            return Array.prototype.slice.call(arguments).join(fw.__CONFIG.IDENTIFIER_SEPARATOR);
        },

        //
        // Take a fullname and return a ordered list of the simple 
        // name parcels that compose it.
        // @param fullname The fullname to process
        // @return a list of simple name parcels
        //

        getParcels: function (id) {

            var parcels = [];

            if (fw.core.defined(id)) {

                //
                // Get the fullname parcels.
                //

                parcels = id.split(fw.__CONFIG.IDENTIFIER_SEPARATOR);

                //
                // Verify that they are valid.
                //

                $.each(parcels, function (_, simple) {
                    fw.core.verify(fw.core.verifyIDParcel(simple), 'parcel \'' + simple + '\' is not a valid simple name');
                });
            }

            return parcels;
        },

        //
        // Take a full artifact identifier and return
        // the module segment and simple name.
        //

        getModuleAndName: function (id) {

            var parcels = { module: null, name: null };

            if (fw.core.defined(id)) {

                //
                // Break the identifier into
                // a list of simple names.
                //

                parcels = id.split('.');

                //
                // Extract module and name.
                // Module is the set of all simple
                // identifier except the last one,
                // with is the local name.
                //

                parcels.module = parcels.slice(0, parcels.length - 1).join(fw.__CONFIG.IDENTIFIER_SEPARATOR);
                parcels.name = parcels[parcels.length - 1];
            }

            return parcels;
        },

        //
        // Display an internal error, use this for framework
        // related errors.
        //

        error: function (descriptor) {

            //
            // Base message.
            //

            var msg = '[' + fw.__LIB + ']:' + fw.__ERRORS[descriptor];

            //
            // Instantiate additional parameters, placeholder: {argN}
            //

            if (arguments.length > 1) {

                for (var i = 1, j = 0; i < arguments.length; i++, j++) {

                    msg = msg.replace('{arg' + j + '}', arguments[i]);
                }
            }

            //
            // Write final error message to console.
            //

            console.error(msg);
        }
    },

    //
    // Add a new module to the framework. If the module is already
    // defined then just return the module API protocol.
    // @param name The name for the module. (fully qualified name).
    // @return The module API object.
    //

    module: function (id, deps) {
        return fw.core.module.add(id, deps);
    },

    //
    // Add a new feature definition to framework.
    // @param id the name for the feature
    // @param def The feature definition
    // @return The framework object for chainning.
    // 

    feature: function (id, def) {
        return fw.core.feature.add(id, def);
    },

    //
    // Get the artifact with the specified identifier.
    // This is the complete, fully qualified name for the artifact.
    // @param id The identifier for the artifact to get.
    // @return The artifact runtime value.
    //

    get: function (id) {
        return fw.core.artifact.instance(id);
    }
});

