
//
// bootstrap.container-fluid
//

fw.module('bootstrap').component('container-fluid', {
    description: 'bootstrap fluid container object',
    properties: {
        style: {
            display: 'style',
            type: null,
            dft: ''
        }
    },
    template: '<div class="container-fluid {{ properties.style }}">{{ placeholders.MAIN }}</div>',
    placeholders: { 'MAIN': {} }
});

