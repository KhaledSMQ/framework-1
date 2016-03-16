// ============================================================================
// Project: Framework
// Name/Class: Throw
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 14/Mar/2016
// Company: Cybermap Lta.
// Description: Error throwing static class.
// ============================================================================                    

using Framework.Core.Exceptions;
using System;

namespace Framework.Core.Error
{
    public static class Throw
    {
        //
        // UNAUTHORIZED-EXCEPTION
        // Methods for throwing un-authorized exceptions.
        //    

        public static void Unauthorized(string prefix, params object[] args)
        {
            WithPrefix(typeof(UnauthorizedException), prefix, args);
        }

        public static void Unauthorized(params object[] args)
        {
            Error(typeof(UnauthorizedException), args);
        }

        //
        // FATAL-EXCEPTION
        // Methods for throwing fatal exceptions.
        //

        public static void Fatal(string prefix, params object[] args)
        {
            WithPrefix(typeof(FatalException), prefix, args);
        }

        public static void Fatal(params object[] args)
        {
            Error(typeof(FatalException), args);
        }

        //
        // INTERNAL-EXCEPTION
        // Methods for throwing internal exceptions.
        //

        public static void Internal(string prefix, params object[] args)
        {
            WithPrefix(typeof(InternalException), prefix, args);
        }

        public static void Internal(params object[] args)
        {
            Error(typeof(InternalException), args);
        }

        //
        // WITH-PREFIX 
        // Methods that attach prefix values to error messages.
        //    

        public static void WithPrefix(string prefix, params object[] args)
        {
            WithPrefix(typeof(Exception), prefix, args);  
        }

        public static void WithPrefix(Type exType, string prefix, params object[] args)
        {
            //
            // Reshape the message text.
            //

            if (!string.IsNullOrEmpty(prefix) && null != args && args.Length > 0)
            {
                string reshapedMessage = string.Concat("[", prefix, "]", ":", args[0]);
                args[0] = reshapedMessage;
            }

            //
            // Throw message.
            //

            Error(exType, args);
        }

        //
        // GENERIC-EXCEPTION
        // Generic exception throws.
        //

        public static void Error(params object[] args)
        {
            Error(typeof(Exception), args);
        }

        public static void Error(Type exType, params object[] args)
        {
            //
            // Preprocess message
            //

            string msg = default(string);
            object[] msgArgs = null;

            if (null != args && args.Length > 0)
            {
                msgArgs = new string[args.Length];
                msg = (string) args[0];

                args.CopyTo(msgArgs, 1);

                if (null != msgArgs && msgArgs.Length > 0)
                {
                    msg = string.Format(msg, msgArgs);
                }
            }

            //
            // Build exception object.
            //

            Exception ex = string.IsNullOrWhiteSpace(msg) 
                ? Reflection.Activator.CreateInstance<Exception>(exType, msg) 
                : Reflection.Activator.CreateInstance<Exception>(exType);

            //
            // Throw the exception.
            //

            throw ex;
        }
    }
}
