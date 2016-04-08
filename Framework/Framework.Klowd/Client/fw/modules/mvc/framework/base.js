
//
// mvc.components.base
//

fw.module('mvc.framework').component('base', 'core.util, core.string', function ($util, $string) {
    return {
        description: 'Base component definition',
        api: {

            //
            // Component initialization function.
            //

            _init: function ($this) { },

            //
            // Component default render method.
            // @param $this The runtime instance object value for component.
            //            

            $anatomy: function ($this) {

                // #ifdef DEBUG

                fw.debug('COMPONENT:');
                fw.debug('    name..........: {0}', $this.$def.name);
                fw.debug('    base..........: {0}', $this.$def.base);
                fw.debug('    description...: {0}', $this.$def.description);
                fw.debug('    placeholders..: {0}', $util.toArray($this.$def.placeholders, function (name, _) { return name; }).join(', '));

                if ($util.isDefined($this.$def.properties)) {
                    fw.debug('    properties....: ');
                    $.each($this.$def.properties, function (name, def) {
                        fw.debug('                    {0} => {2}', name, def.type);
                    });
                }

                if ($util.isDefined($this.$def.model)) {
                    fw.debug('    model.........: ');
                    $.each($this.$def.model, function (name, def) {
                        fw.debug('                    {0} => {1}, {2}', name, def.kind, def.type);
                    });
                }

                fw.debug('INSTANCE:');
                fw.debug('    id............: {0}', $this.$id);
                fw.debug('    type..........: {0}', $this.$type);
                fw.debug('    model.........: ');
                $.each($this.$state.model, function (name, value) {
                    fw.debug('                    {0} => {1}', name, typeof value);
                });
                fw.debug('    api...........: ');
                $.each($this, function (name, def) {
                    if (!$string.startsWith(name, '$') && (typeof def == 'function')) {
                        fw.debug('                    {0}', name);
                    }
                });

                // #endif
            }
        }
    };
});

