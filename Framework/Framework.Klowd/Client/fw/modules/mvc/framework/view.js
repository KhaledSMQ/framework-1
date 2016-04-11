
//
// mvc.framework.view
//

fw.module('mvc.framework').component('view', 'core.util, core.string, mvc.engine.instance', function ($util, $string, $instance) {
    return {
        base: 'mvc.framework.base',
        description: 'User interface layer base component',
        api: {
        }
    };
});

