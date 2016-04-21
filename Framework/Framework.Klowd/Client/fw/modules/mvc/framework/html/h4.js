
//
// html.h4
//

fw.module('mvc.framework.html').component('h4',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h4',
        template: '<h4>{{ placeholders.MAIN }}</h4>',
        placeholders: { 'MAIN': {} }
    };
});

