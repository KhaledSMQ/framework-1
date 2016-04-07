
//
// bootstrap.col11
//

fw.module('bootstrap').component('col11',  function () {
    return {
        description: 'bootstrap col 11 object',
        properties: {
            style: {
                display: 'style',
                type: null,
                dft: ''
            }
        },
        template: '<div class="col-md-11 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

