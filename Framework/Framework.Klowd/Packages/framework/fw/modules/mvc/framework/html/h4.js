
//
// html.h4
//

fw.module('mvc.framework.html').component('h4',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h4',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h4>{{ placeholders.MAIN }}</h4>')
        }
    };
});

