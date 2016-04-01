
//
// bootstrap.col8
//

fw.module('bootstrap').component('col8', {
    description: 'bootstrap col 8 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-8 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

