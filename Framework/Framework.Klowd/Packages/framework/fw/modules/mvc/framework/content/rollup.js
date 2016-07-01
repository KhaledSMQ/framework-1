
//
// mvc.framework.content.rollup
//

fw.module('mvc.framework.content').component('rollup', 'core.util, mvc.engine.component', function ($util, $c) {
    return {
        base: 'mvc.framework.core.template',
        description: 'display a list of items, according to an optional template value.',
        model: {
            list: $c.property('list', $c.INOUT, null, $c.REQUIRED, [])
        },
        api: {
        }
    };
});

