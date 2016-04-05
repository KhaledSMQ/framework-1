
//
// utils.rollup
//

fw.module('utils').component('rollup', 'core.util', {
    description: 'diplay a list of items',
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
    native: function ($instance, $util) {

        //

        var _render = function() {            
        }

        //
        // API
        //

        return {
            render: _render
        };
    }
});

