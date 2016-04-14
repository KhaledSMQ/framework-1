
//
// utils.rollup
//

fw.module('utils').component('rollup', 'core.util', function ($util) {
    return {
        base: 'mvc.framework.view',
        description: 'display a list of items, according to an optional template value.',
        model: {
            list: {
                display: 'list',
                kind: 'INOUT',
                type: null,
                dft: []
            }
        },
        api: {
        }
    };
});

