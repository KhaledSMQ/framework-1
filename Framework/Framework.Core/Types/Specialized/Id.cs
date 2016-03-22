// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Framework.Core.Types.Specialized
{
    public class Id
    {
        //
        // Check if identifier is simple.
        // An identifier is simple if it has
        // only one parcel.
        //

        public bool Simple
        {
            get { return 1 == NumberOfParcels; }
        }

        //
        // Get the number of elements that are included in this ID.
        // If Parcels is empty or null, then this property returns 0,
        // otherwise it returns the number of parcels.
        //

        public int NumberOfParcels
        {
            get { return _Parcels.Count; }
        }

        //
        // CONSTRUCTORS
        //

        public Id(string value)
            : this()
        {
            Add(value.SplitNoEmpty(_Separator));
        }

        public Id(params string[] segs)
            : this()
        {
            Add(segs);
        }

        public Id(IEnumerable<string> segs)
            : this()
        {
            Add(segs);
        }

        public Id()
        {
            _Parcels = new List<string>();
        }

        //
        // ADD/APPEND-METHODS
        //

        public Id Add(Id id)
        {
            return Add(id._Parcels);
        }

        public Id Add(IEnumerable<string> segs)
        {
            segs.Apply(str => Add(str));
            return this;
        }

        public Id Add(string parcel)
        {
            if (parcel.isNullOrEmpty())
            {
                return this;
            }

            if (parcel.Contains(_Separator))
            {
                throw new Exception(string.Format("invalid parcel to identifier '{0}'", parcel));
            }

            _Parcels.Add(parcel);

            return this;
        }

        //
        // OPERATORS
        //


        public static Id operator +(Id c1, string c2)
        {
            return new Id().Add(c1).Add(c2);
        }

        public static Id operator +(string c1, Id c2)
        {
            return new Id().Add(c1).Add(c2);
        }

        public static Id operator +(Id c1, Id c2)
        {
            return new Id().Add(c1).Add(c2);
        }

        //
        // STANDARD-OBJECT-OVERLOADS
        //

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return (obj is Id) && (obj as Id).ToString() == ToString();
        }

        public override string ToString()
        {
            return _Parcels.Join(_Separator);
        }

        //
        // PRIVATE-PROPERTIES
        // Array of the ID parcels.
        // The set of segments that make up the whole ID.
        //

        private IList<string> _Parcels { get; set; }
        private string _Separator = ".";
    }
}
