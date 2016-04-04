
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
    native: function ($util) {

        var $def = this;

        //

        function _render() {

            var instance = this;
        }

        //
        // API
        //

        return {
            render: _render
        };
    }
});

