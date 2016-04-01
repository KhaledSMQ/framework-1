
//
// bootstrap.col1
//

fw.module('bootstrap').component('col1', {
    description: 'bootstrap col 1 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-1 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

