
//
// html.h5
//

fw.module('mvc.framework.html').component('h5',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h5',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h5>{{ placeholders.MAIN }}</h5>')
        }
    };
});

