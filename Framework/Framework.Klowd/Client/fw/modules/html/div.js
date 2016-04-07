
//
// html.div
//

fw.module('html').component('div', function () {
    return {
        description: 'div',
        template: '<div>{{ placeholders.MAIN }}</div>',
        placeholders: { 'MAIN': {} }
    };
});

