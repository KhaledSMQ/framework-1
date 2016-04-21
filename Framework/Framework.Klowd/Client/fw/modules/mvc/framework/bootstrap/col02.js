
//
// bootstrap.col2
//

fw.module('mvc.framework.bootstrap').component('col2',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 2 object',
        template: '<div class="col-md-2 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

