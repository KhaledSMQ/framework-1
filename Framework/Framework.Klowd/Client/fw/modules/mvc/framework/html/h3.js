
//
// html.h3
//

fw.module('mvc.framework.html').component('h3',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h3',
        template: '<h3>{{ placeholders.MAIN }}</h3>',
        placeholders: { 'MAIN': {} }
    };
});

