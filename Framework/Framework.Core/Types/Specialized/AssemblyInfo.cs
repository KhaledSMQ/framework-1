﻿// ============================================================================
// Project: Framework
// Name/Class: AssemblyInfo
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Assembly info modelling class.
// ============================================================================

using System;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Core.Types.Specialized
{
    public class AssemblyInfo
    {
        //
        // PROPERTIES
        //

        public string Name { get; set; }
        public string Version { get; set; }
        public string Culture { get; set; }
        public string PublicKeyToken { get; set; }

        //
        // METHODS
        //

        public virtual void Parse(string input)
        {
            Name = string.Empty;
            Version = string.Empty;
            Culture = string.Empty;
            PublicKeyToken = string.Empty;

            IDictionary<string, string> comps = ParseComponents(input);

            foreach (string property in comps.Keys)
            {
                string value = comps[property];
                switch (property)
                {
                    case "name":
                        Name = value;
                        break;
                    case "version":
                        Version = value;
                        break;
                    case "culture":
                        Culture = value;
                        break;
                    case "publickeytoken":
                        PublicKeyToken = value;
                        break;
                }
            }
        }

        public virtual string UnparseForType(string typename)
        {
            return this.Unparse() + (typename.isNotNullAndEmpty() ? ", " + typename : string.Empty);
        }

        public virtual string Unparse()
        {
            string fullname = string.Empty;
            fullname += Name.isNotNullAndEmpty() ? Name : string.Empty;
            fullname += Version.isNotNullAndEmpty() ? ", Version=" + Version : string.Empty;
            fullname += Culture.isNotNullAndEmpty() ? ", Culture=" + Culture : string.Empty;
            fullname += PublicKeyToken.isNotNullAndEmpty() ? ", PublicKeyToken=" + PublicKeyToken : string.Empty;
            return fullname;
        }

        //
        // HELPER METHODS
        //

        protected virtual IDictionary<string, string> ParseComponents(string input)
        {
            IDictionary<string, string> comps = new SortedDictionary<string, string>();

            string[] segments = input.SplitNoEmpty(',');
            foreach (string seg in segments)
            {
                string property = string.Empty;
                string value = string.Empty;

                string[] pair = seg.SplitNoEmpty("=");
                if (pair.Length == 1)
                {
                    property = "name";
                    value = pair[0];
                }
                else if (pair.Length == 2)
                {
                    property = pair[0].ToLower().Trim();
                    value = pair[1];
                }

                if (property.isNotNullAndEmpty() && value.isNotNullAndEmpty())
                {
                    comps.Add(property, value);
                }
            }

            return comps;
        }
    }
}