
//
// mvc.framework.data
//

fw.module('mvc.framework').component('data', 'core.util, core.string', function ($util, $string) {
    return {
        base: 'mvc.framework.base',
        description: 'Data layer base component',
        api: {

            //
            // Initialize the data component.
            // @param $this The component instance.
            //

            $init: function ($this) {

                //
                // Call base component initialize method.
                //

                $this.$base.$init();
            }
        }
    };
});

