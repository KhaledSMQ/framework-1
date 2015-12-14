// ============================================================================
// Project: Framework
// Name/Class: Throw
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Error throwing static class.
// ============================================================================                    

using System;

namespace Framework.Core.Error
{
    public static class Throw
    {
        //
        // Throw an exception with assmebly related information and
        // a variable list of arguments.
        // @param prefix The error prefix for the message.
        // @param msg The error message.
        // @param args The list of arguments.
        //

        public static void WithMessage(string prefix, string msg, params object[] args)
        {
            throw new System.Exception(string.Format(System.Globalization.CultureInfo.InvariantCulture, string.Concat("[", prefix, "]", ":", msg), args));
        }

        //
        // Throw an exception with assmebly related information and
        // a variable list of arguments.
        // @param prefix The error prefix for the message.
        // @param msg The error message.
        // @param args The list of arguments.
        //

        public static void WithMessage(string prefix, Exception exception, string msg, params object[] args)
        {
            string fullMsg = string.Format(System.Globalization.CultureInfo.InvariantCulture, string.Concat("[", prefix, "]", ":", msg), args);
            throw new System.Exception(fullMsg);
        }
    }
}
