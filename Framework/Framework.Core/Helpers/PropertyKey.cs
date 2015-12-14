// ============================================================================
// Project: Framework
// Name/Class: PropertyKey
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Simple class to store and parse the propertyKeys.
//
//                propertyKey = configObjectInstanceName.Key.
//                e.g.
//                  1. "profileOptions.IsEnabled"
//                  2. "profileOptions.user1.PageSize"
//
// ============================================================================

namespace Framework.Core.Helpers
{
    public class PropertyKey
    {
        //
        // Static constructor to create the null object.
        //

        static PropertyKey()
        {
            _Empty = new PropertyKey(string.Empty, string.Empty, string.Empty);
        }

        //
        // Gets the null object.
        //

        public static PropertyKey Empty
        {
            get { return _Empty; }
        }

        //
        // The first property e.g. A as in "A.B.C"
        //

        public readonly string Group;

        //
        // The second property e.g. B as in "A.B.C"
        //

        public readonly string SubGroup;

        //
        // The last property. e.g Either B if 2 properties as in "A.B" or C if 3 properties as in "A.B.C"
        //

        public readonly string Key;

        //
        // Constructor.
        //

        public PropertyKey(string group, string subGroup, string key)
        {
            Group = group;
            SubGroup = subGroup;
            Key = key;
        }

        //
        // Whether or not this has a subgroup.
        //

        public bool HasSubGroup
        {
            get { return !string.IsNullOrEmpty(this.SubGroup); }
        }

        //
        // Builds the path by only including the Group and SubGroup if applicable,
        // without using the Key.
        //

        public string BuildWithoutKey()
        {
            string fullkey = Group;

            if (!string.IsNullOrEmpty(SubGroup))
            {
                fullkey += "." + SubGroup;
            }

            return fullkey;
        }

        //
        // Return the key in "Group.SubGroup.Key".
        //

        public override string ToString()
        {
            return PropertyKey.BuildKey(Group, SubGroup, Key);
        }

        //
        // Builds the property key which is the combination of the group and the key.
        //

        public static string BuildKey(string group, string subGroup, string key)
        {
            string fullkey = group;

            if (!string.IsNullOrEmpty(subGroup))
            {
                fullkey += "." + subGroup;
            }

            if (!string.IsNullOrEmpty(key))
            {
                fullkey += "." + key;
            }

            return fullkey;
        }

        //
        // Builds the object key which is the combination of the group and the key.
        //

        public static string BuildKey(string group, string key)
        {
            if (!string.IsNullOrEmpty(group))
            {
                group = group.Trim();
            }

            key = key.Trim();

            return group + "." + key;
        }

        //
        // Parses the propertyKey string "name.Property" and returns a
        // PropertyKey object with the name and property separate.
        //

        public static PropertyKey Parse(string propertyKey)
        {
            if (string.IsNullOrEmpty(propertyKey))
            {
                return PropertyKey.Empty;
            }

            string[] tokens = propertyKey.Split('.');

            // 
            // If only 2 tokens. Convert to "group.key"
            //

            if (tokens.Length == 2)
            {
                return new PropertyKey(tokens[0], string.Empty, tokens[1]);
            }

            if (tokens.Length == 1)
            {
                return new PropertyKey(tokens[0], string.Empty, string.Empty);
            }

            // 
            // Convert to "group.subGroup.key"
            //

            return new PropertyKey(tokens[0], tokens[1], tokens[2]);
        }

        //
        // PRIVATE FIELDS
        //

        private static readonly PropertyKey _Empty;
    }
}
