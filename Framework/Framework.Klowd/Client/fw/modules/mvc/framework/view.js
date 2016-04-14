
//
// mvc.framework.view
//

fw.module('mvc.framework').component('view', 'core.util, core.string, mvc.engine.component', function ($util, $string, $c) {
    return {
        base: 'mvc.framework.base',
        description: 'User interface layer base component',
        model: {
            width: $c.property('width', $c.INOUT, null, $c.OPTIONAL, 0),
            height: $c.property('height', $c.INOUT, null, $c.OPTIONAL, 0)
        },
        api: {

            //
            // Main render method.
            // @param $this The component instance.
            //

            $render: function ($this) {
            }
        }
    };
});

