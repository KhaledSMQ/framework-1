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
        // DATA-CLUSTER
        //

        public static ICollection<DataCluster> ToDataCluster(this ClusterElementCollection collection)
        {
            List<DataCluster> dataClusterCollection = new List<DataCluster>();
            if (null != collection)
            {
                foreach (ClusterElement clusterElm in collection)
                {
                    dataClusterCollection.Add(ToDataCluster(clusterElm));
                }
            }
            return dataClusterCollection;
        }

        public static DataCluster ToDataCluster(this ClusterElement clusterElm)
        {
            DataCluster dataCluster = new DataCluster();
            dataCluster.Name = clusterElm.Name;
            dataCluster.Description = clusterElm.Description;
            dataCluster.Context = ToDataContext(clusterElm.Context);
            dataCluster.Entities = ToDataEntity(clusterElm.Entities);
            dataCluster.Models = ToDataModel(clusterElm.Models);
            dataCluster.Settings = ToSetting(clusterElm.Settings);
            return dataCluster;
        }

        //
        // DATA-CONTEXT
        //

        public static DataContext ToDataContext(this ContextElement contextElm)
        {
            DataContext dataContext = null;
            if (null != contextElm)
            {
                dataContext = new DataContext();
                dataContext.Name = contextElm.Name;
                dataContext.Description = contextElm.Description;
                dataContext.TypeName = contextElm.Type;
                dataContext.Settings = ToSetting(contextElm.Settings);
            }
            return dataContext;
        }

        //
        // DATA-ENTITY
        //

        public static ICollection<DataEntity> ToDataEntity(this EntityElementCollection collection)
        {
            List<DataEntity> dataEntityCollection = new List<DataEntity>();
            if (null != collection)
            {
                foreach (EntityElement entityElm in collection)
                {
                    dataEntityCollection.Add(ToDataEntity(entityElm));
                }
            }
            return dataEntityCollection;
        }

        public static DataEntity ToDataEntity(this EntityElement entityElm)
        {
            DataEntity dataEntity = new DataEntity();
            dataEntity.Name = entityElm.Name;
            dataEntity.Description = entityElm.Description;
            dataEntity.TypeName = entityElm.Type;
            dataEntity.Settings = ToSetting(entityElm.Settings);
            return dataEntity;
        }

        //
        // DATA-MODELS
        //

        public static ICollection<DataModel> ToDataModel(this ModelElementCollection collection)
        {
            List<DataModel> dataModelCollection = new List<DataModel>();
            if (null != collection)
            {
                foreach (ModelElement entityElm in collection)
                {
                    dataModelCollection.Add(ToDataModel(entityElm));
                }
            }
            return dataModelCollection;
        }

        public static DataModel ToDataModel(this ModelElement entityElm)
        {
            DataModel dataModel = new DataModel();
            dataModel.Name = entityElm.Name;
            dataModel.Description = entityElm.Description;
            dataModel.TypeName = entityElm.Type;
            dataModel.Settings = ToSetting(entityElm.Settings);
            return dataModel;
        }

        //
        // SETTING
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
