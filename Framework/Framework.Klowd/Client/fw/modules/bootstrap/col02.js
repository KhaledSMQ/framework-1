
//
// bootstrap.col2
//

fw.module('bootstrap').component('col2', {
    description: 'bootstrap col 2 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-2 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

