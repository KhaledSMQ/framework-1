
//
// mvc.framework.fragment
//

fw.module('mvc.framework').component('fragment', 'core.util', function ($util) {
    return {
        base: 'mvc.framework.view',
        description: 'User defined view',
        template: '<div>{{ placeholders.MAIN }}</div>',
        placeholders: null,
        model: {
            view: {
                display: 'view',
                kind: 'INOUT',
                type: null,
                dft: null
            },
            binding: {
                display: 'binding',
                kind: 'INOUT',
                type: null,
                dft: null
            }
        },
        api: {
        }
    };
});

