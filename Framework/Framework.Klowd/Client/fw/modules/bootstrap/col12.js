
//
// bootstrap.col1
//

fw.module('bootstrap').component('col12', {
    description: 'bootstrap col 12 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-12 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

