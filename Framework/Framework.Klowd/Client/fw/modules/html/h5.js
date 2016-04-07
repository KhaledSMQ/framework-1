
//
// html.h5
//

fw.module('html').component('h5',  function () {
    return {
        description: 'h5',
        template: '<h5>{{ placeholders.MAIN }}</h5>',
        placeholders: { 'MAIN': {} }
    };
});

