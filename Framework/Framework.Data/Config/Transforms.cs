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

        public static ICollection<DataCluster> ToDataCluster(this ClusterElementCollection coll)
        {
            List<DataCluster> dataClusterCollection = new List<DataCluster>();
            if (null != coll)
            {
                foreach (ClusterElement clusterElm in coll)
                {
                    dataClusterCollection.Add(ToDataCluster(clusterElm));
                }
            }
            return dataClusterCollection;
        }

        public static DataCluster ToDataCluster(this ClusterElement elm)
        {
            DataCluster dataCluster = new DataCluster();
            dataCluster.Name = elm.Name;
            dataCluster.Description = elm.Description;
            dataCluster.Context = ToDataContext(elm.Context);
            dataCluster.Entities = ToDataEntity(elm.Entities);
            dataCluster.Models = ToDataPartialModel(elm.Models);
            dataCluster.Settings = ToSetting(elm.Settings);
            return dataCluster;
        }

        //
        // CONTEXT
        //

        public static DataContext ToDataContext(this ContextElement elm)
        {
            DataContext dataContext = null;
            if (null != elm)
            {
                dataContext = new DataContext();
                dataContext.Name = elm.Name;
                dataContext.Description = elm.Description;
                dataContext.Service = elm.Service;
                dataContext.Settings = ToSetting(elm.Settings);
            }
            return dataContext;
        }

        //
        // ENTITY
        //

        public static ICollection<DataEntity> ToDataEntity(this EntityElementCollection coll)
        {
            List<DataEntity> dataEntityCollection = new List<DataEntity>();
            if (null != coll)
            {
                foreach (EntityElement entityElm in coll)
                {
                    dataEntityCollection.Add(ToDataEntity(entityElm));
                }
            }
            return dataEntityCollection;
        }

        public static DataEntity ToDataEntity(this EntityElement elm)
        {
            DataEntity dataEntity = new DataEntity();
            dataEntity.Name = elm.Name;
            dataEntity.Kind = elm.Kind;
            dataEntity.Description = elm.Description;
            dataEntity.Service = elm.Type;
            dataEntity.Settings = ToSetting(elm.Settings);
            return dataEntity;
        }

        //
        // PARTIAL-MODELS
        //

        public static ICollection<DataPartialModel> ToDataPartialModel(this ModelElementCollection coll)
        {
            List<DataPartialModel> dataModelCollection = new List<DataPartialModel>();
            if (null != coll)
            {
                foreach (ModelElement entityElm in coll)
                {
                    dataModelCollection.Add(ToDataPartialModel(entityElm));
                }
            }
            return dataModelCollection;
        }

        public static DataPartialModel ToDataPartialModel(this ModelElement elm)
        {
            DataPartialModel dataModel = new DataPartialModel();
            dataModel.Name = elm.Name;
            dataModel.Description = elm.Description;
            dataModel.Service = elm.Type;
            dataModel.Settings = ToSetting(elm.Settings);
            return dataModel;
        }

        //
        // SETTINGS
        //

        public static ICollection<Setting> ToSetting(this SettingElementCollection coll)
        {
            List<Setting> settingCollection = new List<Setting>();
            if (null != coll)
            {
                foreach (SettingElement settingElm in coll)
                {
                    settingCollection.Add(ToSetting(settingElm));
                }
            }
            return settingCollection;
        }

        public static Setting ToSetting(this SettingElement elm)
        {
            Setting setting = new Setting();
            setting.Name = elm.Name;
            setting.Value = elm.Value;
            return setting;
        }
    }
}
