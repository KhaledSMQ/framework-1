
//
// html.h2
//

fw.module('html').component('h2',  function () {
    return {
        description: 'h2',
        template: '<h2>{{ placeholders.MAIN }}</h2>',
        placeholders: { 'MAIN': {} }
    };
});

