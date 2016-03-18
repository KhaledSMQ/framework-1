// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 17/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Framework.Data.Model.Mem
{
    public class ContextInfo
    {
        public string ID { get; set; }

        public IList<string> Entities { get; set; }

        public IList<string> Models { get; set; }

        public DataProvider Provider { get; set; }

        public ServiceEntry ProviderServiceEntry { get; set; }

        public Type ProviderServiceType { get { return null != ProviderService ? ProviderService.GetType() : null; } }

        [JsonIgnore]
        public IProviderDataContext ProviderService { get; set; }

        //
        // Original context specification.
        //

        [JsonIgnore]
        public DataContext Original { get; set; }   

        //
        // CONSTRUCTOR
        //

        public ContextInfo()
        {
            ID = null;
            Entities = null;
            Models = null;
            Provider = default(DataProvider);
            ProviderServiceEntry = default(ServiceEntry);
            ProviderService = default(IProviderDataContext);

            Original = default(DataContext);
        }
    }  
}
