
//
// bootstrap.col6
//

fw.module('mvc.framework.bootstrap').component('col6', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 6 object',
        template: '<div class="col-md-6 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

