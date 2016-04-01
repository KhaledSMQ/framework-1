// ============================================================================
// Project: Framework
// Name/Class: Component feature.
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.feature('component', {

    value: function (deps, def) {

        //
        // Component value definitions are objects
        // that contain the following properties:
        //
        //    o- base :: string
        //    o- description :: string
        //    o- properties :: object
        //    o- model :: object
        //    o- resources :: object 
        //    o- events :: object
        //    o- template :: object | string
        //    o- placeholders :: object
        //    o- native : function
        //

        var component = null;

        if (typeof def == 'object') {

            component = def;
            component.deps = deps;            
        }

        return component;
    }

});