
//
// mvc.framework.view
//

fw.module('mvc.framework').component('view', 'core.util, core.string', function ($util, $string) {
    return {
        base: 'mvc.framework.base',
        description: 'User interface layer base component',
        api: {
        }
    };
});

