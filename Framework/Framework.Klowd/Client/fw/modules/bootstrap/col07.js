
//
// bootstrap.col7
//

fw.module('bootstrap').component('col7',  function () {
    return {
        description: 'bootstrap col 7 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-7 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

