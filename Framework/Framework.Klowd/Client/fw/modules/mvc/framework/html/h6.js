
//
// html.h6
//

fw.module('mvc.framework.html').component('h6',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h6',
        template: '<h6>{{ placeholders.MAIN }}</h6>',
        placeholders: { 'MAIN': {} }
    };
});

