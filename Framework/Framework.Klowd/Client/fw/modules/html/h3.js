
//
// html.h3
//

fw.module('html').component('h3',  function () {
    return {
        description: 'h3',
        template: '<h3>{{ placeholders.MAIN }}</h3>',
        placeholders: { 'MAIN': {} }
    };
});

