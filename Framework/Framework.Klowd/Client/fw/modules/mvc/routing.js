// ============================================================================
// Project: Framework
// Name/Class: mvc.fragment
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('mvc').service('routing', 'core.util, core.string, core.time, core.resolver, mvc.config', function ($util, $string, $time, $resolver, $config) {

    //
    // Take an application instance and an url and extract
    // page information object. Page information object 
    // contains at least the page name and set of arguments.
    // @param instance The app instance
    // @param url The url to extract
    // @return The page info.
    //

    var _extractRequestFromUrl = function (instance, url) {

        //
        // Get the page configuration object.
        //

        var pageConfig = instance.config.pages;
        var localeConfig = instance.config.localization;

        //
        // Parse the url fragments.
        //

        var pageInfo = _parseUrl(instance, url, function (x) { return false; }, 'PT', pageConfig);

        //
        // Process relative url for the page filename
        //

        pageInfo.relUrl = $resolver.resolve(instance.runtime.resolver, '[__PAGES__]:~/' + pageInfo.fileUrl);

        //
        // The url property is the value used for calling the service.
        //

        pageInfo.absUrl = pageInfo.relUrl + '?__dummy=' + $time.getTimeStamp();

        //
        // Return page info to caller.
        //

        return pageInfo;
    };

    //
    // Parse an url from a string value.
    // @param url The url to parse.
    // @param isLocale function to check if a certain value is a locale value.
    // @param currLocale The current locale.
    // @param pageConfig The configuration object for pages.
    // @return The page object specification.
    //

    var _parseUrl = function (instance, url, isLocale, currLocale, pageConfig) {

        //
        // Default page info is the default page,
        // current url and an empty argument set.
        //

        var locale = currLocale;
        var path = [];
        var name = '';
        var args = {};
        var fileUrl = '';

        //
        // Trim the url, use trimmed url for null/empty page name.
        //

        var trimmedUrl = $util.isDefined(url) ? url.trim() : pageConfig.dft.trim();

        //
        // If url is null or empty then use the default 
        // page name and an empty argument set.
        //

        if ($util.isDefined(trimmedUrl)) {

            //
            // Remove leading #, /, if existant. Remove trailing /
            //

            trimmedUrl = trimmedUrl.replace(/\\/g, '/');
            trimmedUrl = $string.startsWith(trimmedUrl, '#') ? trimmedUrl.substring(1) : trimmedUrl;
            trimmedUrl = $string.startsWith(trimmedUrl, '/') ? trimmedUrl.substring(1) : trimmedUrl;
            trimmedUrl = $string.endsWith(trimmedUrl, '/') ? trimmedUrl.substring(0, trimmedUrl.length - 1) : trimmedUrl;

            //
            // Parse url parcels.
            //

            var parcels = trimmedUrl.split('/');
            var argsStartIndex = 1;
            var pathStartIndex = 0;

            if ($util.isDefined(parcels)) {

                if (parcels.length >= 1) {

                    //
                    // Get the first parcel, check if its a locale key.
                    //

                    var fstParcel = parcels[0];
                    if ($util.isDefined(isLocale) && isLocale(fstParcel)) {

                        locale = fstParcel;
                        pathStartIndex = 1;
                    }

                    //
                    // Parse the path of the page, if it exists...
                    //

                    for (var i = pathStartIndex; i < parcels.length; i++) {

                        path.push(parcels[i]);
                        argsStartIndex++;
                    }

                    //
                    // Parse the page name. This should be the last value
                    // if the page path.
                    //

                    name = path[path.length - 1];

                    //
                    // Process extension, yielding a complete filename for page.
                    //

                    fileUrl = path.join('/');
                    fileUrl = $string.endsWith(fileUrl, pageConfig.extension) ? fileUrl : fileUrl + pageConfig.extension;

                    //
                    // After extracting the page path and name, extract arguments.
                    //

                    var argName = null;

                    for (var i = argsStartIndex, j = 1; i < parcels.length; i++, j++) {

                        if (j & 1) {
                            argName = parcels[i];
                        }
                        else {
                            args[argName] = parcels[i];
                        }
                    }
                }
            }
        }

        return { locale: locale, fileUrl: fileUrl, path: path, name: name, args: args };
    };

    //
    // Unparse into a url a specific page spec object.
    // @param pageInfo the page info object.
    // @return the string with the unparsed url.
    //

    var _unparseUrl = function (instance, pageInfo) {

        var path = pageInfo.path.join('/');

        var args = '';

        $.each(pageInfo.args, function (name, value) { args += '/' + name + '/' + value; });

        return '#' + pageInfo.locale + '/' + path + args;
    };

    //
    // Process arguments for page info object.
    // @param pageCfg the page configuration object.
    // @param pageInfo the page runtime object.
    //

    var _processArgs = function (instance, pageInfo) {
        return pageInfo;
    };

    //
    // API
    //

    return {
        extractRequestFromUrl: _extractRequestFromUrl,
        parseUrl: _parseUrl,
        unparseUrl: _unparseUrl
    };
});