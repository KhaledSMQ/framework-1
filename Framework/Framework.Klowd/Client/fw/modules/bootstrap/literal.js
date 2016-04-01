
//
// bootstrap.literal
//

fw.module('bootstrap').component('literal', {
    description: 'render a literal string of caracters',
    model: {
        content: {
            display: 'content',
            type: null,
            kind: 'INOUT'
        }
    },
    template: '{{ model.content }}'
});

