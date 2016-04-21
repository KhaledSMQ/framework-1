
//
// mvc.framework.base
//

fw.module('mvc.framework.core').component('base', 'core.util, core.string, mvc.engine.instance', function ($util, $string, $instance) {
    return {
        description: 'Framework base component definition',
        api: {

            //
            // Initialize the view component.
            // @param $this The component instance.
            //

            $constructor: function ($this) {
                $instance.model.init($this);
                $instance.data.init($this);
                $instance.resource.init($this);
            },

            //
            // Component type related functions
            //

            $is: function ($this, type) {
                return $instance.type.is($this, type);
            },

            $hierarchy: function ($this) {
                return $instance.type.hierarchy($this);
            },

            //
            // Model related functions.
            //

            $get: function ($this, name) {
                return $instance.model.get($this, name);
            },

            $set: function ($this, name, val) {
                return $instance.model.set($this, name, val)
            },

            //
            // Event related functions.
            //

            $on: function ($this, object, event, handler) {
                return $instance.events.on($this, object, event, handler);
            },

            $trigger: function ($this, object, event) {
                return $instance.events.trigger($this, object, event);
            },

            //
            // Debug related functions.
            //

            $this: function ($this) {
                return $instance.debug.instance($this);
            },

            $anatomy: function ($this) {
                return $instance.debug.anatomy($this);
            }
        }
    };
});

