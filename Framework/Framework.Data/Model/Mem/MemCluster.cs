// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Framework.Data.Model.Mem
{
    public class MemCluster
    {
        public string ID { get; set; }

        public IList<string> Contexts { get; set; }

        public IList<string> Entities { get; set; }

        public IList<string> Models { get; set; }

        //
        // Original cluster specification.
        //

        [JsonIgnore]
        public FW_DataCluster Original { get; set; }

        //
        // CONSTRUCTOR
        //

        public MemCluster()
        {
            ID = null;
            Contexts = null;
            Entities = null;
            Models = null;

            Original = null;
        }
    }
}
