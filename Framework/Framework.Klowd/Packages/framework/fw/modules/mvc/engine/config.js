// ============================================================================
// Project: Framework
// Name/Class: mvc.engine.config
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('mvc.engine').service('config', 'core.util', function ($util) {

    //
    // Default name for application manifest, in
    // case the user does not define a value use this.
    //

    var _DEFAULT_MANIFEST_URL = 'manifest.url';

    //
    // Property name where the component instance ID is defined.
    //

    var _PROPERTY_INSTANCE_ID = 'id';

    //
    // Property name where the component instance TYPE is defined.
    //

    var _PROPERTY_INSTANCE_TYPE = 'type';

    //
    // Property name where the component instance MODEL is defined.
    //

    var _PROPERTY_INSTANCE_MODEL = 'model';

    //
    // Property name where the component instance CONTENT is defined.
    //

    var _PROPERTY_INSTANCE_CONTENT = 'content';

    //
    // Base name for native jQuery plugins.
    //

    var _PLUGIN_BASE_NAME = '__PLUGIN';

    //
    // API
    //

    return {
        DEFAULT_MANIFEST_URL: _DEFAULT_MANIFEST_URL,
        PROPERTY_INSTANCE_TYPE: _PROPERTY_INSTANCE_TYPE,
        PROPERTY_INSTANCE_ID: _PROPERTY_INSTANCE_ID,
        PROPERTY_INSTANCE_CONTENT: _PROPERTY_INSTANCE_CONTENT,
        PLUGIN_BASE_NAME: _PLUGIN_BASE_NAME
    };
});