
//
// bootstrap.col1
//

fw.module('mvc.framework.bootstrap').component('col1',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap col 1 object',
        template: '<div class="col-md-1 {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

