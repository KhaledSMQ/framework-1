// ============================================================================
// Project: Framework
// Name/Class: Properties
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper methods for reflection on object properties.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Framework.Core.Helpers;
using Framework.Core.Extensions;

namespace Framework.Core.Reflection
{
    public static class Properties
    {
        //
        // Return a list of the object properties that are instance and public.
        //

        public static PropertyInfo[] GetPublicAndInstance<T>(this T obj)
        {
            return typeof(T).GetPublicAndInstanceForType();
        }

        //
        // Return a list of the object properties that are instance and public.
        //

        public static PropertyInfo[] GetPublicAndDeclared<T>(this T obj)
        {
            return typeof(T).GetPublicAndDeclaredForType();
        }

        //
        // Return a list of the object properties that are instance and public.
        //

        public static string[] GetPublicAndInstanceNames<T>(this T obj)
        {
            return typeof(T).GetPublicAndInstanceNamesForType<T>();
        }

        public static string[] GetPublicAndDeclaredNames<T>(this T obj)
        {
            return typeof(T).GetPublicAndDeclaredNamesForType<T>();
        }

        //
        // Return a list of the object properties that are instance and public.
        //

        public static PropertyInfo[] GetPublicAndInstanceForType(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public static PropertyInfo[] GetPublicAndDeclaredForType(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        //
        // Return a list of the object properties that are instance and public.
        //

        public static string[] GetPublicAndInstanceNamesForType<T>(this Type type)
        {
            return type.GetPublicAndInstanceForType().Select(prop => prop.Name).ToArray();
        }

        public static string[] GetPublicAndDeclaredNamesForType<T>(this Type type)
        {
            return type.GetPublicAndDeclaredForType().Select(prop => prop.Name).ToArray();
        }

        //
        // Gets the property value safely, without throwing an exception.
        // If an exception is caught, null is returned.
        //

        public static object GetPropertyValueSafely(this object obj, PropertyInfo propInfo)
        {
            //
            // Check input arguments.
            //

            Guard.IsNotNull(obj, "Must provide object to get it's property.");

            if (null == propInfo)
            {
                return null;
            }

            //
            // Default return value is null.
            //

            object result = null;

            //
            // Guard value retrievel.
            //

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

        public static object GetPropertyValueSafely(this object obj, string name)
        {
            return obj.GetPropertyValueSafely(obj.GetType().GetProperty(name));
        }

        //
        // Set object properties on T using the properties collection supplied.
        // The properties collection is the collection of "property" to value.
        //

        public static void SetProperties<T>(T obj, IList<KeyValuePair<string, string>> properties) where T : class
        {
            //
            // Validate input.
            //

            if (obj == null) { return; }

            foreach (KeyValuePair<string, string> propVal in properties)
            {
                SetProperty<T>(obj, propVal.Key, propVal.Value);
            }
        }

        //
        // Set the object properties using the prop name and value.
        //

        public static void SetProperty<T>(object obj, string propName, object propVal) where T : class
        {
            //
            // Check & Verify.
            //

            Guard.IsNotNull(obj, "Object containing properties to set is null");
            Guard.IsTrue(!string.IsNullOrEmpty(propName), "Property name not supplied.");

            // 
            // Remove spaces.
            //

            propName = propName.Trim();
            if (string.IsNullOrEmpty(propName))
            {
                throw new ArgumentException("Property name is empty.");
            }

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propName);

            // 
            // Correct property with write access.
            //

            if (propertyInfo.IsNotNull() && propertyInfo.CanWrite && TypeChecker.CanConvertToCorrectType(propertyInfo, propVal))
            {
                object convertedVal = TypeChecker.ConvertToSameType(propertyInfo, propVal);
                propertyInfo.SetValue(obj, convertedVal, null);
            }
        }

        //
        // Set the object properties using the prop name and value.
        //

        public static void SetProperty(object obj, string propName, object propVal)
        {
            // 
            // Remove spaces.
            //

            propName = propName.Trim();
            if (string.IsNullOrEmpty(propName)) { throw new ArgumentException("Property name is empty."); }

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propName);

            // 
            // Correct property with write access 
            //

            if (propertyInfo.IsNotNull() && propertyInfo.CanWrite)
            {
                propertyInfo.SetValue(obj, propVal, null);
            }
        }

        //
        // Set the object properties using the property name and value.
        //

        public static void SetProperty(object obj, PropertyInfo prop, object propVal, bool catchException)
        {
            // 
            // Correct property with write access.
            //

            if (prop.IsNotNull() && prop.CanWrite)
            {
                if (!catchException)
                {
                    prop.SetValue(obj, propVal, null);
                }
                else
                {
                    try
                    {
                        prop.SetValue(obj, propVal, null);
                    }
                    catch (Exception) { }
                }
            }
        }

        //
        // Set the property value using the string value.
        //

        public static void SetProperty(object obj, PropertyInfo prop, string propVal)
        {
            //
            // Check & Verify.
            //

            Guard.IsNotNull(obj, "Object containing properties to set is null");
            Guard.IsNotNull(prop, "Property not supplied.");

            // 
            // Correct property with write access.
            //

            if (prop.IsNotNull() && prop.CanWrite && TypeChecker.CanConvertToCorrectType(prop, propVal))
            {
                object convertedVal = TypeChecker.ConvertToSameType(prop, propVal);
                prop.SetValue(obj, convertedVal, null);

            }
        }

        //
        // Replace the object string properties of an item
        // This method will traverse all the public string properties of an instance
        // and set the value the the passed string value
        //

        public static void ReplaceEmptyStrings<T>(T item, string replacement)
        {
            PropertyInfo[] properties = Properties.GetPublicAndInstance<T>(item);

            foreach (PropertyInfo p in properties)
            {
                // 
                // Only work with strings.
                //

                if (p.PropertyType != typeof(string)) { continue; }

                // 
                // If not writable then cannot null it; if not readable 
                // then cannot check it's value.
                //

                if (!p.CanWrite || !p.CanRead) { continue; }

                MethodInfo mget = p.GetGetMethod(false);
                MethodInfo mset = p.GetSetMethod(false);

                // 
                // Get and set methods have to be public.
                //

                if (mget == null) { continue; }
                if (mset == null) { continue; }

                if (string.IsNullOrEmpty((string)p.GetValue(item, null)))
                {
                    p.SetValue(item, replacement, null);
                }
            }
        }

        //
        // Replace all string properties that are either null or empty
        // by the supplied value. To this for all objects in the list.
        //

        public static void ReplaceEmptyStrings<T>(List<T> list, string replacement)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in properties)
            {
                // 
                // Only work with strings.
                //

                if (p.PropertyType != typeof(string)) { continue; }

                // 
                // If not writable then cannot null it; if not readable then cannot check it's value.
                //

                if (!p.CanWrite || !p.CanRead) { continue; }

                MethodInfo mget = p.GetGetMethod(false);
                MethodInfo mset = p.GetSetMethod(false);

                // 
                // Get and set methods have to be public.
                //

                if (mget == null) { continue; }
                if (mset == null) { continue; }

                foreach (T item in list)
                {
                    if (string.IsNullOrEmpty((string)p.GetValue(item, null)))
                    {
                        p.SetValue(item, replacement, null);
                    }
                }
            }
        }
    }
}
