// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 17/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Model.Schema;
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

        public ServiceEntry ProviderServiceEntry { get; set; }

        public Type ProviderServiceType { get { return null != ProviderService ? ProviderService.GetType() : null; } }

        [JsonIgnore]
        public IProviderDataContext ProviderService { get; set; }

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
            ProviderServiceEntry = default(ServiceEntry);
            ProviderService = default(IProviderDataContext);
            Original = default(FW_DataContext);
        }
    }  
}
