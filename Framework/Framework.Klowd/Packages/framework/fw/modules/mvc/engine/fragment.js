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
        // Normalize the view. Worker function.
        //

        var _worker = function (view) {

            let nView = null;

            if (view instanceof Array) {

                //
                // new view is an empty array.
                //

                nView = [];

                //
                // List of components.
                //

                $util.apply(view, function (_, componentInstance) {

                    //
                    // Get a valid component definition.
                    //

                    var component = fw.get(componentInstance[$config.PROPERTY_COMPONENT_TYPE]);

                    if ($util.isDefined(component)) {

                        var content = {};

                        if ($util.isDefined(componentInstance.content)) {

                            if (componentInstance.content instanceof Array ||
                                $util.isDefined(componentInstance.content[$config.PROPERTY_COMPONENT_TYPE])) {

                                //
                                // Component must have a unique content placeholder 
                                // definition, otherwise this wont work...
                                //

                                var placeholder = '';

                                if ($util.isDefined(component.placeholders) && 1 == $util.count(component.placeholders)) {

                                    //
                                    // Get the name of the single placeholder.
                                    //

                                    $util.apply(component.placeholders, function (name, def) { placeholder = name; });

                                    //
                                    //
                                    // CASE: Content is an array of component instances. 
                                    //       generate each template and merge it. The component
                                    //       definition must contain one and only one content
                                    //       placeholder.
                                    //
                                    //
                                    // CASE: Content is an object, a single instance.
                                    //       and is *NOT* a content definition with placeholders.
                                    //       The component definition must contain one and only 
                                    //       one content placeholder.
                                    //
                                    //

                                    content[placeholder] = _normalize(componentInstance.content);
                                }
                                else {

                                    //
                                    // ERROR: Component definition needs to define a single placeholder.
                                    //

                                    throw 'component with namespace \'' + component.namespace + '\' and name \'' + component.name + '\' does not define a single placeholder!';
                                }
                            }
                            else {

                                //
                                // CASE: Content defines the placeholders.
                                //

                                $util.apply(componentInstance.content, function (placeholderName, placeholderContent) {

                                    content[placeholderName] = _normalize(placeholderContent);
                                });
                            }

                            //
                            // Change object.
                            //

                            componentInstance.content = content;
                        }
                        //
                        // else {
                        //
                        // Component instance does not have any content in it.
                        // No need to normalize.
                        //
                        // }
                    }
                    else {

                        throw 'component ' + componentInstance[$config.PROPERTY_COMPONENT_TYPE] + ' is not defined!';
                    }
                });
            }
            else
                if ($util.isDefined(view[$config.PROPERTY_COMPONENT_TYPE])) {

                    //
                    // One component.
                    //

                    view = _normalize([view]);
                }
                else {

                    //
                    // Placeholders.
                    //

                    $util.apply(view, function (name, content) { view[name] = _normalize(content); })
                }

            return nView;
        };
        
        //
        // Normalize the view and add the normalized view to the pipe.
        //

        _vAdd(scope, _worker(_vCurrent(scope)));

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