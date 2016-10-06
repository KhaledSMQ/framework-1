// ============================================================================
// Project: Framework
// Name/Class: Fields
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Field related reflection.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using Framework.Core.Extensions;

namespace Framework.Core.Reflection
{
    public static class Fields
    {
        //
        // Return the list of fields of an object that are instance
        // public fields.
        //

        public static FieldInfo[] GetPublicAndInstance<T>(T obj)
        {
            return Get(obj, BindingFlags.Public | BindingFlags.Instance);
        }

        //
        // Return the list of fields that are of a specific characteristic.
        // i.e. Public.
        //

        public static FieldInfo[] Get<T>(T obj, BindingFlags flags)
        {
            return typeof(T).GetFields(flags);
        }

        //
        // Return the list of fields of an object that are instance
        // public fields and are decorated with a particular attribute.
        //

        public static List<FieldInfo> GetWithAttribute<T>(T item, Type attribute)
        {
            return GetWithAttribute(typeof(T), attribute, BindingFlags.Public | BindingFlags.Instance);
        }

        //
        // Return the list of fields of a type that are instance
        // public fields and are decorated with a particular attribute.
        //

        public static List<FieldInfo> GetWithAttribute(Type type, Type attribute)
        {
            return GetWithAttribute(type, attribute, BindingFlags.Public | BindingFlags.Instance);
        }

        //
        // Return the list of fields that are of a specific characteristic.
        // i.e. Public, and are decorated with a specific attribute.
        //

        public static List<FieldInfo> GetWithAttribute<T>(T item, Type attribute, BindingFlags flags)
        {
            return GetWithAttribute(typeof(T), attribute, flags);
        }

        public static List<FieldInfo> GetWithAttribute(Type type, Type attribute, BindingFlags flags)
        {
            var fields = new List<FieldInfo>();

            type.GetFields(flags).Apply(field =>
            {
                if (field.IsDefined(attribute, true))
                {
                    fields.Add(field);
                }
            });

            return fields;
        }
    }
}
