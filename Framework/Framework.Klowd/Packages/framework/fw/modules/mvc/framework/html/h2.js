
//
// html.h2
//

fw.module('mvc.framework.html').component('h2',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h2',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h2>{{ placeholders.MAIN }}</h2>')
        }
    };
});

