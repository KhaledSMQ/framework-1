
//
// bootstrap.col3
//

fw.module('mvc.framework.bootstrap').component('col3', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 3 object',
        template: '<div class="col-md-3 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

