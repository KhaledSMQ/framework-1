// ============================================================================
// Project: Framework
// Name/Class: Configuration for Clusters.
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Configuration objects.
// ============================================================================

using System.Configuration;

namespace Framework.Data.Model.Config
{
    public class ConfigClusterCollection : ConfigurationElementCollection
    {
        public ConfigClusterCollection() { }

        public ConfigCluster this[int index]
        {
            get { return (ConfigCluster)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ConfigCluster itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigCluster();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigCluster)element).Name;
        }

        public void Remove(ConfigCluster itemConfig)
        {
            BaseRemove(itemConfig.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }

    public class ConfigCluster : ConfigBaseWithSettings
    {
        //
        // CONTEXTS
        //

        [ConfigurationProperty(Constants.CONTEXTS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigContextCollection))]
        public ConfigContextCollection Contexts
        {
            get { return (ConfigContextCollection)this[Constants.CONTEXTS]; }
        }      

        //
        // ENTITIES
        //

        [ConfigurationProperty(Constants.ENTITIES, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigEntityCollection))]
        public ConfigEntityCollection Entities
        {
            get { return (ConfigEntityCollection)this[Constants.ENTITIES]; }
        }

        //
        // MODELS
        //

        [ConfigurationProperty(Constants.MODELS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConfigModelCollection))]
        public ConfigModelCollection Models
        {
            get { return (ConfigModelCollection)this[Constants.MODELS]; }
        }
    }
}
