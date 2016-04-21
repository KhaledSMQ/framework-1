
//
// html.h1
//

fw.module('mvc.framework.html').component('h1',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h1',
        template: '<h1>{{ placeholders.MAIN }}</h1>',
        placeholders: { 'MAIN': {} }
    };
});

