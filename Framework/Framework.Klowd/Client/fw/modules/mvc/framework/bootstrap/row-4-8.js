
//
// bootstrap.row-4-8
//

fw.module('mvc.framework.bootstrap').component('row-4-8', function () {
    return {
        base: 'mvc.framework.core.template',
        description: 'bootstrap row object with two cols (4-8)',
        placeholders: { 'Left': {}, 'Right': {} },
        view: {}
    };
});

