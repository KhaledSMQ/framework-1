
//
// bootstrap.col10
//

fw.module('mvc.framework.bootstrap').component('col10', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 10 object',
        template: '<div class="col-md-10 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

