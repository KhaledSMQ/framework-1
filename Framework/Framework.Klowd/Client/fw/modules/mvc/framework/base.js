
//
// mvc.framework.base
//

fw.module('mvc.framework').component('base', 'core.util, core.string, mvc.engine.instance', function ($util, $string, $instance) {
    return {
        description: 'Base component definition',
        api: {

            //
            // Component related functions
            //

            $hierarchy: function ($this) {
                return $instance.hierarchy($this);
            },

            $is: function ($this, type) {
                return $instance.is($this, type);
            },

            //
            // Model related functions.
            //

            $get: function ($this, name) {
                return $instance.get($this, name);
            },

            $set: function ($this, name, val) {
                $instance.set($this, name, val)
            },

            //
            // Event related functions.
            //

            $on: function ($this, object, event, handler) {
                $instance.on($this, object, event, handler);
            },

            $trigger: function ($this, object, event) {
                $instance.trigger($this, object, event);
            },

            // #ifdef DEBUG
            $anatomy: function ($this) {
                $instance.anatomy($this);
            }
            // #endif
        }
    };
});

