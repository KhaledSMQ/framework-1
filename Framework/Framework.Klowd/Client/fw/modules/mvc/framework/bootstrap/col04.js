
//
// bootstrap.col4
//

fw.module('mvc.framework.bootstrap').component('col4', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 4 object',
        template: '<div class="col-md-4 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

