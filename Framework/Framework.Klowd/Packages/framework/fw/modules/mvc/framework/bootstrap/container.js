
//
// bootstrap.container
//

fw.module('mvc.framework.bootstrap').component('container', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap container object',
        template: '<div class="container {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

