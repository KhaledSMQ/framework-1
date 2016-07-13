// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Relational;
using Framework.Data.API;
using Framework.Factory.Model.Relational;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Mem
{
    public class MemContext
    {
        public string ID { get; set; }

        public IList<string> Entities { get; set; }

        public IList<string> Models { get; set; }

        public FW_DataProvider Provider { get; set; }

        public FW_FactoryServiceEntry ProviderServiceEntry { get; set; }

        public Type ProviderServiceType { get { return null != ProviderService ? ProviderService.GetType() : null; } }

        [JsonIgnore]
        public IDataContext ProviderService { get; set; }

        //
        // Original context specification.
        //

        [JsonIgnore]
        public FW_DataContext Original { get; set; }   

        //
        // CONSTRUCTOR
        //

        public MemContext()
        {
            ID = null;
            Entities = null;
            Models = null;
            Provider = default(FW_DataProvider);
            ProviderServiceEntry = default(FW_FactoryServiceEntry);
            ProviderService = default(IDataContext);
            Original = default(FW_DataContext);
        }
    }  
}
