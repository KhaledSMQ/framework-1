// ============================================================================
// Project: Framework
// Name/Class: Guard
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Simple validations for code.
//
// Adapted from: CommonLibrary.NET
//                        Kishore Reddy
//                        http://commonlibrarynet.codeplex.com/
// ============================================================================

using Framework.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Framework.Core.Helpers
{
    public sealed class Guard
    {
        //
        // Check that the condition is true.
        //

        public static void IsTrue(bool condition)
        {
            if (!condition)
            {
                throw new ArgumentException("The condition supplied is false");
            }
        }

        //
        // Check that the condition is true and return error message provided.
        //

        public static void IsTrue(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message);
            }
        }

        //
        // Check that the condition is false.
        //

        public static void IsFalse(bool condition)
        {
            if (condition)
            {
                throw new ArgumentException("The condition supplied is true");
            }
        }

        //
        // Check that the condition is false and return error message provided.
        //

        public static void IsFalse(bool condition, string message)
        {
            if (condition)
            {
                throw new ArgumentException(message);
            }
        }

        //
        // Check that the object provided is not null.
        //

        public static void IsNotNull(object obj)
        {
            if (null == obj)
            {
                throw new ArgumentNullException("The argument provided cannot be null.");
            }
        }

        //
        // Check that the object supplied is not null and throw exception
        // with message provided.
        //

        public static void IsNotNull(object obj, string message)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(message);
            }
        }

        //
        // Check that the string provided is not null or empty.
        //

        public static void IsNotNullAndEmpty(string obj)
        {
            if (obj.isNullOrEmpty())
            {
                throw new ArgumentNullException("The argument provided cannot be null or empty.");
            }
        }

        //
        // Check that the string provided is not null or empty.
        //

        public static void IsNotNullAndEmpty(string obj, string msg)
        {
            if (obj.isNullOrEmpty())
            {
                throw new ArgumentNullException(msg);
            }
        }

        //
        // Check that the object provided is null.
        //

        public static void IsNull(Object obj)
        {
            if (null != obj)
            {
                throw new ArgumentNullException("The argument provided must be null.");
            }
        }

        //
        // Check that the object supplied is null and throw exception
        // with message provided.
        //

        public static void IsNull(Object obj, string message)
        {
            if (null != obj)
            {
                throw new ArgumentNullException(message);
            }
        }

        //
        // Check that the supplied object is one of a list of objects.
        //

        public static bool IsOneOfSupplied<T>(T obj, List<T> possibles)
        {
            return IsOneOfSupplied<T>(obj, possibles, "The object does not have one of the supplied values.");
        }

        //
        // Check that the supplied object is one of a list of objects.
        //

        public static bool IsOneOfSupplied<T>(T obj, List<T> possibles, string message)
        {
            foreach (T possible in possibles)
            {
                if (possible.Equals(obj))
                {
                    return true;
                }
            }

            throw new ArgumentException(message);
        }

        //
        // Verify that a string is not null or empty.
        //

        public static void ArgumentNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (value.Length == 0)
            {
                throw new ArgumentException("'{0}' cannot be empty.".FormatWith(CultureInfo.InvariantCulture, parameterName), parameterName);
            }
        }

        //
        // Verify that a value is an enum.
        //

        public static void ArgumentTypeIsEnum(Type enumType, string parameterName)
        {
            ArgumentNotNull(enumType, "enumType");

            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type {0} is not an Enum.".FormatWith(CultureInfo.InvariantCulture, enumType), parameterName);
            }
        }

        //
        // Verify that an argument is not null.
        // Supply the argument name.
        //

        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        //
        // Verify that an argument is not null.
        // Supply the argument name and custum message.
        //

        public static void ArgumentConditionTrue(bool condition, string parameterName, string message)
        {
            if (!condition)
                throw new ArgumentException(message, parameterName);
        }

        //
        // Verify that a collection argument is not null or empty (i.e. zero elements).
        //

        public static void ArgumentNotNullOrEmpty<T>(ICollection<T> collection, string parameterName)
        {
            ArgumentNotNullOrEmpty<T>(collection, parameterName, "Collection '{0}' cannot be empty.".FormatWith(CultureInfo.InvariantCulture, parameterName));
        }

        //
        // Verify that a collection argument is not null or empty (i.e. zero elements).
        // Supply a custom message.
        //

        public static void ArgumentNotNullOrEmpty<T>(ICollection<T> collection, string parameterName, string message)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (collection.Count == 0)
            {
                throw new ArgumentException(message, parameterName);
            }
        }
    }
}
