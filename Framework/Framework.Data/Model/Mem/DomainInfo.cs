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
    public class DomainInfo
    {
        public string ID { get; set; }

        public IList<string> Clusters { get; set; }

        //
        // Original context specification.
        //

        [JsonIgnore]
        public DataDomain Original { get; set; }   

        //
        // CONSTRUCTOR
        //

        public DomainInfo()
        {
            ID = null;
            Clusters = null;

            Original = null;
        }
    }
}
