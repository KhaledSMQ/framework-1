
//
// html.h1
//

fw.module('mvc.framework.html').component('h1',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'h1',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<h1>{{ placeholders.MAIN }}</h1>')
        }
    };
});

