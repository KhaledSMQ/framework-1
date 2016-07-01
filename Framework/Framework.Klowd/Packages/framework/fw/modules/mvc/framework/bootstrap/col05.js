
//
// bootstrap.col5
//

fw.module('mvc.framework.bootstrap').component('col5', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 5 object',
        template: '<div class="col-md-5 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

