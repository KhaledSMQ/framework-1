
//
// bootstrap.col3
//

fw.module('bootstrap').component('col3',  function () {
    return {
        description: 'bootstrap col 3 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-3 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

