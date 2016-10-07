// ============================================================================
// Project: Framework
// Name/Class: ErrorBag;ErrorDef
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 7/Oct/2016
// Company: Coop4Creativity
// Description: Runtime error bag and error definition classes.
// ============================================================================                    

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Framework.Core.Extensions;

namespace Framework.Core.Error
{
    //
    // Define the type for exception throwing handlers.
    // @param errorCode The error code as defined in the library.
    // @param args The list of arguments to use when building the error message.
    // @return The exception datatype, ready to be used in a throw statement.
    //

    public delegate Exception ExceptionHandler(Enum errorCode, params object[] args);

    public class ErrorDef : SortedDictionary<int, string> { }

    public class ErrorDefaultBag : SortedDictionary<Enum, string> { }

    public class ErrorBag : SortedDictionary<Enum, ErrorDef>
    {
        //
        // CONSTRUCTOR
        //

        public ErrorBag(Assembly executingAssembly)
        {
            _ExecutingAssembly = executingAssembly;
            _Prefix = Framework.Base.GetDefaultErrorPrefix(executingAssembly);
        }

        public void AddErrorDef(Enum errorCode, string errorMsg)
        {
            AddErrorDef(_InvariantLCID, errorCode, errorMsg);
        }

        public void AddErrorDef(int lcid, Enum errorCode, string errorMsg)
        {
            if (!ContainsKey(errorCode))
            {
                Add(errorCode, new ErrorDef());
            }

            this[errorCode][lcid] = errorMsg;
        }

        //
        // Build an exception for a specific error code and a list
        // of error values.
        //

        public Exception Exception(Enum errorCode, params object[] args)
        {
            return Exception(_InvariantLCID, errorCode, args);
        }

        public Exception Exception(int lcid, Enum errorCode, params object[] args)
        {            
            string errorMsg = this[errorCode][lcid];
            return Throw.ExceptionWithPrefix(_Prefix, args);
        }

        //
        // Private state for error bag.
        //

        private readonly int _InvariantLCID = CultureInfo.InvariantCulture.LCID;
        private readonly string _Prefix;
        private readonly Assembly _ExecutingAssembly;

        //
        //
        //

        public static ExceptionHandler GetExceptionHandler(Assembly executingAssembly, object[] bag)
        {
            Enum errorCode = default(Enum);
            string errorMsg = default(string);
            ErrorBag output = new ErrorBag(executingAssembly);
            bag.Apply((val, index) => {
                if (index.IsOdd())
                {
                    errorMsg = (string)val;
                    output.AddErrorDef(errorCode, errorMsg);
                }
                else
                {
                    errorCode = (Enum)val;
                }
            });
            return output.Exception;
        }
    }
}
