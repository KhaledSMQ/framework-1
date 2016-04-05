// ============================================================================
// Project: Framework
// Name/Class: Core module. Time service.
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('time', function () {


    //
    // Get the current time from client.
    // returns a friendly string format.
    //

    var _getTimeString = function () {

        var lastUpdate = new Date();
        var hours = lastUpdate.getHours();
        var minutes = lastUpdate.getMinutes();
        var seconds = lastUpdate.getSeconds();
        var result = hours + " : " + minutes + " : " + seconds;

        return result;
    };

    //
    // Generate a time stamp. Use this to prevent 
    // caching on the requested urls.
    //

    var _getTimeStamp = function () {

        return new Date().getTime();
    };

    //
    // API
    //

    return {
        getTimeString: _getTimeString,
        getTimeStamp: _getTimeStamp
    };
});