// ============================================================================
// Project: Framework
// Name/Class: ObjectExtensions
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension methods for object datatype.
// ============================================================================                    

using System;
using Framework.Core.Helpers;
using Framework.Core.Reflection;

namespace Framework.Core.Extensions
{
    public static class ObjectExtensions
    {
        //
        // Check if object is not null.
        //

        public static bool IsNotNull(this object val)
        {
            return !IsNull(val);
        }

        //
        // Check if object is null.
        //

        public static bool IsNull(this object val)
        {
            return null == val;
        }

        //
        // INSTANTIATE
        // Take an object value and a string template and replace in the string
        // the textual value of each property found. Names for properties in string
        // template have to match exactly with the names found in the object class.
        // Returns a string with the instantiated value. NOTE: the values for the
        // properties are their ToString values. Properties are referenced with
        // ${<NAME>} construct.
        //

        public static string Instantiate(this object input, string template)
        {
            //
            // setup an lambda function to perform the substitutions.
            //

            Func<string, string> subfunc = (propName => { return ReflectionUtils.GetPropertyValue(input, propName).ToString(); });

            //
            // Substitute the input string template with the property names.
            //

            string output = StringHelper.Substitute(template, subfunc);

            //
            // Return output to caller.
            //

            return output;
        }
    }
}
