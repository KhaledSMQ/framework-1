
//
// bootstrap.col8
//

fw.module('mvc.framework.bootstrap').component('col8', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 8 object',
        template: '<div class="col-md-8 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

