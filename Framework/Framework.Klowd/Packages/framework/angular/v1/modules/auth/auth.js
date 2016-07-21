// ============================================================================
// Project:
// Name/Class: 
// Created On: 20/Jul/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company:
// Description:
// ============================================================================

'use strict';

angular.module('fw.auth').factory('fw.auth.login', [
    '$http',
    '$q',
    'localStorageService',
    'fw.engine.settings',
    function ($http, $q, localStorageService, settings) {

        //
        // DTO with authentication information.
        // 

        var _authentication = {

            isAuth: false,
            userName: "",
            info: null
        };

        //
        // Service configuration/settings.
        //

        var _defaultConfig = {

            settings: {
                loginUrl: ''
            },

            errMsg: {
                MSG_INVALID_LOGIN_CREDENTIALS: 'Please fill username and password fields!',
                MSG_NO_LOGIN_URL_IS_DEFINED: 'INTERNAL: No login url is defined!'
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

            angular.merge(_config, _defaultConfig, settings.get("fw.auth"));
        }

        //
        // Method to verify the login data and this service
        // configuration settings.
        // @param loginData the user's login information.
        //        { userName :: string, password :: string }
        //

        var _verify = function (loginData) {

            //
            // Default output, no error condition.
            //

            var output = { error: false, msg: '' };

            if (!toolkit.util.AreDefined(loginData, loginData.userName, loginData.password)) {

                //
                // ERROR: Invalid login data.
                //

                output.error = true;
                output.msg = _config.errMsg.MSG_INVALID_LOGIN_CREDENTIALS;
            }
            else if (!angular.isDefined(_config.settings.loginUrl)) {

                //
                // ERROR: No login url is defined!
                //

                output.error = true;
                output.msg = _config.errMsg.MSG_NO_LOGIN_URL_IS_DEFINED;
            }

            return output;
        };

        //    
        // Perform login use the configuration url to log the user.
        // Returns a promise to caller. 
        // @param loginData the user's login information.
        //        { userName :: string, password :: string }
        //

        var _login = function (loginData) {

            var deferred = $q.defer();

            if (angular.isDefined(loginData) && angular.isDefined(_config.settings.loginUrl)) {

                //
                // Resolve the login url.
                //

                var loginUrl = toolkit.url.Resolve(_config.settings.loginUrl);

                //
                // Everything check outs, perform the login.
                //

                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

                $http.post(loginUrl, data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                    .success(function (response) {

                        //
                        // Login succeded, fill the authorization data with the name and token.
                        //

                        localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, info: response });

                        _authentication.isAuth = true;
                        _authentication.userName = loginData.userName;
                        _authentication.info = response;

                        deferred.resolve(response);
                    })
                    .error(function (err, status) {

                        _logout();
                        deferred.reject(err);
                    });
            }

            return deferred.promise;
        };

        //
        // Function to logout the current user.
        // Removes authentication data from local
        // storage and sets appropriate flags.
        //

        var _logout = function () {

            localStorageService.remove('authorizationData');
            _authentication.isAuth = false;
            _authentication.userName = '';
            _authentication.info = null;
        };

        //
        // Function to fetch from local storage the authentication
        // data and set this services state accordingly.
        //

        var _fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');

            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                _authentication.info = authData.info;
            }
        }

        //
        // Service protocol. API.
        //

        return {
            login: _login,
            logOut: _logout,
            verify: _verify,
            processConfig: _processConfig,
            fillAuthData: _fillAuthData,
            authentication: _authentication
        };
    }
]);