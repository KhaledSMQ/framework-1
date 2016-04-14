
//
// mvc.framework.fragment
//

fw.module('mvc.framework').component('fragment', 'core.util, mvc.engine.component', function ($util, $component) {
    return {
        base: 'mvc.framework.view',
        description: 'User defined component.',
        model: {
            view: $component.property('view', $component.INOUT, null, $component.REQUIRED, null),
            binding: $component.property('binding', $component.INOUT, null, $component.OPTIONAL, null)
        },
        api: {
        }
    };
});

