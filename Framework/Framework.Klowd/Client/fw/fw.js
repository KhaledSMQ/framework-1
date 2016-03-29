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
    // API
    //

    api: {

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

                if (!fw.api.module.has(id)) {

                    //
                    // Verify input arguments.
                    //

                    fw.api.util.verify(fw.api.util.verifyID(id), 'module identifier \'' + id + '\' is invalid!');

                    //
                    // Set the module object.
                    //

                    var val = {
                        name: id,
                        deps: deps
                    };

                    fw.api.module.set(id, val);
                }

                //
                // Return the API protocol for the module
                // this will allow the user to chain calls.
                //

                return fw.api.module.protocol(id);
            },

            get: function (id) { return fw.__MODULES[id]; },

            set: function (id, val) { fw.__MODULES[id] = val; },

            has: function (id) { return fw.api.util.defined(fw.api.module.get(id)); },

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

                $.each(fw.api.feature.list(), function (_, feature) {

                    //
                    // Add a new artifact for feature to an existing module.
                    // @param name The artifact name
                    // @param deps The artifact dependency list.
                    // @param value The artifact value.
                    //

                    protocol[feature] = function (name, deps, value) {                      
                        return fw.api.artifact.add(module, name, feature, deps, value);
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

                fw.api.util.verify(fw.api.util.verifyID(id), 'invalid name for feature');

                if (!fw.api.feature.has(id)) {
                    
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

                    fw.api.feature.set(id, def);
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

            has: function (id) { return fw.api.util.defined(fw.api.feature.get(id)); }
        },

        //
        // ARTIFACTS
        //

        artifact: {

            add: function (module, name, feature, deps, def) {

                //
                // Verify input arguments.
                //

                fw.api.util.verify(fw.api.util.verifyID(module), 'invalid module identifier for artifact');
                fw.api.util.verify(fw.api.util.verifyID(name), 'invalid local name for artifact');
                
                //
                // Verify if module is valid.
                //

                fw.api.util.verify(fw.api.module.has(module), 'module is not defined');

                //
                // Verify if feature is valid.
                //

                fw.api.util.verify(fw.api.feature.has(feature), 'feature is not defined');

                //
                //
                //

                if (!fw.api.util.defined(def)) {
                    def = deps;
                    deps = null;
                }

                //
                // Process request.
                //

                var id = fw.api.util.getID(module, name);

                if (!fw.api.artifact.has(id)) {

                    if (typeof deps == 'string') {
                        deps = [deps];
                    }

                    var defObj = {
                        feature: feature,
                        deps: deps,
                        def: def
                    };

                    fw.api.artifact.set(id, defObj);
                }

                return fw.api.module.protocol(module);
            },

            get: function (id) { return fw.__ARTIFACTS[id]; },

            set: function (id, val) { fw.__ARTIFACTS[id] = val; },

            has: function (id) { return fw.api.util.defined(fw.api.artifact.get(id)); },

            instance: function (id) {

                //
                // Check if value was already instantiated.
                //

                var value = fw.api.singleton.get(id);

                if (!fw.api.util.defined(value)) {     

                    //
                    // Get the artifact definition.
                    //

                    var defObj = fw.api.artifact.get(id);

                    //
                    // Get the feature definition.
                    //

                    var featureDef = fw.api.feature.get(defObj.feature);
                    value = defObj.def;

                    if (fw.api.util.defined(featureDef) && fw.api.util.defined(featureDef.value)) {

                        //
                        // Instantiate the dependencies.
                        //

                        var deps = null;
                        if (fw.api.util.defined(defObj.deps)) {

                            deps = [];
                            $.each(defObj.deps, function (_, dep) {
                                deps.push(fw.api.artifact.instance(dep));
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

                    fw.api.singleton.set(id, value);
                }

                return value;
            }
        },

        //
        // SINGLETON
        //
        // Singleton are values indexed with an identifier.
        // This identifier will include the complete module
        // name and its local name.
        //

        singleton: {

            get: function (id) { return fw.__SINGLETON[id]; },

            set: function (id, val) { fw.__SINGLETON[id] = val; },

            has: function (id) { return fw.api.util.defined(fw.api.singleton.get(id)); }
        },

        //
        // UTILS
        //

        util: {

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
                    output = fw.api.util.verifyIDParcel(id);
                }
                else {
                    $.each(parcels, function (_, simple) {
                        output = output && fw.api.util.verifyIDParcel(simple);
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
                return fw.api.util.defined(parcel) && parcel.match(/[$a-zA-Z_][$a-zA-Z0-9_-]*/).length == 1;
            },

            //
            // Build a fullname for an artifact.
            // @param module The module name
            // @param name The artifiact simple name.
            //

            getID: function (module, name) {
                return module + fw.__CONFIG.IDENTIFIER_SEPARATOR + name;
            },

            //
            // Take a fullname and return a ordered list of the simple 
            // name parcels that compose it.
            // @param fullname The fullname to process
            // @return a list of simple name parcels
            //

            getParcels: function (id) {

                var parcels = [];

                if (fw.api.util.defined(id)) {

                    //
                    // Get the fullname parcels.
                    //

                    parcels = id.split(fw.__CONFIG.IDENTIFIER_SEPARATOR);

                    //
                    // Verify that they are valid.
                    //

                    $.each(parcels, function (_, simple) {
                        fw.api.util.verify(fw.api.util.verifyIDParcel(simple), 'parcel \'' + simple + '\' is not a valid simple name');
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

                if (fw.api.util.defined(id)) {

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
        }
    },

    //
    // Add a new module to the framework. If the module is already
    // defined then just return the module API protocol.
    // @param name The name for the module. (fully qualified name).
    // @return The module API object.
    //

    module: function (id, deps) {
        return fw.api.module.add(id, deps);
    },

    //
    // Add a new feature definition to framework.
    // @param id the name for the feature
    // @param def The feature definition
    // @return The framework object for chainning.
    // 

    feature: function (id, def) {
        return fw.api.feature.add(id, def);
    },

    //
    // Get the artifact with the specified identifier.
    // This is the complete, fully qualified name for the artifact.
    // @param id The identifier for the artifact to get.
    // @return The artifact runtime value.
    //

    get: function (id) {
        return fw.api.artifact.instance(id);
    }
});

