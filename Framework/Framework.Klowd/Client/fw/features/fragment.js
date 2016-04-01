// ============================================================================
// Project: Framework
// Name/Class: Fragment feature.
// Created On: 27/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.feature('fragment', {

    value: function (deps, def) {

        //
        // Component value definitions are objects
        // that contain the following properties:
        //
        //    o- master :: string
        //    o- description :: string
        //    o- properties :: object
        //    o- model :: object
        //    o- resources :: object 
        //    o- events :: object
        //    o- placeholders :: object
        //    o- view :: object | array
        //    o- binding :: object | array
        //    o- rules : object
        //

        var fragment = null;

        if (typeof def == 'object') {

            fragment = def;
            fragment.deps = deps;            
        }

        return fragment;
    }

});