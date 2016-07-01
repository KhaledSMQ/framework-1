
//
// html.h6
//

fw.module('mvc.framework.html').component('h6',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h6',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h6>{{ placeholders.MAIN }}</h6>')
        }
    };
});

