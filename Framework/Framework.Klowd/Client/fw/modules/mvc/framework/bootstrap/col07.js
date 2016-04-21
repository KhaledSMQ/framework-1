
//
// bootstrap.col7
//

fw.module('mvc.framework.bootstrap').component('col7', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 7 object',
        template: '<div class="col-md-7 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

