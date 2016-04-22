// ============================================================================
// Project: Framework
// Name/Class: 
// Created On: 28/Mar/2016
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Company: Cybermap Lda.
// ============================================================================

'use strict';
fw.module('core').service('sequence', 'core.util', function ($util) {

    //
    // Library name.
    //

    var __LIB = 'core.sequence';

    //
    // Run a sequence os async functions.
    // @param input The input object 
    // @param sequence The sequence of functions to run.
    // @param options The options for the sequence runner.
    //

    var _run = function (input, sequence, options) {
        _worker(input, _prepare(sequence), 0, options);
    };

    //
    // Prepare a sequence to be loaded.
    // @param sequence The sequence to process
    // @return The prepared sequence.
    //

    var _prepare = function (sequence) {

        var processed = [];

        $util.apply(sequence, function (_, step) {

            //
            // Predefined step value.
            //

            var processedStep = step;

            if (typeof step == 'function') {

                processedStep = {
                    fn: step,
                    description: null
                };
            }

            //
            // Push it to new array.
            //

            if ($util.isDefined(processedStep.fn)) {

                processed.push(processedStep);
            }
        });

        return processed;
    };

    //
    // Run a sequence os async functions.
    // @param input The input object 
    // @param sequence The sequence of functions to run.
    // @param index The current index in the array
    // @param options The options for the sequence runner.
    //

    var _worker = function (input, sequence, index, options) {

        //
        // Check if the sequence is hover.
        //

        if (index >= sequence.length) {

            //
            // Call the handler that finishes the loading.
            //

            if ($util.isDefined(options) && $util.isDefined(options.finish)) {
                options.finish(input);
            }

            return;
        }

        var step = sequence[index];
        var fn = step.fn;

        //
        // Call the handler before step execution.
        //

        step.index = index + 1;
        if ($util.isDefined(options) && $util.isDefined(options.beforeStep)) { options.beforeStep(step); }

        //
        // Call the worker function for this step.
        //

        fn(input,
            function (retValue) {

                //
                // Call the handler after the step execution.
                //

                if ($util.isDefined(options) && $util.isDefined(options.afterStep)) { options.afterStep(step); }

                //
                // Continue to next step.
                //

                var newIndex = index + 1;
                _worker(retValue, sequence, newIndex, options);
            }
        );
    };

    //
    // API
    //

    return {
        run: _run
    };
});