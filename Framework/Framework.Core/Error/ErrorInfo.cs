// ============================================================================
// Project: Framework
// Name/Class: ErrorInfo
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Error information modelling class.
// ============================================================================                    

using System;
using System.Diagnostics;

namespace Framework.Core.Error
{
    public class ErrorInfo
    {
        //
        // PROPERTIES
        //

        public string Message { get; set; }

        public StackTrace Trace { get; set; }

        //
        // CONSTRUCTORS
        //

        public ErrorInfo(Exception e)
        {
            Message = e.Message;
            Trace = new StackTrace(e);
        }
    }
}
