
//
// bootstrap.col9
//

fw.module('mvc.framework.bootstrap').component('col9', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 9 object',
        template: '<div class="col-md-9 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    }
});

