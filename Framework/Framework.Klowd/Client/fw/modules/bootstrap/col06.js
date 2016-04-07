
//
// bootstrap.col6
//

fw.module('bootstrap').component('col6',  function () {
    return {
        description: 'bootstrap col 6 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-6 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

