// ============================================================================
// Project: Framework
// Name/Class: NameValueExtensions
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Extension class for NameValueCollection.
// ============================================================================

using System.Collections.Specialized;
using Framework.Core.Helpers;

namespace Framework.Core.Extensions
{
    public static class NameValueCollectionExtensions
    {
        //
        // Check if collection is not empty or not null.
        //

        public static bool NotEmpty(this NameValueCollection coll)
        {
            return ((null != coll) && (coll.Count > 0));
        }

        //
        // Gets the string value associated w/ the key, if it's empty returns the default value.
        // @param collection The name value collection.
        // @param key  The key value.
        // @param defaultValue The default value.
        // @return The value for the key or the default.
        //

        public static string GetOrDefault(NameValueCollection coll, string key, string defaultValue)
        {
            if (coll == null)
            {
                return defaultValue;
            }

            string val = coll[key];

            if (string.IsNullOrEmpty(val))
            {
                return defaultValue;
            }

            return val;
        }

        //
        // Gets the generic value associated w/ the key, if it's empty returns the default value.
        // @param collection The name value collection.
        // @param key  The key value.
        // @param defaultValue The default value.
        // @return The value for the key or the default.
        //

        public static T GetOrDefault<T>(NameValueCollection coll, string key, T defaultValue)
        {
            if (coll == null)
            {
                return defaultValue;
            }

            string val = coll[key];

            if (string.IsNullOrEmpty(val))
            {
                return defaultValue;
            }

            return TypeHelper.ConvertTo<T>(val);
        }
    }
}
