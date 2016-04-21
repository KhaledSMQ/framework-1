
//
// html.h5
//

fw.module('mvc.framework.html').component('h5',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h5',
        template: '<h5>{{ placeholders.MAIN }}</h5>',
        placeholders: { 'MAIN': {} }
    };
});

