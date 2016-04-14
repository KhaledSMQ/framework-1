
//
// mvc.framework.view
//

fw.module('mvc.framework').component('view', 'core.util, core.string, mvc.engine.component', function ($util, $string, $component) {
    return {
        base: 'mvc.framework.base',
        description: 'User interface layer base component',
        model: {
            width: $component.property('width', $component.INOUT, null, $component.OPTIONAL, 0),
            height: $component.property('height', $component.INOUT, null, $component.OPTIONAL, 0)
        },
        api: {

            //
            // Initialize the view component.
            // @param $this The component instance.
            //

            $init: function ($this) {

                
                 // Call base component initialize method.
                

                $this.$base.$init();
            },

            //
            // Main render method.
            // @param $this The component instance.
            //

            $render: function ($this) {
            }


        }
    };
});

