
//
// mvc.components.base
//

fw.module('mvc.framework').component('base', 'core.util', function ($util) {
    return {
        description: 'Base component definition',
        template: null,
        placeholders: null,
        model: null,
        api: {

            //
            // Component default render method.
            // @param $this The runtime instance object value for component.
            //            

            render: function ($this) {

                if (fw.debug()) {
                    console.info('name: ' + $this.$def.name);
                    console.info('description: ' + $this.$def.description);
                }
            }
        }
    };
});

