
//
// bootstrap.col1
//

fw.module('mvc.framework.bootstrap').component('col12', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 12 object',
        template: '<div class="col-md-12 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

