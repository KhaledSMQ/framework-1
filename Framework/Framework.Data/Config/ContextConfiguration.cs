// ============================================================================
// Project: Framework
// Name/Class: Configuration for contexts.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Config
{
    public class ContextElement : BaseElementWithSettings
    {
        //
        // SERVICE
        //

        [ConfigurationProperty(Constants.SERVICE, DefaultValue = "", IsRequired = true)]
        public string Service
        {
            get { return (string)this[Constants.SERVICE]; }
            set { this[Constants.SERVICE] = value; }
        }
    }
}
