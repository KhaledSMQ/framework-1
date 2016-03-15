// ============================================================================
// Project: Framework
// Name/Class: DataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Data.Config;
using Framework.Data.Model;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvDataStore : ACommon, IDataStore
    {
        //
        // INIT
        //

        public override void Init()
        {
            base.Init();
            __InitInMemoryStorage();
            __LoadConfig();
        }

        private void __InitInMemoryStorage()
        {
            __ClusterMap = new SortedDictionary<string, DataCluster>();
            __EntityMap = new SortedDictionary<string, DataEntity>();
        }

        private void __LoadConfig()
        {
            //
            // Load from the system configuration spec
            // the data store elements.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Load definitions into store.
            //

            if (null != config)
            {
                if (null != config.Clusters)
                {
                    Load(Transforms.ToDataCluster(config.Clusters));
                }
            }
        }

        public void InitClusters()
        {
            GetListOfClusters().Apply(__InitCluster);
        }

        private void __InitCluster(DataCluster cluster)
        {
            //
            // Extract the data context from cluster.
            //

            DataContext dataCtxSpec = cluster.Context;

            if (null != dataCtxSpec)
            {
                //
                // Initialize data context provider.
                // This means load the service provider, initialize it
                // and create the model.
                //

                string serviceName = dataCtxSpec.Service;

                if (serviceName.isNotNullAndEmpty())
                {
                    IProviderDataContext srvProviderDataContext = Scope.Hub.GetByName<IProviderDataContext>(serviceName);

                    if (null != srvProviderDataContext)
                    {
                        //
                        // Load the entities and partial models in data context provider.
                        //

                        srvProviderDataContext.Load(cluster.Entities);
                        srvProviderDataContext.Load(cluster.Models);

                        //
                        // Use the data context handler to create/setup the required 
                        // data model specification.
                        //

                        srvProviderDataContext.CreateModel();
                    }
                    else
                    {
                        //
                        // ERROR: Could not load data context provider service.
                        //
                    }
                }
                else
                {
                    //
                    // ERROR: Invalid service name for data cluster provider.
                    //
                }
            }
            else
            {
                //
                // ERROR: Data context provider specification for cluster is invalid!
                //
            }
        }

        //
        // LOAD
        //

        public void Load(IEnumerable<DataCluster> clusters)
        {
            clusters.Apply(Load);
        }

        public void Load(DataCluster cluster)
        {
            __LoadCluster(cluster);
            __LoadEntities(cluster);
        }

        private void __LoadCluster(DataCluster cluster)
        {
            __ClusterMap.AddNonExistent(cluster.Name, cluster);
        }

        private void __LoadEntities(DataCluster cluster)
        {
            if (null != cluster)
            {
                if (cluster.Name.isNotNullAndEmpty())
                {
                    //
                    // Load entities in cluster.
                    // Create a map between the entity and the parent cluster.
                    //

                    cluster.Entities.Apply(entity =>
                    {
                        if ((null != entity) && (entity.Name.isNotNullAndEmpty()) && (entity.TypeName.isNotNullAndEmpty()))
                        {
                            string entityUniqueName = _BuildUniqueName(cluster.Name, entity.Name);
                            __EntityMap.AddNonExistent(entityUniqueName, entity);
                        }
                        else
                        {
                            //
                            // ERROR: Entity definition is not valid, either the name or type is not defined!
                            //
                        }
                    });
                }
                else
                {
                    //
                    // ERROR: Cluster name is not valid.
                    //
                }
            }
            else
            {
                //
                // ERROR: Cluster is not defined!
                //
            }
        }

        //
        // RETRIEVE
        //

        public DataCluster GetClusterByName(string name)
        {
            DataCluster cluster = default(DataCluster);

            if (__ClusterMap.ContainsKey(name))
            {
                cluster = __ClusterMap[name];
            }

            return cluster;
        }

        public IEnumerable<DataCluster> GetListOfClusters()
        {
            return __ClusterMap.Values.ToList();
        }

        public DataEntity GetEntityByClusterAndName(string cluster, string entity)
        {
            string entityName = _BuildUniqueName(cluster, entity);
            return __EntityMap[entityName];
        }

        public Type GetEntityTypeByClusterAndName(string cluster, string entity)
        {
            Type entityType = default(Type);
            DataEntity entityDef = GetEntityByClusterAndName(cluster, entity);
            if (null != entityDef)
            {
                entityType = Type.GetType(entityDef.TypeName);
            }

            return entityType;
        }

        private IProviderDataContext _GetProviderContextForEntity(string cluster, string entity)
        {
            IProviderDataContext runtimeDataContext = null;

            DataCluster clusterDef = __ClusterMap[cluster];
            if (null != clusterDef)
            {
                DataContext specdataContext = clusterDef.Context;
                if (null != specdataContext)
                {
                    runtimeDataContext = Scope.Hub.GetByName<IProviderDataContext>(specdataContext.Service);
                }
            }

            return runtimeDataContext;
        }

        //
        // HELPERS

        //

        private string _BuildUniqueName(string clusterName, string entityName)
        {
            return string.Concat(clusterName.Trim().ToLower(), ".", entityName.Trim().ToLower());
        }

        //
        // Memory storage.
        //

        private IDictionary<string, DataCluster> __ClusterMap = null;
        private IDictionary<string, DataEntity> __EntityMap = null;
    }
}
