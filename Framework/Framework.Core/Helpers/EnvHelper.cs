// ============================================================================
// Project: Framework
// Name/Class: EnvHelper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description:
//
// Adapted from: CommonLibrary.NET
//                        Kishore Reddy
//                        http://commonlibrarynet.codeplex.com/
// ============================================================================

using System;

namespace Framework.Core.Helper
{
    public class EnvHelper
    {
        //
        // Get environment variable from current process, user variable, machine variable.
        //

        public static string GetAny(string name)
        {
            string env = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(env))
            {
                env = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User);
                if (string.IsNullOrEmpty(env))
                {
                    env = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine);
                }
            }
            return env;
        }
    }
}
