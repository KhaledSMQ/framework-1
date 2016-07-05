// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Relational;
using Newtonsoft.Json;
using System;

namespace Framework.Data.Model.Mem
{
    //
    // Class to map information about data models.
    // Used to map unique model identifiers to their
    // runtime information.
    //

    public class MemModel
    {
        public string ID { get; set; }

        public Type Type { get; set; }

        public string Domain { get; set; }

        public string Cluster { get; set; }

        public string Context { get; set; }

        //
        // Original model specification.
        //

        [JsonIgnore]
        public FW_DataPartialModel Original { get; set; }

        public FW_DataPartialModel Instance { get; set; }

        //
        // CONSTRUCTOR
        //

        public MemModel()
        {
            ID = default(string);
            Type = default(Type);
            Domain = default(string);
            Cluster = default(string);
            Context = default(string);

            Original = null;
            Instance = null;
        }
    }
}
