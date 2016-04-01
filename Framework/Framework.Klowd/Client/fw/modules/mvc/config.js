// ============================================================================
// Project: Framework
// Name/Class: mvc.config
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc').service('config', 'core.util', function ($util) {

    //
    // Default name for application manifest, in
    // case the user does not define a value use this.
    //

    var _DEFAULT_MANIFEST_URL = 'manifest.url';

    //
    // Property name where the component type is defined.
    //

    var _PROPERTY_COMPONENT_TYPE = 'name';

    //
    // Base name for native jQuery plugins.
    //

    var _PLUGIN_BASE_NAME = '__PLUGIN';

    //
    // API
    //

    return {
        DEFAULT_MANIFEST_URL: _DEFAULT_MANIFEST_URL,
        PROPERTY_COMPONENT_TYPE: _PROPERTY_COMPONENT_TYPE,
        PLUGIN_BASE_NAME: _PLUGIN_BASE_NAME
    };
});