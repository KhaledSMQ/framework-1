
//
// html.hr
//

fw.module('mvc.framework.html').component('hr',  function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'hr',
        model: {
            template: $c.property('template', $c.INOUT, null, $c.REQUIRED, '<hr />')
        }
    };
});

