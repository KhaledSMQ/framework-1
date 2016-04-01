
//
// bootstrap.col9
//

fw.module('bootstrap').component('col9', {
    description: 'bootstrap col 9 object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="col-md-9 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

