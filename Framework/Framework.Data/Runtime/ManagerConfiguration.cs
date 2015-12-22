// ============================================================================
// Project: Framework
// Name/Class: Manager
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Runtime data store implementation.
// ============================================================================

using System;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Xml;

namespace Framework.Data.Runtime
{
    public static class PropertyName {

        public const string PROPERTY_CLUSTERS = "Clusters";
        public const string PROPERTY_NAME = "Name";
        public const string PROPERTY_DESCRIPTION = "Description";
        public const string PROPERTY_TYPE = "Type";
        public const string PROPERTY_VALUE = "Value";
        public const string PROPERTY_SETTINGS = "Settings";

    }

    public class ManagerConfiguration : ConfigurationSection
    {
        //
        // Clusters
        //

        [ConfigurationProperty(PropertyName.PROPERTY_CLUSTERS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ClusterElementCollection))]
        public ClusterElementCollection Settings
        {
            get { return (ClusterElementCollection)this[PropertyName.PROPERTY_CLUSTERS]; }
        }
    }

    public class ClusterElementCollection : ConfigurationElementCollection
    {
        public ClusterElementCollection() { }

        public ClusterElement this[int index]
        {
            get { return (ClusterElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(ClusterElement itemConfig)
        {
            BaseAdd(itemConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ClusterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ClusterElement)element).Name;
        }

        public void Remove(ClusterElement itemConfig)
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

    public class ClusterElement : ConfigurationElement
    {
        //
        // Name
        //

        [ConfigurationProperty(PropertyName.PROPERTY_NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[PropertyName.PROPERTY_NAME]; }
            set { this[PropertyName.PROPERTY_NAME] = value; }
        }

        //
        // Description
        //

        [ConfigurationProperty(PropertyName.PROPERTY_DESCRIPTION, DefaultValue = "", IsRequired = true)]
        public string Description
        {
            get { return (string)this[PropertyName.PROPERTY_DESCRIPTION]; }
            set { this[PropertyName.PROPERTY_DESCRIPTION] = value; }
        }

        //
        // Type Name
        //

        [ConfigurationProperty(PropertyName.PROPERTY_TYPE, DefaultValue = "", IsRequired = true)]
        public string Type
        {
            get { return (string)this[PropertyName.PROPERTY_TYPE]; }
            set { this[PropertyName.PROPERTY_TYPE] = value; }
        }

        //
        // Settings
        //

        [ConfigurationProperty(PropertyName.PROPERTY_SETTINGS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SettingElementCollection))]
        public SettingElementCollection Settings
        {
            get { return (SettingElementCollection)this[PropertyName.PROPERTY_SETTINGS]; }
        }
    }

    public class DataContextElement : ConfigurationElement
    { 
        //
        // Name
        //

        [ConfigurationProperty(PropertyName.PROPERTY_NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[PropertyName.PROPERTY_NAME]; }
            set { this[PropertyName.PROPERTY_NAME] = value; }
        }

        //
        // Description
        //

        [ConfigurationProperty(PropertyName.PROPERTY_DESCRIPTION, DefaultValue = "", IsRequired = true)]
        public string Description
        {
            get { return (string)this[PropertyName.PROPERTY_DESCRIPTION]; }
            set { this[PropertyName.PROPERTY_DESCRIPTION] = value; }
        }

        //
        // Type Name
        //

        [ConfigurationProperty(PropertyName.PROPERTY_TYPE, DefaultValue = "", IsRequired = true)]
        public string Type
        {
            get { return (string)this[PropertyName.PROPERTY_TYPE]; }
            set { this[PropertyName.PROPERTY_TYPE] = value; }
        }

        //
        // Settings
        //

        [ConfigurationProperty(PropertyName.PROPERTY_SETTINGS, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SettingElementCollection))]
        public SettingElementCollection Settings
        {
            get { return (SettingElementCollection)this[PropertyName.PROPERTY_SETTINGS]; }
        }
    }

    public class SettingElementCollection : ConfigurationElementCollection
    {
        public SettingElementCollection() { }

        public SettingElement this[int index]
        {
            get { return (SettingElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        public void Add(SettingElement serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SettingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SettingElement)element).Name;
        }

        public void Remove(SettingElement serviceConfig)
        {
            BaseRemove(serviceConfig.Name);
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

    public class SettingElement : ConfigurationElement
    {  
        //
        // Name
        //

        [ConfigurationProperty(PropertyName.PROPERTY_NAME, DefaultValue = "", IsRequired = true)]
        public string Name
        {
            get { return (string)this[PropertyName.PROPERTY_NAME]; }
            set { this[PropertyName.PROPERTY_NAME] = value; }
        }

        //
        // Description
        //

        [ConfigurationProperty(PropertyName.PROPERTY_DESCRIPTION, DefaultValue = "", IsRequired = true)]
        public string Description
        {
            get { return (string)this[PropertyName.PROPERTY_DESCRIPTION]; }
            set { this[PropertyName.PROPERTY_DESCRIPTION] = value; }
        }

        //
        // Value
        //

        [ConfigurationProperty(PropertyName.PROPERTY_VALUE, DefaultValue = "", IsRequired = true)]
        public string Type
        {
            get { return (string)this[PropertyName.PROPERTY_VALUE]; }
            set { this[PropertyName.PROPERTY_VALUE] = value; }
        }
    }
}
