
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
            // Component default render method.
            // @param $this The runtime instance object value for component.
            //            

            $anatomy: function ($this) {
                $instance.anatomy($this);
            }
        }
    };
});

