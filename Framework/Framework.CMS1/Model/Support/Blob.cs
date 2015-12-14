// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System;
using Toolkit.Core.Patterns;
using Toolkit.DAL.Sets;

namespace Framework.CMS1.Model.Support
{
    public class Blob :
        IID<int>,
        ICreated<string>,
        IModified<string>,
        IBlob
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public byte[] Content { get; set; }
        public string MimeType { get; set; }

        //
        // CONSTRUCTORS
        //

        public Blob()
        {
            ID = -1;

            CreatedBy = string.Empty;
            CreatedDate = DateTime.Now;
            ModifiedBy = string.Empty;
            ModifiedDate = DateTime.Now;

            Content = null;
            MimeType = string.Empty;
        }
    }
}
