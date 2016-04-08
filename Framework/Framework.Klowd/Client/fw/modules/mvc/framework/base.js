
//
// mvc.components.base
//

fw.module('mvc.framework').component('base', 'core.util', function ($util) {
    return {
        description: 'Base component definition',      
        api: {

            //
            // Component default render method.
            // @param $this The runtime instance object value for component.
            //            

            $anatomy: function ($this) {

                // #ifdef DEBUG
                
                fw.debug('COMPONENT:');
                fw.debug('    name.........: {0}', $this.$def.name);
                fw.debug('    description..: {0}', $this.$def.description);
                fw.debug('INSTANCE:');
                fw.debug('    id...........: {0}', $this.id);
                fw.debug('    type.........: {0}', $this.type);

                // #endif
            }
        }
    };
});

