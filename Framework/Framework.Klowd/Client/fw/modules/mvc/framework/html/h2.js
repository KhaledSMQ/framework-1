
//
// html.h2
//

fw.module('mvc.framework.html').component('h2',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h2',
        template: '<h2>{{ placeholders.MAIN }}</h2>',
        placeholders: { 'MAIN': {} }
    };
});

