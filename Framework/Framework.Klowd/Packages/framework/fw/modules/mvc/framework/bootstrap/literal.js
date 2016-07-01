
//
// bootstrap.literal
//

fw.module('mvc.framework.bootstrap').component('literal', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'render a literal string of caracters',
        model: {
            content: {
                display: 'content',
                type: null,
                kind: 'INOUT'
            }
        },
        template: '{{ model.content }}'
    };
});

