
//
// html.h4
//

fw.module('html').component('h4',  function () {
    return {
        description: 'h4',
        template: '<h4>{{ placeholders.MAIN }}</h4>',
        placeholders: { 'MAIN': {} }
    };
});

