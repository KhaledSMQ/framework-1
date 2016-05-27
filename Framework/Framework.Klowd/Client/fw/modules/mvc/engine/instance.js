// ============================================================================
// Project: Framework
// Name/Class: mvc.engine.instance
// Created On: 09/Abr/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc.engine').service('instance', 'core.util, core.string', function ($util, $string) {

    //
    // Initialize the model of a component instance.
    // @param $this The component instance
    // @param model The model definition to set.
    //

    var _model_init = function ($this) {

        $this.$state.model = {};

        // #ifdef DEBUG
        fw.debug('{0}: {1}::{2} => [_model_init]', 'COMPONENT', $this.$id, $this.$type);
        // #endif

        fw.core.apply($this.$model, function (name, def) {

            //
            // Set the initial value for the model
            // property, take it from the component
            // model definition.
            //

            _model_set($this, name, (fw.core.defined(def) && fw.core.defined(def.dft)) ? def.dft : null);

            //
            // Hookup the setters/getters for the property.
            //

            Object.defineProperty($this, name, {
                get: function () { return _model_get($this, name); },
                set: function (val) { return _model_set($this, name, val); }
            });
        });
    };

    //
    // Get the value of a specific object.
    // @param $this The component instance
    // @param name The name for the object
    // @return The object value
    //

    var _model_get = function ($this, name) {

        // #ifdef DEBUG

        fw.debug('{0}: {1}::{2} => [GET, {3}]', 'COMPONENT', $this.$id, $this.$type, name);

        // #endif

        //
        // Check if there are any event handlers,
        // and call them, by order.
        //

        _event_trigger($this, name, 'get');

        return $this.$state.model[name];
    };

    //
    // Set the value of a specific object.
    // @param $this The component instance
    // @param name The name for the object
    // @param val The value for the object.
    //

    var _model_set = function ($this, name, val) {

        //
        // Set the value.
        //

        $this.$state.model[name] = val;

        // #ifdef DEBUG

        fw.debug('{0}:: {1}::{2} => [SET, {3}, {4}]', 'COMPONENT', $this.$id, $this.$type, name, $this.$state.model[name]);

        // #endif

        //
        // Check if there are any event handlers,
        // and call them, by order.
        //

        _event_trigger($this, name, 'change');
    };

    //
    // Hook up an event for a specific object/event on a component
    // instance. 
    // @param $this The component instance
    // @param object The name for the object
    // @param event The event name to trigger
    // @param handler The function handler to be called. 
    //

    var _event_on = function ($this, object, event, handler) {

        if ($util.isDefined($this)) {

            if ($util.isDefined($this.$state.events)) {

                let eventName = object + '.' + event;

                if (!$util.isDefined($this.$state.events[eventName])) {

                    $this.$state.events[eventName] = [];
                }

                $this.$state.events[eventName].push(handler)
            }
        }
    };

    //
    // Trigger al event handlers for a specific object
    // name and event. Handlers are called in arbitrary
    // order. no assumption about this should be mada.    
    // @param $this The component instance
    // @param object The name for the object
    // @param event The event name to trigger
    // @param ... All remaining arguments are sent to handler(s).
    //

    var _event_trigger = function ($this, object, event) {

        if ($util.isDefined($this)) {

            if ($util.isDefined($this.$state.events)) {

                let eventName = object + '.' + event;

                if ($util.isDefined($this.$state.events[eventName])) {

                    $.each($this.$state.events[eventName], function (_, handler) {

                        handler($this);
                    });
                }
            }
        }
    };

    //
    // Check if a component instance is of
    // a certain component type.
    // @param $this The component instance
    // @param type The type of the component
    //

    var _type_is = function ($this, type) {
        let output = false;
        $util.apply(_type_hierarchy($this), function (_, pair) { output = pair.type == type; return !output; });
        return output;
    };

    //
    // Get the component path from the current
    // instance to the top most instance value.
    // @param $his The component instance
    // @return The hierarchy path, both types 
    // and instances.
    //

    var _type_hierarchy = function ($this) {

        var output = [];

        if ($util.isDefined($this)) {

            output = _type_hierarchy($this.$base);
            output.push({ type: $this.$type, id: $this.$id });
        }

        return output;
    };

    //
    // Generate the data API for the data object
    // found in the component instance.
    // @param $this the component instance.
    //

    var _data_init = function ($this) {

        $this.$data = fw.core.hash($this.$state.data);
        $this.$data.init();
    }

    //
    // Generate the resource API for the resource object
    // found in the component instance.
    // @param $this the component instance.
    //

    var _resource_init = function ($this) {

        $this.$resource = fw.core.hash($this.$state.resource);
        $this.$resource.init();
    }

    //
    // Output to the debug console a component 
    // instance internal information and state.
    // @param $this The component instance.
    //

    var _debug_anatomy_build = function ($this) {

        var obj = {};
        let hierarchy = _type_hierarchy($this);

        // COMPONENT

        obj.COMPONENT = {};
        obj.COMPONENT.name = $this.$def.name;
        obj.COMPONENT.hierarchy = $util.map(hierarchy, function (_, pair) { return pair.type; });
        obj.COMPONENT.description = $this.$def.description;
        obj.COMPONENT.model = $util.toArray($this.$def.model, function (name, def) { return { name: name, type: def.type, kind: def.kind }; });
        obj.COMPONENT.api = $util.toArray($this.$def.api, function (name, def) { return name; });

        // INSTANCE

        obj.INSTANCE = {};
        obj.INSTANCE.id = $this.$id;
        obj.INSTANCE.hierarchy = $util.map(hierarchy, function (_, pair) { return pair.id; });
        obj.INSTANCE.type = $this.$type;
        obj.INSTANCE.model = $util.toArray($this.$model, function (name, def) { return { name: name, type: def.type, kind: def.kind, value: $this.$state.model[name] }; });
        obj.INSTANCE.api = $util.toArray($this, function (name, def) { return name; });

        return obj;
    };

    var _debug_anatomy = function ($this) {

        let emptyTag = '<EMPTY>';

        //
        // COMPONENT
        //

        fw.debug('COMPONENT:');
        fw.debug('    name..........: {0}', $this.$def.name);

        //
        // hieararchy
        //

        let hierarchy = _type_hierarchy($this);
        fw.debug('    hierarchy.....: {0}', $util.map(hierarchy, function (_, pair) { return pair.type; }).join(' <= '));

        //
        // description
        //

        fw.debug('    description...: {0}', $this.$def.description);

        //
        // model
        //

        let defModelEmpty = !$util.isDefined($this.$def.model) || $util.empty($this.$def.model) ? emptyTag : '';
        fw.debug('    model.........: {0}', defModelEmpty);
        $.each($this.$def.model, function (name, def) {
            fw.debug('                    {0} :: {1}, {2}', name, def.type, def.kind);
        });

        //
        // api
        //

        let defApiEmpty = !$util.isDefined($this.$def.api) || $util.empty($this.$def.api) ? emptyTag : '';
        fw.debug('    api...........: {0}', defApiEmpty);
        $.each($this.$def.api, function (name, def) {
            fw.debug('                    {0}', name);
        });

        //
        // COMPONENT-INSTANCE
        //

        fw.debug('INSTANCE:');

        //
        // id
        //

        fw.debug('    id............: {0}', $this.$id);

        //
        // base (hierarchy
        //

        fw.debug('    hierarchy.....: {0}', $util.map(hierarchy, function (_, pair) { return pair.id; }).join(' <= '));

        //
        // type
        //

        fw.debug('    type..........: {0}', $this.$type);

        //
        // model
        //

        let instModelEmpty = !$util.isDefined($this.$model) || $util.empty($this.$model) ? emptyTag : '';
        fw.debug('    model.........: {0}', instModelEmpty);
        $.each($this.$model, function (name, def) {
            fw.debug('                    {0} :: [{1}, {2}] = {3}', name, def.type, def.kind, $this.$state.model[name]);
        });

        //
        // api
        //

        fw.debug('    api...........: ');
        $.each($this, function (name, def) {
            if (typeof def == 'function') {
                fw.debug('                    {0}', name);
            }
        });
    };

    //
    // API
    //

    return {

        //
        // Model related functions/methods.
        //

        model: {
            init: _model_init,
            get: _model_get,
            set: _model_set
        },

        //
        // Event related functions/methods.
        //

        events: {
            on: _event_on,
            trigger: _event_trigger
        },

        //
        // Type related functions/methods.
        //

        type: {
            is: _type_is,
            hierarchy: _type_hierarchy
        },

        //
        // Data hash related API.
        //

        data: {
            init: _data_init
        },

        //
        // Resource hash related API.
        //

        resource: {
            init: _resource_init
        },

        //
        // Debug related functions/methods.
        //

        debug: {
            instance: _debug_anatomy_build,
            anatomy: _debug_anatomy
        }
    };
});