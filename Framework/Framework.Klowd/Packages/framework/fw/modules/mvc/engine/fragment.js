// ============================================================================
// Project: Framework
// Name/Class: mvc.engine.fragment
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('mvc.engine').service('fragment', 'core.util, core.sequence, mvc.engine.config, mvc.engine.scope, mvc.engine.view', function ($util, $seq, $config, $scope, $view) {

    //
    // Library name.
    //

    var __LIB = 'mvc.engine.fragment';
    var _rootScope = null;

    //
    // Initialize the fragment rendering service.
    // This function initialzes the fragment rendering
    // pipeline.
    //

    var _init = function () {

        _rootScope = $scope.root();
    };

    //
    // Render a fragment bit on a specific container.
    // @param parent The parent scope object.
    // @param container The HTML DOM element where to render the fragment.
    // @param fragment The fragment to render.
    //

    var _render = function (parent, container, fragment) {

        //
        // Setup the rendering scope.
        //

        var scope = $scope.new($util.isDefined(parent) ? parent : _rootScope, container, fragment);

        //
        // Build the render sequence.
        //

        var seq = [
            _load,
            _master,
            _merge,
            _preprocess,
            _model,
            _normalize,
            _tree,
            _html,
            _resize
        ];

        //
        // Execute the render sequence.
        //

        $seq.run(scope, seq);

        return scope;
    };

    //
    // Load the fragment to render.
    //

    var _load = function (scope, done) {

        let cFragment = _fCurrent(scope);
        let nFragment = null;

        //
        // Transform the input fragment into an array
        // of elements. This is the most generic data
        // type for fragments.
        //

        if ($util.isString(cFragment)) {

            nFragment = JSON.parse(cFragment);
        }
        else if ($util.isObject(scope.fragment)) {

            nFragment = cFragment;
        }
        else {

            //
            // ERROR: Input data type for fragment is not supported.            
            //
        }

        //
        // Add the processed fragment to the pipeline.
        // Also start the model/view/controller datatypes.
        //

        _mAdd(scope, nFragment.model);
        _vAdd(scope, nFragment.view);
        _fAdd(scope, nFragment);

        //
        // Proceed to next steps..
        //

        done(scope);
    };

    //
    // Load all master fragments.
    //

    var _master = function (scope, done) {

        done(scope);
    };

    //
    // Merge all master fragments.
    //

    var _merge = function (scope, done) {

        done(scope);
    };

    //
    // Apply the registered pre processing tokens.
    //

    var _preprocess = function (scope, done) {

        done(scope);
    };

    //
    // Preprocess model structures.
    //

    var _model = function (scope, done) {

        let cModel = _mCurrent(scope);

        let nModel = cModel;

        _mAdd(scope, nModel);

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Normalize the view to render.
    //

    var _normalize = function (scope, done) {

        //
        // Normalize the view.
        //

        let cView = _vCurrent(scope);

        let nView = cView;

        _vAdd(scope, nView);

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Build component tree.
    //

    var _tree = function (scope, done) {

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Generate the HTML for the fragment.
    //

    var _html = function (scope, done) {

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Apply the resize behaviour to the fragment. 
    //

    var _resize = function (scope, done) {

        done(scope);
    };

    //
    // Fragment/Model/View related helpers.
    //

    var _fCurrent = function (scope) {
        return _xCurrent(scope, 'fragment');
    }

    var _fAdd = function (scope, val) {
        return _xAdd(scope, 'fragment', val);
    }

    var _mCurrent = function (scope) {
        return _xCurrent(scope, 'model');
    }

    var _mAdd = function (scope, val) {
        return _xAdd(scope, 'model', val);
    }

    var _vCurrent = function (scope) {
        return _xCurrent(scope, 'view');
    }

    var _vAdd = function (scope, val) {
        return _xAdd(scope, 'view', val);
    }

    var _xCurrent = function (scope, property) {

        let curr = null;

        if ($util.isArray(scope[property])) {

            let len = scope[property].length;
            if (len > 0) {

                curr = scope[property][len - 1];
            }
        }
        else if ($util.isDefined(scope[property])) {

            curr = scope[property];
        }

        return curr;
    };

    var _xAdd = function (scope, property, val) {

        if (!$util.isDefined(scope[property])) {

            scope[property] = [];
        }

        if (!$util.isArray(scope[property])) {

            let curr = scope[property];
            scope[property] = [];
            scope[property].push(curr);
        }

        scope[property].push(val);
    };

    //
    // API
    //

    return {
        'render': _render
    };
});