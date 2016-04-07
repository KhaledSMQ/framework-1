
//
// bootstrap.col10
//

fw.module('bootstrap').component('col10', function () {
    return {
        description: 'bootstrap col 10 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-10 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

