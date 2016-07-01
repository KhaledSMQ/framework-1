
//
// html.h3
//

fw.module('mvc.framework.html').component('h3',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h3',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h3>{{ placeholders.MAIN }}</h3>')
        }
    };
});

