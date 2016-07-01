
//
// html.div
//

fw.module('mvc.framework.html').component('div', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'div',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<div>{{ placeholders.MAIN }}</div>')
        }
    };
});

