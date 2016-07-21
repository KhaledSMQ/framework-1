// ============================================================================
// Project:
// Name/Class: 
// Created On: 20/Jul/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company:
// Description:
// ============================================================================

'use strict';
angular.module('fw').config(function ($sceDelegateProvider) {

    //
    // White list.
    //

    $sceDelegateProvider.resourceUrlWhitelist([

      // 
      // Allow same origin resource loads.
      //

      'self'
    ]);

    // 
    // Black list.
    // The blacklist overrides the whitelist so the open 
    // redirect here is blocked.
    //
    // $sceDelegateProvider.resourceUrlBlacklist([ ]);
    //
});

angular.module('fw.engine').service('fw.engine.app', [
    'fw.engine.core',
    'fw.engine.startup',
    'fw.engine.settings',
    'fw.engine.locales',
    'fw.engine.resx',
    'fw.engine.resolver',
    'fw.engine.pages',
    'fw.engine.components',
    'fw.engine.templates',
    'fw.engine.endpoints',
    function (core, start, settings, locales, resx, resolver, pages, components, templates, endpoints) {

        //
        // Create a new angular based application object
        // based on a more abstract specification.
        //

        var _create = function (app) {

            var ngApp = angular.module(app.name, _modules(app));

            settings.define(ngApp, app);
            locales.define(ngApp, app);
            resx.define(ngApp, app);
            resolver.define(ngApp, app);
            pages.define(ngApp, app);
            components.define(ngApp, app);
            endpoints.define(ngApp, app);
            start.define(ngApp, app);
            templates.define(ngApp, app);

            _cors(ngApp, app);

            //
            // Hook the authentication interceptor service, so that
            // all calls to web services are augment with the autorization
            // token.
            //

            ngApp.config(function ($httpProvider) { $httpProvider.interceptors.push('fw.auth.interceptor'); });

            //
            // Return the angular object to caller.
            //

            return ngApp;
        };

        //
        // Compute the list of modules to add to the application.
        // Return the list of module dependencies.
        //

        var _modules = function (app) {

            //
            // Compute dependency modules.
            //

            var modules = [];

            //
            // Add additional modules, specificed by the developer.
            //

            if (angular.isDefined(app.modules)) {

                //
                // If module is already included in the app,
                // do not add it.
                //

                angular.forEach(app.modules, function (name, idx) {

                    var exists = false;
                    angular.forEach(this, function (val, i) { exists = exists || (val == name); });
                    if (!exists) { this.push(name); }

                }, modules);
            }

            return modules;
        };

        //
        // Process the white and blacklist of the application specification.
        // @param ngApp The angular module object.
        // @param app the application spec.
        //

        var _cors = function (ngApp, app) {

            var whitelist = ['self'];
            var blacklist = [];

            if (angular.isDefined(app.cors)) {

                //
                // Process white list.
                //

                if (angular.isDefined(app.cors.whitelist)) {

                    angular.forEach(app.cors.whitelist, function (url, idx) {

                        var exists = false;

                        angular.forEach(this, function (val, i) { exists = exists || (val == url); });

                        if (!exists) { this.push(url); }

                    }, whitelist);
                }

                //
                // Process black list.
                //

                blacklist = angular.isDefined(app.cors.blacklist) ? app.cors.blacklist : [];
            }

            //
            // Register with application the white & black list.
            //

            ngApp.config(function ($sceDelegateProvider) {

                if (angular.isDefined(whitelist)) { $sceDelegateProvider.resourceUrlWhitelist(whitelist); }
                if (angular.isDefined(blacklist)) { $sceDelegateProvider.resourceUrlBlacklist(blacklist); }
            });
        };

        //
        // API
        //

        return {
            'create': _create
        };
    }]);
