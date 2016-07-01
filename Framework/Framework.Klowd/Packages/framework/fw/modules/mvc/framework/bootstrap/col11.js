
//
// bootstrap.col11
//

fw.module('mvc.framework.bootstrap').component('col11', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 11 object',
        template: '<div class="col-md-11 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

