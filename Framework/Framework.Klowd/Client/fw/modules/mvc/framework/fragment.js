
//
// mvc.framework.fragment
//

fw.module('mvc.framework').component('fragment', 'core.util, mvc.engine.component', function ($util, $c) {
    return {
        base: 'mvc.framework.view',
        description: 'User defined component.',
        model: {
            view: $c.property('view', $c.INOUT, null, $c.REQUIRED, null),
            binding: $c.property('binding', $c.INOUT, null, $c.OPTIONAL, null)
        },
        api: {
        }
    };
});

