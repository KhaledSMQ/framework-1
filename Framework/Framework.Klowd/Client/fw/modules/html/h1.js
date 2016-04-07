
//
// html.h1
//

fw.module('html').component('h1',  function () {
    return {
        description: 'h1',
        template: '<h1>{{ placeholders.MAIN }}</h1>',
        placeholders: { 'MAIN': {} }
    };
});

