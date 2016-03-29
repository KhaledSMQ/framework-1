// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc').service('view', 'core.util, mvc.config', function ($util, $config) {

    //
    // Normalize a view tree datatype.
    // @param view
    // @param errorFun
    //

    var _normalize = function (view, errorFun) {

        if (view instanceof Array) {

            //
            // List of components.
            //

            $.each(view, function (compIndex, componentInstance) {

                //
                // Get a valid component definition.
                //

                var component = fw.get(componentInstance[$config.PROPERTY_COMPONENT_TYPE]);

                if ($util.isDefined(component)) {

                    var content = {};

                    if ($util.isDefined(componentInstance.content)) {

                        if (componentInstance.content instanceof Array || $util.isDefined(componentInstance.content[$config.PROPERTY_COMPONENT_TYPE])) {

                            //
                            // Component must have a unique content placeholder definition,
                            // otherwise this wont work...
                            //

                            var placeholder = '';

                            if ($util.isDefined(component.placeholders) && 1 == $util.count(component.placeholders)) {

                                //
                                // Get the name of the single placeholder.
                                //

                                $.each(component.placeholders, function (name, def) { placeholder = name; });

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

                                content[placeholder] = _normalize(componentInstance.content, errorFun);
                            }
                            else {

                                //
                                // ERROR: Component definition needs to define a single placeholder.
                                //

                                errorFun(___LIB + ': component with namespace \'' + component.namespace + '\' and name \'' + component.name + '\' does not define a single placeholder!');
                            }
                        }
                        else {

                            //
                            // CASE: Content defines the placeholders.
                            //

                            $.each(componentInstance.content, function (placeholderName, placeholderContent) {

                                content[placeholderName] = _normalize(placeholderContent, errorFun);
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

                    errorFun('component ' + componentInstance[$config.PROPERTY_COMPONENT_TYPE] + ' is not defined!');
                }
            });
        }
        else
            if ($util.isDefined(view[$config.PROPERTY_COMPONENT_TYPE])) {

                //
                // One component.
                //

                view = _normalize([view], errorFun);
            }
            else {

                //
                // Placeholders.
                //

                $.each(view, function (name, content) {

                    view[name] = _normalize(content, errorFun);
                })
            }

        return view;
    };

    //
    // Take a normalized view and build the document tree in document order.
    // @param view
    // @param errorFun
    // @return The tree of components in document order
    //

    var _buildTree = function (view, errorFun) {

        var output = [];

        //
        // Traverse each component instance in content.
        //

        if (view instanceof Array) {

            $.each(view, function (idx0, fragment) {

                //
                // Initialize this node value.
                //

                var node = {};

                //
                // Check if this is an object.
                //

                if (typeof fragment === 'object' && !(fragment instanceof Array)) {

                    //
                    // Get a valid component definition.
                    //

                    var component = fw.get(fragment.name);

                    //
                    // Render the component only if we have a valid
                    // ui component definition.
                    //

                    if ($util.isDefined(component)) {

                        //
                        // Caracterize the component imstance.
                        // This will be used for the fragment spec.
                        //

                        node = {
                            id: null,
                            def: component,
                            options: fragment.options,
                            properties: fragment.properties,
                            content: null
                        };

                        //
                        // Process children component instances, place then 
                        // in the appropriate content placeholder.
                        //

                        if ($util.isDefined(fragment.content)) {

                            node.content = {};

                            $.each(fragment.content, function (placeholderName, placeholderContent) {

                                node.content[placeholderName] = _buildTree(placeholderContent, errorFun);
                            });
                        }
                    }
                }
                else {

                    //
                    // ERROR: Was expecting an object...
                    //

                    errorFun('content does appear to be normalized!, was expecting an object type, not an array...');
                }

                //
                // concat the processed nodes into a final array.
                //

                output.push(node);
            });
        }
        else {

            //
            // ERROR: Content does appear to be normalized.
            //

            errorFun('content does appear to be normalized');
        }

        //
        // Return the view tree in document order.
        //

        return output;
    };

    //
    // Catamorphisms on component trees.
    // @param tree The component tree to process
    // @param genes The callback set for the catamorphism.
    //                    
    //                      empty       :: function() 
    //                      node        :: function(root, placeholders)
    //                      placeholder :: function(name, [ ... ])
    //                      root        :: function([node])
    //                      error       :: function(msg)
    //
    // @return The result of the operation... whetever type that might be...
    //

    var _cata = function (tree, genes) {

        //
        // Traverse each component instance in content.
        //

        var _cataRec = function (value) {

            let output = [];

            if (value instanceof Array) {

                if (value.length == 0) {

                    //
                    // CASE: No nodes in tree.
                    //

                    output = genes.empty();
                }
                else {

                    //
                    // CASE: Nodes in tree are > 0
                    //

                    $.each(value, function (idx0, node) {

                        //
                        // Check if this is an object.
                        //

                        if (typeof node === 'object' && !(node instanceof Array)) {

                            var content = null;

                            if ($util.isDefined(node.content)) {

                                content = {};

                                $.each(node.content, function (placeholderName, placeholderContent) {

                                    content[placeholderName] = genes.placeholder(placeholderName, _cataRec(placeholderContent));
                                });
                            }

                            //
                            // Call the node gene.
                            //

                            output.push(genes.node(node, content));

                        }
                        else {

                            //
                            // ERROR: Was expecting an object...
                            //

                            genes.error('content does appear to be normalized!, was expecting an object type, not an array...');
                        }
                    });
                }
            }
            else {

                //
                // ERROR: Content does appear to be normalized.
                //

                genes.error('content does appear to be normalized');
            }

            //
            // Return processed tree to caller.
            //

            return output;
        };

        //
        // Process final tree.
        //

        return $util.isDefined(genes.root) ? genes.root(_cataRec(tree)) : _cataRec(tree);
    };

    //
    // Walk/traverse a component tree in a specified order
    // @param tree The tree to traverse
    // @param genes The action to apply to each node.
    //
    //                      action :: function( node )
    //                      error  :: function(msg)
    //
    // @param order the document order to traverse, 'PRE-ORDER'/'POST-ORDER'
    //

    var _walk = function (tree, genes, order) {

        //
        // PRE-ORDER
        //

        var _preOrder = function (value) {

            if (value instanceof Array && value.length != 0) {

                //
                // CASE: Nodes in tree are > 0
                //

                $.each(value, function (idx0, node) {

                    //
                    // Check if this is an object.
                    //

                    if (typeof node === 'object' && !(node instanceof Array)) {

                        //
                        // Visit node *BEFORE* children nodes.
                        //

                        genes.action(node);

                        //
                        // Visit children *AFTER* root node.
                        //

                        if ($util.isDefined(node.content)) {

                            $.each(node.content, function (placeholderName, placeholderContent) { _preOrder(placeholderContent); });
                        }
                    }
                    else {

                        //
                        // ERROR: Was expecting an object...
                        //

                        genes.error('content does appear to be normalized!, was expecting an object type, not an array...');
                    }
                });
            }
        };

        //
        // POST-ORDER
        //

        var _postOrder = function (value) {

            if (value instanceof Array && value.length != 0) {

                //
                // CASE: Nodes in tree are > 0
                //

                $.each(value, function (idx0, node) {

                    //
                    // Check if this is an object.
                    //

                    if (typeof node === 'object' && !(node instanceof Array)) {

                        //
                        // Visit children *BEFORE* root node.
                        //

                        if ($util.isDefined(node.content)) {

                            $.each(node.content, function (placeholderName, placeholderContent) { _postOrder(placeholderContent); });
                        }

                        //
                        // Visit node *AFTER* children nodes.
                        //

                        genes.action(node);
                    }
                    else {

                        //
                        // ERROR: Was expecting an object...
                        //

                        genes.error('content does appear to be normalized!, was expecting an object type, not an array...');
                    }
                });
            }
        };

        //
        // Based on the specified order process the tree.
        //

        var trimmedOrder = order.trim().toUpperCase();
        switch (trimmedOrder) {

            case 'PRE-ORDER': _preOrder(tree); break;
            case 'POST-ORDER': _postOrder(tree); break;
        }
    };

    //
    // API
    //

    return {
        normalize: _normalize,
        buildTree: _buildTree,
        cata: _cata,
        walk: _walk
    };
});