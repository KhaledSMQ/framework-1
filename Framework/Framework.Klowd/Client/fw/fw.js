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
    // Module instances.
    //

    __MODULES: {},
    __FEATURES: {},
    __SINGLETON: {},

    //
    // API
    //

    _api: {

        //
        // MODULES
        //

        module: {

            add: function (fullname, deps) {

                //
                // If module does not exist, then create
                // it, setup the memory space for the new
                // modules and its artifacts.
                //

                if (!fw._api.module.has(fullname)) {
                    fw._api.module.create(fullname, deps);
                }

                //
                // Return the API protocol for the module
                // this will allow the user to chain calls.
                //

                return fw._api.module.protocol(fullname);
            },

            create: function (fullname, deps) {

                var nameParcel = fw._api.util.getSimpleParcels(fullname);

                var module = {
                    name: fullname,
                    deps: deps,
                    artifacts: {}
                };

                fw.__MODULES[fullname] = module;

                return module;
            },

            get: function (name) {
                return fw.__MODULES[name];
            },

            list: function () {

                var lst = [];
                $.each(fw.__MODULES, function (name, def) { lst.push($.extend(true, def)); });
                return lst;
            },

            has: function (name) {
                return fw._api.util.defined(fw._api.module.get(name));
            },

            protocol: function (module) {

                var protocol = {};

                //
                // Run all features and setup the 
                // protocol for the module.
                //

                $.each(fw.__FEATURES, function (feature, _) {

                    //
                    // Add a new artifact for feature to an existing module.
                    // @param name The artifact name
                    // @param deps The artifact dependency list.
                    // @param value The artifact implementation.
                    //

                    protocol[feature] = function (name, deps, value) {

                        if (!fw._api.util.defined(value)) {
                            value = deps;
                            deps = null;
                        }

                        return fw._api.artifact.add(module, name, feature, deps, value);
                    };

                });

                return protocol;
            }
        },

        //
        // FEATURES
        //

        feature: {

            add: function (name, def) {

                //
                // Verify name.
                //

                fw._api.util.verify(fw._api.util.checkSimpleName(name), 'invalid name for feature');

                if (!fw._api.feature.has(name)) {
                    fw._api.feature.create(name, def);
                }

                return fw;
            },

            create: function (name, def) {

                //
                // def :: {
                //
                //     //
                //     // @param deps list of dependencies for artifact.
                //     // @param def the definition object, dependent on the artifact.
                //     // @return the runtime/singleton value for artififact.
                //     //
                //            
                //     value :: function(deps, def)
                //
                //
                // }
                //

                fw.__FEATURES[name] = def;
                return def;
            },

            get: function (name) { return fw.__FEATURES[name]; },

            list: function () {

                var lst = [];
                $.each(fw.__FEATURES, function (name, def) { lst.push($.extend(true, def)); });
                return lst;
            },

            has: function (name) { return fw._api.util.defined(fw._api.feature.get(name)); }
        },

        //
        // ARTIFACTS
        //

        artifact: {

            add: function (module, name, feature, deps, def) {

                //
                // Verify name.
                //

                fw._api.util.verify(fw._api.util.checkSimpleName(name), 'invalid name for artifact');

                if (!fw._api.artifact.has(module, name)) {
                    fw._api.artifact.create(module, name, feature, deps, def);
                }

                return fw._api.module.protocol(module);
            },

            create: function (module, name, feature, deps, def) {

                var modObj = fw._api.module.get(module);
                var fullName = fw._api.util.fullname(module, name);

                var defObj = {
                    feature: feature,
                    deps: deps,
                    def: def
                };

                modObj.artifacts[fullName] = defObj;

                return defObj;
            },

            get: function (module, name) {

                var modObj = fw._api.module.get(module);
                var fullname = fw._api.util.fullname(module, name);

                return modObj.artifacts[fullname];
            },

            has: function (module, name) {
                return fw._api.util.defined(fw._api.artifact.get(module, name));
            },

            instance: function (id) {

                //
                // Check if value was already instantiated.
                //

                var value = fw._api.singleton.get(id);

                if (!fw._api.util.defined(value)) {

                    //
                    // Parse the full identifier to get the
                    // module and name for the artifact.
                    //

                    var parcels = fw._api.util.parseModuleAndName(id);
                    var module = parcels.module;
                    var name = parcels.name;

                    //
                    // Now, get the artifact definition.
                    //

                    var defObj = fw._api.artifact.get(module, name);

                    //
                    // Get the feature definition.
                    //

                    var featureDef = fw._api.feature.get(defObj.feature);
                    value = defObj.def;

                    if (fw._api.util.defined(featureDef) && fw._api.util.defined(featureDef.value)) {

                        //
                        // Instantiate the dependencies.
                        //

                        var deps = null;

                        //
                        // Use the feature value definition to get the 
                        // actual feature value.
                        //

                        value = featureDef.value(deps, value);
                    }

                    //
                    // Cache the value.
                    //

                    value = fw._api.singleton.set(id, value);

                }

                return value;
            }
        },

        //
        // SINGLETONS
        //

        singleton: {

            get: function (id) {

                return fw.__SINGLETON[id];
            },

            set: function (id, val) {

                fw.__SINGLETON[id] = val;
                return val;
            },

            has: function (id) {
                return fw._api.util.defined(fw._api.singleton.get(id));
            }
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
                // In case the variable is a string check if
                // it is not an empty string.
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
            // Verify that a string satisfies the simple name spec.
            // @param name The name to verify
            // @return true if ok, false otherwise.
            //

            checkSimpleName: function (name) {
                return fw._api.util.defined(name) && name.match(/[$a-zA-Z][$a-zA-Z0-9_-]*/).length == 1;
            },

            //
            // Build a fullname for an artifact.
            // @param modName The module name
            // @param name The artifiact simple name.
            //

            fullname: function (modName, name) {
                return modName + '.' + name;
            },

            //
            // Take a fullname and return a ordered
            // list of the simple name parcels that
            // compose it.
            // @param fullname The fullname to process
            // @return a list of simple name parcels
            //

            getSimpleParcels: function (fullname) {

                var parcels = [];

                if (fw._api.util.defined(fullname)) {

                    //
                    // Get the fullname parcels.
                    //

                    parcels = fullname.split('.');

                    //
                    // Verify that they are valid.
                    //

                    $.each(parcels, function (_, simple) {
                        fw._api.util.verify(fw._api.util.checkSimpleName(simple), 'parcel \'' + simple + '\' is not a valid simple name');
                    });
                }

                return parcels;
            },

            //
            // Take a full artifact identifier and return
            // the module segment and simple name.
            //

            parseModuleAndName: function (fullname) {

                var parcels = { module: null, name: null };

                if (fw._api.util.defined(fullname)) {

                    //
                    // parse all identifiers.
                    //

                    parcels = fullname.split('.');

                    //
                    // extract module and name.
                    //

                    parcels.module = parcels.slice(0, parcels.length - 1).join('.');
                    parcels.name = parcels[parcels.length - 1];
                }

                return parcels;
            }
        }
    },

    //
    // Add a new module to the framework. If the module already
    // has then just return the module API protocol.
    // @param name The name for the module. (fully qualified name).
    // @return The module API object.
    //

    module: function (name, deps) {
        return fw._api.module.add(name, deps);
    },

    //
    // Add a new feature definition to framework.
    // @param name the name for the feature
    // @param def The feature definition
    // @return The framework object for chainning.
    // 

    feature: function (name, def) {
        return fw._api.feature.add(name, def);
    },

    //
    // Get the artifact with the specified name.
    // This is the complete, fully qualified 
    // name for the artifact.
    // @param id The name for the artifact to get.
    // @return The artifact runtime value.
    //

    get: function (id) {
        return fw._api.artifact.instance(id);
    }
});

