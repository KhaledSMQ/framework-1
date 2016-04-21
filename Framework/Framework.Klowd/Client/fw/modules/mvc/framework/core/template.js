
//
// mvc.framework.template
//

fw.module('mvc.framework.core').component('template', 'core.util, core.string, mvc.engine.component', function ($util, $string, $c) {
    return {
        base: 'mvc.framework.core.view',
        description: 'View component based on a HTML template',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, ''),
            style: $c.property('style', $c.IN, null, $c.OPTIONAL, '')
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

