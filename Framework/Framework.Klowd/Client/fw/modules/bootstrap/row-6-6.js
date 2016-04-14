
//
// bootstrap.row-6-6
//

fw.module('bootstrap').component('row-6-6',  function () {
    return {
        description: 'bootstrap row object with two cols (6-6)',
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

