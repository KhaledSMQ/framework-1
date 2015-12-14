﻿// ============================================================================
// Project: Framework
// Name/Class: ErrorInfo
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
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