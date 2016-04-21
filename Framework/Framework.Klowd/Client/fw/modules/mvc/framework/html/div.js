
//
// html.div
//

fw.module('mvc.framework.html').component('div', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'div',
        template: '<div>{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

