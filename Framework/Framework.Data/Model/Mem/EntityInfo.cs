// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Model.Schema;
using Newtonsoft.Json;
using System;

namespace Framework.Data.Model.Mem
{
    public class EntityInfo
    {  
        public string ID { get; set; }

        public Type Type { get; set; }

        public string Domain { get; set; }

        public string Cluster { get; set; }

        public string Context { get; set; }

        //
        // Entity definition used in context.
        //

        [JsonIgnore]
        public DataEntity Original { get; set; }

        public DataEntity Instance { get; set; }

        //
        // CONSTRUCTOR
        //

        public EntityInfo()
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
