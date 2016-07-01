
//
// html.br
//

fw.module('mvc.framework.html').component('br', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'br',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<br />')
        }
    };
});

