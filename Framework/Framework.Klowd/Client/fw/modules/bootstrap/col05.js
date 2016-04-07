
//
// bootstrap.col5
//

fw.module('bootstrap').component('col5',  function () {
    return {
        description: 'bootstrap col 5 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-5 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

