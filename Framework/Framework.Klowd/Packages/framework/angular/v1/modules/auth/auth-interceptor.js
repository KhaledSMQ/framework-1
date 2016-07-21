// ============================================================================
// Project:
// Name/Class: 
// Created On: 20/Jul/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company:
// Description:
// ============================================================================

'use strict';
angular.module('fw.auth').factory('fw.auth.interceptor', [
    '$q',
    '$injector',
    '$location',
    'localStorageService',
    'fw.engine.settings',
    function ($q, $injector, $location, localStorageService, settings) {

        //
        // Default configuration for this service.
        //

        var _defaultConfig = {
            STATUS_401: {
                LOGGED_IN_URL: '/',
                NOT_LOGGED_IN_URL: '/'
            }
        };

        var _config = {};

        //
        // Process settings. Merge the defined settings
        // for this component found in the runtime with 
        // default values.
        //

        var _processConfig = function () {

            //
            // Fetch the configuration for this service, merge
            // with default values and set the scope object.
            //

            angular.merge(_config, _defaultConfig, settings.get("fw.auth.interceptor"));
        }

        //
        // Request part for interceptor.
        //

        var _request = function (config) {

            config.headers = config.headers || {};

            //
            // If the credential are in the local 
            // storage add them to the request.
            //

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        }

        //
        // Response part for the interceptor.
        //

        var _responseError = function (rejection) {

            //
            // In case the service fails what to do????
            //

            if (rejection.status === 401) {

                var path = '/';

                var loggedIn = angular.isDefined(localStorageService.get('authorizationData'));

                if (loggedIn) {

                    //
                    // If case we wish to clear the token info, 
                    // run the following code.
                    //
                    // var auth = $injector.get('fw.auth');
                    // auth.logOut();
                    //

                    path = _config.STATUS_401.LOGGED_IN_URL;
                }
                else {

                    path = _config.STATUS_401.NOT_LOGGED_IN_URL;
                }

                $location.path(path);
            }

            return $q.reject(rejection);
        }

        //
        // Service API.
        //

        return {
            request: _request,
            responseError: _responseError,
            processConfig: _processConfig
        };
    }
]);