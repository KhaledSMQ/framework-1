
//
// bootstrap.col4
//

fw.module('bootstrap').component('col4', {
    description: 'bootstrap col 4 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-4 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

