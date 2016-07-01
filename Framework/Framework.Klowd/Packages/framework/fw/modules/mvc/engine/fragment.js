// ============================================================================
// Project: Framework
// Name/Class: mvc.fragment
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc.engine').service('fragment', 'core.util, core.sequence, mvc.engine.config, mvc.engine.scope, mvc.engine.view', function ($util, $seq, $config, $scope, $view) {
  
    //
    // Library name.
    //

    var __LIB = 'mvc.fragment';

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

        var scope = $scope.new(parent, container, fragment);

        //
        // Build the render sequence.
        //

        var seq = [
            _loadFragment,
            _loadMaster,
            _mergeFragments,
            _applyPreprocessing,
            _processPrefixes,
            _processModel,
            _normalizeView,
            _buildTree,
            _generateHtml,
            _attachComponents,
            _applyResize
        ];

        //
        // Execute the render sequence.
        //

        $seq.run(scope, seq);
    };

    //
    // Load the fragment to render.
    //

    var _loadFragment = function (scope, done) {

        if (typeof scope.fragment.original == 'string') {

        }
        else {

            //
            // Signal end of function.
            //

            done(scope);
        }
    };

    //
    // Load all master fragments.
    //

    var _loadMaster = function (scope, done) {

        if (toolkit.util.IsDefined(scope.fragment.original.master)) {

            //
            // Setup the url and request to load.
            //

            var absUrl = scope.app.factory.$resolver.resolve('[__MASTER_PAGES__]:' + scope.fragment.original.master + scope.app.config.pages.extension);
            var webRequest = { url: absUrl, method: 'GET' };

            //
            // Load he master fragment.
            //

            scope.app.factory.$http.get(webRequest, function (master) {

                //
                // If fragment loads sucessfully,
                // set the current master fragment.
                //

                scope.master = master;
                done(scope);

            }, error);

        }
        else {

            //
            // No master to load, signal end of function.
            //

            done(scope);
        }
    };

    //
    // Merge all master fragments.
    //

    var _mergeFragments = function (scope, done, error) {

        //
        // Function to merge two fragments, one
        // master fragment and one child fragment.
        // @return The merged fragment between the two.
        //

        var _merge = function (master, child) {

            //
            // Get from the child the content associated 
            // with a  placeholder name.
            //

            var _getContent = function (name) {

                var content = null;

                $.each(child.view, function (idx, elm) {

                    if ((toolkit.util.IsDefined(elm.options)) && (elm.options.placeholder == name)) {

                        content = elm.content;
                        return false;
                    }
                })

                return content;
            };

            var _merge = function (root) {

                var output = null;

                //
                // List of elements, replace one at a time.
                //

                if (root instanceof Array) {

                    output = [];

                    $.each(root, function (idx, elm) {
                        output.push(_merge(elm));
                    });
                }
                else {

                    //
                    // Check if the current node is a placeholder,
                    // if so, try to get the content for it.
                    //

                    if (root.name == "platform.placeholder") {

                        var name = root.options.name;
                        var inst = _getContent(name);

                        if (toolkit.util.IsDefined(inst)) {

                            output = _merge(inst);
                        }
                        else {

                            output = root;
                        }
                    }
                    else {

                        output = $.extend(false, {}, root);

                        if (toolkit.util.IsDefined(root.content)) {
                            
                            output.content = _merge(root.content);
                        }
                    }
                }

                return output;
            }

            //
            // Compute merged fragment.
            //

            master.view = _merge(master.view);
            master.model = $.extend(true, {}, child.model, master.model);

            return master;
        }

        //
        // Merge the master fragment and the main fragment.
        // If no master is defined then do nothing.
        //

        if (toolkit.util.IsDefined(scope.master)) {

            //
            // Merge the fragment with its master fragments.
            //

            scope.fragment.merged = _merge(scope.master, scope.fragment.original);

        }
        else {

            scope.fragment.merged = scope.fragment.original;
        }

        //
        // Change the view to match the merged fragment.
        //

        scope.view.original = scope.fragment.merged.view;

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Apply the registered pre processing tokens.
    //

    var _applyPreprocessing = function (scope, done, error) {

        var _getFun = function (name) {

            var funRepo = {

                'http-get': function (scope, args, success, error) {

                    var url = args[0];

                    url = scope.app.factory.$resolver.resolve(url);

                    var request = {
                        url: url,
                        type: 'json'
                    };

                    scope.app.factory.$http.get(request, function (value) { success(value); }, error);
                }
            };

            return funRepo[name];
        };

        var _buildSeq = function (obj) {

            var output = [];

            function __traverse(value, objValue, propName) {

                if (toolkit.util.IsDefined(value)) {

                    //
                    // We are looking for string values with
                    // a specific format.
                    //

                    if (typeof (value) === 'string') {

                        var trimmed = value.trim();

                        if (trimmed.startsWith('<<') && trimmed.endsWith('>>')) {

                            //
                            // Cutoff starting and ending brackets.
                            //

                            trimmed = trimmed.slice(2, trimmed.length - 2);

                            //
                            // Parse function name and arguments.
                            //

                            var sepIndex = trimmed.indexOf(':');

                            if (-1 != sepIndex) {

                                var fun = trimmed.substring(0, sepIndex).trim().toLowerCase();
                                var args = trimmed.substring(sepIndex + 1).split(',');

                                if (toolkit.util.IsDefined(args) && args.length > 0) {

                                    //
                                    // Preprocess the args.
                                    //

                                    $.each(args, function (idx, val) { args[idx] = val.trim(); });
                                }

                                //
                                // Build the function to run. 
                                //

                                var funToRun = function (scope, done, error) {

                                    var repoFun = _getFun(fun);
                                    repoFun(scope, args, function (val) {

                                        //
                                        // Change the value.
                                        //

                                        if (toolkit.util.AreDefined(objValue, propName)) {

                                            objValue[propName] = val;
                                        }

                                        //
                                        // Continue sequence.
                                        //

                                        done(scope);

                                    }, error);
                                }

                                //
                                // Push the function to the stack of functions to run.
                                //

                                output.push(funToRun);
                            }
                        }
                    } else
                        if (typeof (value) === 'object') {

                            //
                            // Mark this object as seen.
                            // Traverse all properties.
                            //

                            $.each(value, function (property, val) { __traverse(val, value, property); });
                        }
                        else
                            if (value instanceof Array) {

                                //
                                // Traverse all items of array.
                                //

                                $.each(value, function (index, val) { __traverse(val); });
                            }
                }
            }

            __traverse(obj);

            return output;
        };

        //
        // Build the sequence of functions to call in document order.
        //

        var seq = _buildSeq(scope.fragment.merged);

        //
        // Run the sequence, changing whatever is needed.
        // At the end run the i'm done function.
        //

        toolkit.sequence.Run(scope, seq, { finish: done, error: scope.app.factory.$msg.error })
    };

    //
    // Process prefixes.
    //

    var _processPrefixes = function (scope, done, error) {

        if (toolkit.util.IsDefined(scope.fragment.merged.prefix)) {

            $.each(scope.fragment.merged.prefix, function (prefix, ns) {
                toolkit.xprefix.Set(scope.prefix, prefix, ns);
            });
        }

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Preprocess model structures.
    //

    var _processModel = function (scope, done, error) {

        //
        // Extract need properties for this function.
        //

        var model = scope.fragment.merged.model;
        var processedModel = model;

        //
        // Preprocess the fragment model bit.
        //

        if (toolkit.util.IsDefined(model)) {

            $.each(model, function (prop, value) {

                var newValue = value;

                //
                // TODO: Eventually remove this....
                // When pages are updated to use new format.
                //

                newValue = toolkit.util.IsDefined(value)
                    && (typeof value == 'object')
                    && toolkit.util.IsDefined(value.dftValue)
                    ? value.dftValue : value;

                //
                // Change processed value mapping.
                // 

                processedModel[prop] = newValue;
            });

            //
            // Set the new page model bit.
            // 

            scope.model = processedModel;
        }

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Normalize the view to render.
    //

    var _normalizeView = function (scope, done, error) {

        //
        // Normalize the view.
        //

        scope.view.normalized = fwr.view.normalize(scope.view.original, error);

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Build component tree.
    //

    var _buildTree = function (scope, done, error) {

        //
        // Build the scope component tree.
        // this is the working fragment tree to use.
        //

        scope.tree = fwr.view.buildTree(scope.view.normalized, scope.app.factory.$msg.error);

        //
        // Generate the full node instance.
        //

        fwr.view.walk(
            scope.tree,
            {
                action: function (node) {

                    //
                    // Node related.
                    //

                    node.id = scope.app.factory.$id.get();
                    node.type = node.def.type;
                    node.namespace = node.def.namespace;
                    node.name = node.def.name;
                    node.nativeName = node.def.nativeName,
                    node.constants = node.def.constants;
                    node.callbacks = node.def.callbacks;

                    //
                    // Context related.
                    //

                    node.app = scope.app;
                    node.factory = scope.app.factory;
                    node.scope = scope;

                },
                error: error
            },
            'PRE-ORDER'
        );

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Generate the HTML for the fragment.
    //

    var _generateHtml =function (scope, done, error) {

        //
        // Push settings for template engine.
        //

        var currTemplateSettings = toolkit.util.Clone(_.templateSettings);
        _.templateSettings = { interpolate: /\{\{(.+?)\}\}/g };

        //
        // Generate the HTML for the component tree.
        //

        var htmlPayLoad = fwr.view.cata(
            scope.tree,
            {
                empty: function () {
                    return '';
                },

                node: function (parent, placeholders) {

                    var htmlView = '';

                    //
                    // Process component instance options.
                    // Merge the defined options for the component
                    // with the component instance options.
                    //

                    var mergedOptions = {};
                    $.extend(true, mergedOptions, parent.def.options, parent.options);
                    parent.options = mergedOptions;

                    //
                    // Process binding.
                    //

                    fwr.binding.bindComponent(scope, parent);

                    //
                    // Process template.
                    //

                    var template = parent.def.template;

                    if (toolkit.util.IsDefined(template)) {

                        //
                        // Assemble the object to send to the 
                        // template engine.
                        //

                        var obj = {
                            id: parent.id,
                            namespace: parent.namespace,
                            name: parent.name,
                            constant: parent.constants,
                            option: parent.options,
                            nativeName: parent.nativeName,
                            content: placeholders
                        };

                        var compiled = _.template(template);

                        htmlView = compiled(obj);

                        //
                        // Attach framework information.
                        //

                        var wrapperObj = $(htmlView);

                        if (0 == wrapperObj.length) {

                            //
                            // DO NOTHING... for know..
                            //

                            fwr.warn('component with namespace \'' + parent.namespace + '\' and name \'' + parent.name + '\' does not define a root element!');
                        }
                        else
                            if (1 == wrapperObj.length) {

                                //
                                // One root element, process it.
                                //

                                wrapperObj.attr('id', parent.id);
                                wrapperObj.attr('data-fw-id', parent.id);
                                wrapperObj.attr('data-fw-namespace', parent.namespace);
                                wrapperObj.attr('data-fw-name', parent.name);
                                wrapperObj.attr('data-fw-native', parent.nativeName);

                                //
                                // Wrap the changed object and unwrap it to get its html.
                                //

                                htmlView = $('<div/>').append(wrapperObj).html();
                            }
                            else {

                                //
                                // ERROR: Components cannot have more than one root element.
                                //

                                scope.app.factory.$msg.error('component with namespace \'' + parent.namespace + '\' and name \'' + parent.name + '\' defines more than one root element!');
                            }
                    }
                    else {

                        //
                        // TODO: This is possibly an error, no template for component.
                        //

                        scope.app.factory.$msg.error('component with namespace \'' + parent.namespace + '\' and name \'' + parent.name + '\' does not define a template!');
                    }

                    return htmlView;
                },

                placeholder: function (name, lst) {

                    var htmlPayload = '';
                    $.each(lst, function (idx, val) { htmlPayload += val; });
                    return htmlPayload;
                },

                root: function (lst) {

                    var htmlPayload = '';
                    $.each(lst, function (idx, val) { htmlPayload += val; });
                    return htmlPayload;
                },

                error: error
            });

        //
        // Pop settings for template engine.
        //

        _.templateSettings = currTemplateSettings;

        //
        // Add the generated HTML to the scope.
        //

        scope.html = htmlPayLoad;

        //
        // Attach the generated HTML to the root element of fragment.
        //

        scope.container.html(htmlPayLoad);

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Attach the components to DOM elements.
    //

    var _attachComponents = function (scope, done, error) {

        fwr.view.walk(
            scope.tree,
            {
                action: function (node) {
                    if (node.type == 'PLUGIN') {
                        toolkit.util.AttachPlugin(node.id, node.nativeName, node);
                    }
                },
                error: error
            },
            'POST-ORDER'
        );

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // Apply the resize behaviour to the fragment. 
    //

    var _applyResize = function (scope, done, error) {

        fwr.view.walk(
            scope.tree,
            {
                action: function (node) {
                    if (node.type == 'PLUGIN') {
                        toolkit.util.AttachPlugin(node.id, node.nativeName, 'resize');
                    }
                },
                error: error
            },
            'PRE-ORDER'
        );

        //
        // Signal end of function.
        //

        done(scope);
    };

    //
    // API
    //

    return {        
    };
});