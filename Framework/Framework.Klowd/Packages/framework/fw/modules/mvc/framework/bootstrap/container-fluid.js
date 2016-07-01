
//
// bootstrap.container-fluid
//

fw.module('mvc.framework.bootstrap').component('container-fluid', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap fluid container object',
        template: '<div class="container-fluid {{ properties.style }}">{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

