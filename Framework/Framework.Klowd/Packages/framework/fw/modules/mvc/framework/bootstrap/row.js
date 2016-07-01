
//
// bootstrap.row
//

fw.module('mvc.framework.bootstrap').component('row', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap row object',
        template: '<div class="row {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

