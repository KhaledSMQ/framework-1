// ============================================================================
// Project: Framework
// Name/Class: Transform
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Data.Model;
using Framework.Core.Types.Specialized;
using System.Collections.Generic;

namespace Framework.Data.Config
{
    public static class Transforms
    {       
        //
        // CLUSTERS
        //

        public static ICollection<Cluster> ToDataCluster(this ClusterElementCollection collection)
        {
            List<Cluster> dataClusterCollection = new List<Cluster>();
            if (null != collection)
            {
                foreach (ClusterElement clusterElm in collection)
                {
                    dataClusterCollection.Add(ToDataCluster(clusterElm));
                }
            }
            return dataClusterCollection;
        }

        public static Cluster ToDataCluster(this ClusterElement clusterElm)
        {
            Cluster dataCluster = new Cluster();
            dataCluster.Name = clusterElm.Name;
            dataCluster.Description = clusterElm.Description;
            dataCluster.Context = ToDataContext(clusterElm.Context);
            dataCluster.Entities = ToDataEntity(clusterElm.Entities);
            dataCluster.Models = ToDataModel(clusterElm.Models);
            dataCluster.Settings = ToSetting(clusterElm.Settings);
            return dataCluster;
        }

        //
        // CONTEXT
        //

        public static Context ToDataContext(this ContextElement contextElm)
        {
            Context dataContext = null;
            if (null != contextElm)
            {
                dataContext = new Context();
                dataContext.Name = contextElm.Name;
                dataContext.Description = contextElm.Description;
                dataContext.TypeName = contextElm.Type;
                dataContext.Settings = ToSetting(contextElm.Settings);
            }
            return dataContext;
        }

        //
        // ENTITY
        //

        public static ICollection<Entity> ToDataEntity(this EntityElementCollection collection)
        {
            List<Entity> dataEntityCollection = new List<Entity>();
            if (null != collection)
            {
                foreach (EntityElement entityElm in collection)
                {
                    dataEntityCollection.Add(ToDataEntity(entityElm));
                }
            }
            return dataEntityCollection;
        }

        public static Entity ToDataEntity(this EntityElement entityElm)
        {
            Entity dataEntity = new Entity();
            dataEntity.Name = entityElm.Name;
            dataEntity.Description = entityElm.Description;
            dataEntity.TypeName = entityElm.Type;
            dataEntity.Settings = ToSetting(entityElm.Settings);
            return dataEntity;
        }

        //
        // PARTIAL-MODELS
        //

        public static ICollection<PartialModel> ToDataModel(this ModelElementCollection collection)
        {
            List<PartialModel> dataModelCollection = new List<PartialModel>();
            if (null != collection)
            {
                foreach (ModelElement entityElm in collection)
                {
                    dataModelCollection.Add(ToDataModel(entityElm));
                }
            }
            return dataModelCollection;
        }

        public static PartialModel ToDataModel(this ModelElement entityElm)
        {
            PartialModel dataModel = new PartialModel();
            dataModel.Name = entityElm.Name;
            dataModel.Description = entityElm.Description;
            dataModel.TypeName = entityElm.Type;
            dataModel.Settings = ToSetting(entityElm.Settings);
            return dataModel;
        }

        //
        // SETTINGS
        //

        public static ICollection<Setting> ToSetting(this SettingElementCollection collection)
        {
            List<Setting> settingCollection = new List<Setting>();
            if (null != collection)
            {
                foreach (SettingElement settingElm in collection)
                {
                    settingCollection.Add(ToSetting(settingElm));
                }
            }
            return settingCollection;
        }

        public static Setting ToSetting(this SettingElement settingElm)
        {
            Setting setting = new Setting();
            setting.Name = settingElm.Name;
            setting.Value = settingElm.Value;
            return setting;
        }
    }
}
