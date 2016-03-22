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
using System.Collections.Generic;

namespace Framework.Data.Model.Mem
{
    public class MemDomain
    {
        public string ID { get; set; }

        public IList<string> Clusters { get; set; }

        //
        // Original context specification.
        //

        [JsonIgnore]
        public FW_DataDomain Original { get; set; }   

        //
        // CONSTRUCTOR
        //

        public MemDomain()
        {
            ID = null;
            Clusters = null;

            Original = null;
        }
    }
}
