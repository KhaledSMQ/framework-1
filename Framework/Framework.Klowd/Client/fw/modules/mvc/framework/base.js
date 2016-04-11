
//
// mvc.components.base
//

fw.module('mvc.framework').component('base', 'core.util, core.string, mvc.engine.instance', function ($util, $string, $instance) {
    return {
        description: 'Base component definition',
        api: {

            //
            // Component initialization function.
            //

            _init: function ($this) { },

            //
            //
            //

            $get: function ($this, name) {
                return $instance.get($this, name);
            },

            $set: function ($this, name, val) {
                $instance.set($this, name, val)
            },

            $on: function ($this, object, event, handler) {
                $instance.on($this, object, event, handler);
            },

            $trigger: function ($this, object, event) {
                $instance.trigger($this, object, event);
            },

            //
            // Dump the component instance definition and 
            // current state to the debug console.            
            // @param $this This component instance.
            //            

            // #ifdef DEBUG
            $anatomy: function ($this) {
                $instance.anatomy($this);
            }
            // #endif
        }
    };
});

