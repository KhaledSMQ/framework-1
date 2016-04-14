
//
// bootstrap.row-3-9
//

fw.module('bootstrap').component('row-3-9', function () {
    return {
        description: 'bootstrap row object with two cols (3-9)',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        placeholders: { 'Left': {}, 'Right': {} },
        view: {}
    };
});

