
//
// utils.rollup
//

fw.module('utils').component('rollup', 'core.util', function ($util) {
    return {
        description: 'display a list of items, according to an optional template value.',
        template: '<div>{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': null },
        model: {
            list: {
                display: 'list',
                kind: 'INOUT',
                type: null,
                dft: []
            }
        },
        api: {

            render: function ($this) {

                console.info('$util: ' + JSON.stringify($util));
                console.info('description: ' + JSON.stringify($this.$def.description));
            }
        }
    };
});

