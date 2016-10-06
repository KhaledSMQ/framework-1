// ============================================================================
// Project: Framework
// Name/Class: Activator
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Load types with reflection.
// ============================================================================

using Framework.Core.Extensions;
using System;
using System.Reflection;

namespace Framework.Core.Reflection
{
    public static class Activator
    {
        //
        // Create a new instance of an object, specifying which assembly and typename
        // the supplied string can be composed of the assembly name and the full typename
        // separated by a ','. If no assembly name is supplied the the method assumes we should
        // load it from the current assembly.
        // @param fulname The type full name, may include the assembly.
        // @return The object instance.
        //

        public static T CreateInstance<T>(string fullname)
        {
            string assembly = null;
            string typename = null;
            string[] segments = fullname.SplitNoEmpty(',');

            if (segments.Length == 1)
            {
                typename = segments[0];
            }
            else
                if (segments.Length > 1)
            {
                // 
                // extract assembly name.
                //

                assembly = fullname.Substring(0, fullname.LastIndexOf(','));

                // 
                // type is last.
                //

                typename = segments[segments.Length - 1];
            }

            return CreateInstance<T>(assembly, typename);
        }

        //
        // Create a new instance of an object.
        // @param assembly The name for the assembly where the type is located.
        // @param typename The fullname for the type.
        // @return The object instance.
        //

        public static T CreateInstance<T>(string assembly, string typename)
        {
            if (!string.IsNullOrEmpty(assembly))
            {
                Assembly assemblyObj = Assembly.Load(assembly);
                string fullName = assemblyObj.FullName;
            }

            return (T)System.Activator.CreateInstance(assembly, typename).Unwrap();
        }

        //
        // Create a new instance of an object. Method tries to match
        // the best constrcutor given a list of arguments. If no 
        // arguments are defined then use the default constructor.
        // @param type The type definition.
        // @param args The list of arguments to send to the constructor.
        // @return The object instance.
        //

        public static T CreateInstance<T>(Type type, params object[] args)
        {
            return (T)((null != args && args.Length > 0) ? System.Activator.CreateInstance(type, args) : System.Activator.CreateInstance(type));
        }

        //
        // Create a new instance for a generic type definition.
        // @param fullTypeName The complete string definition for the type.
        // @return An object instance for the type.
        //

        public static T CreateGenericInstance<T>(string fullTypeName)
        {
            //
            // Parse the type definition fron the string.
            //

            Type fullType = Parsing.ParseTypeName(fullTypeName);

            //
            // Finally, take the full generic type and create an 
            // object instance.
            //

            return (T)System.Activator.CreateInstance(fullType);
        }
    }
}
