
//
// bootstrap.row
//

fw.module('bootstrap').component('row',  function () {
    return {
        description: 'bootstrap row object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="row {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

