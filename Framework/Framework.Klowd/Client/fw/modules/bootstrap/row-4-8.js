
//
// bootstrap.row-4-8
//

fw.module('bootstrap').fragment('row-4-8',  function () {
    return {
        description: 'bootstrap row object with two cols (4-8)',
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

