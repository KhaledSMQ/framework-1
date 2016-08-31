
//
// mvc.framework.core.view
//

fw.module('mvc.framework.core').component('view', 'core.util, core.string, mvc.engine.component', function ($util, $string, $c) {
    return {
        base: 'mvc.framework.core.base',
        description: 'User interface layer base component',
        placeholders: null,
        model: {
            width: $c.property('width', $c.INOUT, null, $c.OPTIONAL, 0),
            height: $c.property('height', $c.INOUT, null, $c.OPTIONAL, 0),
            content: $c.property('content', $c.INOUT, null, $c.OPTIONAL, null)
        },
        api: {

            //
            // Main render method.
            // @param $this The component instance.
            //

            $render: function ($this) {

                //
                // HTML Generation
                // ===============
                //
                // Generate the html for component. Check if component 
                // defines an html render method.
                //

                var _html = '';
                if ($util.isFunction($this.$html)) {

                    //
                    // Render html for all the content
                    // in this component.
                    //

                    if ($util.isObject($this.content)) {

                        var htmlContent = {};

                        $util.map($this.content, function (holderName, holderContent) {
                        });
                    }
                    else if ($util.isArray($this.content)) {

                        //
                        //
                        //
                    }
                    else if ($util.isString($this.content)) {

                        //
                        //
                        //
                    }
                }

                //
                // Attach the generated html to the container.
                //
            },

            //
            //
            //

            $tree: function () {

            },

            //
            // Component method to generate the relevant html
            // payload this method is used by render to generate
            // the render surface for this view-base component.
            //

            $html: function ($this, content) {
            }
        }
    };
});

