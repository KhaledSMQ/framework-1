// ============================================================================
// Project: Framework
// Name/Class: Core module. Query string service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Company: Coop4Creativity
// ============================================================================

'use strict';
fw.module('core').service('qs', 'core.util', function ($util) {

    //
    // Get Hostname from a URL.
    // @param str the url      
    //

    var _getHostName = function (str) {

        var url = $util.isDefined(str) ? str : window.location.href;
        var re = new RegExp('^(?:f|ht)tp(?:s)?\://([^/]+)', 'im');
        var matchStr = url.match(re);

        return (matchStr != null) ? matchStr[1].toString() : '';
    };

    //
    // Get Hostname and Path from a URL.
    // @param str the url      
    //

    var _getHostNameAndPath = function (str) {

        var url = $util.isDefined(str) ? str : window.location.href;
        var parser = document.createElement('a');
        parser.href = url;

        return [parser.protocol, '//', parser.host, '/', parser.pathname].join('');
    };

    //
    // Get the query string parameters in pairs
    // of name and value (hash).
    //

    var _getUrlVars = function () {

        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    };

    //
    // Extract parameter values from query string.
    // @param name the name of the parameter
    // @return the parameter value or the empty string if it does not exist.  
    //

    var _getQSValue = function (name) {

        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(window.location.href);

        //
        // If no result if found we return the empty string. 
        //

        if (results == null) {
            return "";
        }
        else {
            return decodeURIComponent(results[1].replace(/\+/g, " "));
        }
    };

    //
    // Replace a query string parameter with another value.   
    // @param paraName the name of the query string parameter.
    // @param paramValue the new value for the parameter        
    //

    var _replaceQSValue = function (paramName, paramValue) {

        var UrlStr = window.location.href;
        var AddressStr = UrlStr.substr(0, UrlStr.indexOf("?")) + "?" + paramName + "=" + paramValue;
        var otherParams = this.getAllQSExcept(paramName);

        if (otherParams != "") {
            AddressStr = AddressStr + "&" + otherParams;
        }
        else {
        }

        return AddressStr;
    };

    //
    // Return the query string value stripped of a parameter value.
    // @param paramName the name of the parameter to strip out.
    // @return the query string without the parameter.  
    //

    var _getAllQSExcept = function (paramName) {

        var UrlStr = window.location.href;
        var teste = UrlStr.indexOf("?");

        //
        // do if the query string does have parameters 
        //

        if (teste != -1) {
            var QueryStr = UrlStr.substr(UrlStr.indexOf("?") + 1, UrlStr.length);
            var parameters = QueryStr.split("&");
            var NewQueryString = "";
            var regexS = "^" + paramName;
            var regex = new RegExp(regexS);

            //
            // Exclude the parameter with the name paramName.
            //

            for (i = 0; i < parameters.length; i++) {
                if (paramName != (parameters[i].substr(0, parameters[i].indexOf("=")))) {
                    NewQueryString = NewQueryString + parameters[i] + "&";
                }
            }

            NewQueryString = NewQueryString.substr(0, NewQueryString.length - 1);
        }
        else {

            //
            // If the query string does not have parameters	return an empty string.
            //

            NewQueryString = "";
        }

        return NewQueryString;
    };

    //
    // API
    //

    return {
        getHostName: _getHostName,
        getHostNameAndPath: _getHostNameAndPath,
        getUrlVars: _getUrlVars,
        getQSValue: _getQSValue,
        replaceQSValue: _replaceQSValue,
        getAllQSExcept: _getAllQSExcept
    };
});