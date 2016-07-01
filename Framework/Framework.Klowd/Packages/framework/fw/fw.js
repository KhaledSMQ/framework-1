// ============================================================================
// Project: Framework
// Name/Class: fw
// Created On: 19/Jan/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
window.fw = undefined == window.fw || null == window.fw ? {} : window.fw;

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
    __DEBUG: false,

    //
    // CONFIG
    // Set of configuration settings for framework.
    //

    __CONFIG: {

        IDENTIFIER_SEPARATOR: '.',
        IDENTIFIER_PARCEL_RE: ''
    }
});

window.fw.core = jQuery.extend(true, window.fw.core, {

    //
    // Set or get the framework debug flag or
    // write a debug message.
    // @param val the debug flag value if boolean or
    // the debug message if not boolean.
    // @return the current debug flag value.
    //

    debug: function () {

        let prefix = '[FW:DEBUG]    ';

        if (1 == arguments.length) {

            let val = arguments[0];
            if (fw.core.defined(val)) {
                if (typeof val === 'boolean') {
                    fw.__DEBUG = val;
                }
                else if (fw.__DEBUG) {
                    if (typeof val === 'function') {
                        fw.log(prefix + JSON.stringify(val()));
                    }
                    else if (typeof val === 'string') {
                        fw.log(prefix + val)
                    }
                    else {
                        fw.log(prefix + JSON.stringify(val));
                    }
                }
            }
        }
        else {
            if (fw.__DEBUG && arguments.length > 1) {
                fw.log(prefix + fw.core.format.apply(this, arguments));
            }
        }

        return fw.__DEBUG;
    },

    //
    // Check if a value is defined or not.
    // @param obj The value to check.
    // @return true if the value os defined, false otherwise.
    //

    defined: function (obj) {
        return (typeof obj != 'undefined') && (obj != null);
    },

    //
    // Apply to an object or array a specific
    // function handler.
    // @param val The input value
    // @param fun The mapping function
    //

    apply: function (val, fun) {
        if (fw.core.defined(val) && fw.core.defined(fun)) {
            $.each(val, fun);
        }
    },

    //
    // Map an object or array to an equivalent
    // value type, but applying a function.
    // @param val The input value
    // @param fun The mapping function
    // @return a new value mapped with the function
    //

    map: function (val, fun) {

        var output = null;

        if (fw.core.defined(val) && fw.core.defined(fun)) {

            if (val instanceof Array) {

                output = [];
                $.each(val, function (idx, item) {
                    output.push(fun(idx, item));
                });
            }
            else if (typeof val == 'object') {

                output = {};
                $.each(val, function (property, value) {
                    output[property] = fun(property, value);
                });
            }
            else {
                output = fun(val);
            }
        }

        return output;
    },

    //
    // Map a value to an array
    // @param val The input value
    // @param fun The mapping function
    // @return an array with the mapping
    //

    toArray: function (val, fun) {

        var output = null;

        if (fw.core.defined(val) && fw.core.defined(fun)) {

            if (val instanceof Array) {

                output = fw.core.map(val, fun);
            }
            else if (typeof val == 'object') {

                output = [];
                $.each(val, function (property, value) {
                    output.push(fun(property, value));
                });
            }
            else {
                output = [fun(val)];
            }
        }

        return output;
    },

    //
    // Take a string with a set of placeholder, e.g. {0}, {1},
    // .. {n} and replace them with the actual values passed
    // in the rest of the arguments.
    //

    format: function () {
        var output = null;
        if (arguments.length > 1) {

            output = arguments[0];
            for (var i = 1, j = 0; i < arguments.length; i++, j++) {
                let str = typeof arguments[i] === 'string' ? arguments[i] : JSON.stringify(arguments[i]);
                output = output.replace('{' + j + '}', str);
            }
        }
        return output;
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

            parcels = id.split(fw.__CONFIG.IDENTIFIER_SEPARATOR);

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
    },

    //
    // Generate an API for an hash/object value.
    // @param obj The object to generate the API for.
    // @return An object with a set of functions.
    //

    hash: function (obj) {

        var _init = function () { obj = fw.core.defined(obj) ? obj : {}; };

        var _get = function (name) { return obj[name]; };

        var _set = function (name, val) { obj[name] = val; };

        var _keys = function () { return fw.core.toArray(obj, function (name, _) { return name; }); };

        var _values = function () { return fw.core.toArray(obj, function (_, val) { return val; }); };

        var _clear = function () { return fw.core.apply(obj, function (name, _) { delete obj[name]; }); };

        var _has = function (name) { return fw.core.defined(_get(name)); };

        return {
            init: _init,
            get: _get,
            set: _set,
            list: _keys,
            keys: _keys,
            values: _values,
            clear: _clear,
            has: _has
        };
    }
});

window.fw = jQuery.extend(true, window.fw, {

    //
    // Core API
    // Functions and function sets for basic
    // framework inner workings.
    //

    core: {

        //
        // MODULE
        //

        module: $.extend(true, fw.core.hash(fw.__MODULES), {

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

                    fw.core.module.set(id, { name: id, deps: deps });
                }

                //
                // Return the API protocol for the module
                // this will allow the user to chain calls.
                //

                return fw.core.module.api(id);
            },

            api: function (module) {
                return fw.core.map(fw.__FEATURES, function (feature, _) {

                    //
                    // Add a new artifact for feature to an existing module.
                    // @param name The artifact name
                    // @param deps The artifact dependency list.
                    // @param value The artifact value.
                    //

                    return function (name, deps, value) {
                        return fw.core.artifact.add(module, name, feature, deps, value);
                    };
                });
            },

        }),

        //
        // FEATURE
        //

        feature: $.extend(true, fw.core.hash(fw.__FEATURES), {

            add: function (id, deps, fun) {

                //
                // Verify name.
                //

                fw.core.verify(fw.core.verifyID(id), 'invalid name for feature');

                if (!fw.core.feature.has(id)) {

                    //
                    // Check if no dependencies were set.
                    //

                    if (!fw.core.defined(fun)) {

                        fun = deps;
                        deps = null;
                    }

                    var args = fw.core.map(deps, function (_, dep) { return fw.core.artifact.instance(dep); })

                    var feature = fun.apply(fun, args);

                    //
                    // Add other information to the feature
                    // object, things like id, dependecies, etc.
                    //

                    feature.id = id;
                    feature.deps = deps;

                    //
                    // Add the feature runtime object.
                    //

                    fw.core.feature.set(id, feature);
                }

                return fw;
            }

        }),

        //
        // ARTIFACTS
        //

        artifact: $.extend(true, fw.core.hash(fw.__ARTIFACTS), {

            add: function (module, name, feature, deps, def) {

                //
                // Verify input arguments.
                //

                fw.core.verify(fw.core.verifyID(module), 'invalid module identifier for artifact',
                               fw.core.verifyID(name), 'invalid local name for artifact',
                               fw.core.module.has(module), 'module is not defined',
                               fw.core.feature.has(feature), 'feature is not defined');

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

                        //
                        // If the list of dependencies is a string
                        // then we must check if it has more than
                        // one dependency.
                        //

                        var lstOfDeps = deps.split(',');

                        fw.core.apply(lstOfDeps, function (idx, dep) {
                            lstOfDeps[idx] = dep.trim();
                        });

                        deps = lstOfDeps;
                    }

                    //
                    // Build definition object for artifact.
                    //

                    var artifact = {
                        feature: feature,
                        deps: deps,
                        def: def
                    };

                    fw.core.artifact.set(id, artifact);
                }

                return fw.core.module.api(module);
            },

            value: function (id) {

                var value = null;

                if (fw.core.defined(id)) {

                    //
                    // Get the artifact definition.
                    //

                    var artifact = fw.core.artifact.get(id);

                    if (fw.core.defined(artifact)) {

                        //
                        // Get the feature definition.
                        //

                        var feature = fw.core.feature.get(artifact.feature);

                        if (fw.core.defined(feature)) {

                            //
                            // if feature is defined to generate
                            // singletons, then get the singleton
                            // and be done with it. By default,
                            // everything is a singleton.
                            //

                            var isSingleton = !fw.core.defined(feature.singleton) || feature.singleton;

                            //
                            // In case the feature is singletons
                            // and the value was already retrieved.
                            //

                            if (isSingleton) {

                                value = fw.core.singleton.get(id);

                                if (fw.core.defined(value)) {

                                    return value;
                                }
                            }

                            //
                            // Default value for the artifact
                            //

                            value = artifact.def;

                            //
                            // If feature associated with the artifact 
                            // defines a new handler, call it.
                            // 

                            if (fw.core.defined(feature.value)) {

                                //
                                // Instantiate the dependencies.
                                //

                                let deps = null;
                                if (fw.core.defined(artifact.deps)) {

                                    deps = fw.core.map(artifact.deps, function (_, dep) {
                                        return fw.core.artifact.value(dep);
                                    });
                                }

                                //
                                // Use the feature value definition 
                                // to get the actual artifact value.
                                //

                                value = feature.value(feature, id, deps, value);
                            }

                            //
                            // Cache the value.
                            //

                            if (isSingleton) {

                                fw.core.singleton.set(id, value);
                            }
                        }
                        else {

                            //
                            // ERROR: could not find feature for artifact with identifier 'id'.
                            //

                            fw.error('could not find feature for artifact with identifier \'' + id + '\'');
                        }
                    }
                    else {

                        //
                        // ERROR: artifact with identifier 'id' was not found!
                        //

                        fw.error('artifact with identifier \'' + id + '\' was not found!');
                    }
                }

                //
                // Return value for identifier, either a new
                // object or an object form the singleton
                // store.
                //

                return value;
            }

        }),

        //
        // SINGLETON       
        // Singleton are values indexed with an identifier.
        // This identifier will include the complete module
        // name and its local name.
        //

        singleton: fw.core.hash(fw.__SINGLETON),
    },

    //
    // Add a new module to the framework. If the module is already
    // defined then just return the module API protocol.
    // @param name The name for the module. (fully qualified name).
    // @return The module API object.
    //

    'module': function (id, deps) {
        return fw.core.module.add(id, deps);
    },

    //
    // Add a new feature definition to framework.
    // @param id the name for the feature
    // @param def The feature definition
    // @return The framework object for chainning.
    // 

    'feature': function (id, deps, def) {

        //
        // Check if we are defining a feature or
        // getting the feature definition object.
        //

        return (!fw.core.defined(deps) && !fw.core.defined(def))
            ? fw.core.feature.get(id)
            : fw.core.feature.add(id, deps, def);
    },

    //
    // Get the artifact value.
    // @param id the name for the artifact
    //

    'artifact': function (id) {
        return fw.core.artifact.get(id);
    },

    //
    // Get the artifact value with the specified identifier.
    // This is the complete, fully qualified name for the artifact.
    // @param id The identifier for the artifact to get.
    // @return The artifact runtime value.
    //

    'get': function (id) {
        return fw.core.artifact.value(id);
    },

    //
    // Set or get the framework debug flag.
    // @param val, if set then change the debug flag.
    // @return the current debug flag value.
    //

    'debug': function () {
        return fw.core.debug.apply(this, arguments);
    },

    //
    // Throw an error.
    // @param msg The message error to throw.
    //

    'error': function (msg) {
        console.error(msg);
    },

    //
    // Signal a warning.
    // @param msg The message warning to signal.
    //

    'warn': function (msg) {
        console.warn(msg);
    },

    //
    // Signal an information message.
    // @param msg The message info to signal.
    //

    'info': function (msg) {
        console.info(msg);
    },

    //
    // Signal a log message.
    // @param msg The message log to signal.
    //

    'log': function (msg) {
        console.log(msg);
    }

});

