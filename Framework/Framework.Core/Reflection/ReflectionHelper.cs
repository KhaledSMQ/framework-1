// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System;
using System.Reflection;
using Framework.Core.Helpers;

namespace Framework.Core.Reflection
{
    /// <summary>
    /// This class provides basic reflection helper methods.
    /// </summary>
    public class ReflectionHelper
    {
        /// <summary>
        /// Set the property value using the string value.
        /// </summary>
        /// <param name="obj">Object whose property is to be set.</param>
        /// <param name="prop">Property name.</param>
        /// <param name="propVal">Value to set.</param>
        public static void SetProperty(object obj, PropertyInfo prop, string propVal)
        {
            Guard.IsNotNull(obj, "Object containing properties to set is null");
            Guard.IsNotNull(prop, "Property not supplied.");

            // Correct property with write access 
            if (prop != null && prop.CanWrite)
            {
                // Check same Type
                if (Converter.CanConvertToCorrectType(prop, propVal))
                {
                    object convertedVal = Converter.ConvertToSameType(prop, propVal);
                    prop.SetValue(obj, convertedVal, null);
                }
            }
        }


        /// <summary>
        /// Gets the property value safely, without throwing an exception.
        /// If an exception is caught, null is returned.
        /// </summary>
        /// <param name="obj">Object whose property is to be retrieved.</param>
        /// <param name="propInfo">Property name.</param>
        /// <returns></returns>
        public static object GetPropertyValueSafely(object obj, PropertyInfo propInfo)
        {
            Guard.IsNotNull(obj, "Must provide object to get it's property.");
            if (propInfo == null) return null;

            object result = null;
            try
            {
                result = propInfo.GetValue(obj, null);
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
