// ============================================================================
// Project: Framework
// Name/Class: DataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Data.Config;
using Framework.Data.Model;
using Framework.Data.Patterns;
using Framework.Factory.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Data.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // Data Ecosystem Services.
        //

        public IDataClusterEntry Clusters { get { return Scope.Hub.GetUnique<IDataClusterEntry>(); } }

        public IDataContextEntry Contexts { get; set; }

        public IDataEntityEntry Entities { get; set; }

        public IDataPartialModelEntry Models { get; set; }

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
            //
            // Initialize the in-memory data stores.
            //

            __ClusterNameClusterMap = new SortedDictionary<string, DataCluster>();
            __EntityNameClusterMap = new SortedDictionary<string, DataCluster>();
            __EntityTypeClusterMap = new SortedDictionary<string, DataCluster>();
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
            __ClusterNameClusterMap.AddNonExistent(cluster.Name, cluster);
        }

        private void __LoadEntities(DataCluster cluster)
        {
            //
            // Load entities in cluster.
            // Create a map between the entity and the parent cluster.
            //

            cluster.Entities.Apply(entity =>
            {
                if ((null != entity) && (entity.Name.isNotNullAndEmpty()) && (entity.TypeName.isNotNullAndEmpty()))
                {
                    __EntityNameClusterMap.AddNonExistent(entity.Name, cluster);
                    __EntityTypeClusterMap.AddNonExistent(entity.TypeName, cluster);
                }
                else
                {
                    //
                    // ERROR: Entity definition is not valid, either the name or type is not defined!
                    //
                }
            });
        }

        //
        // RETRIEVE
        //

        public IEnumerable<DataCluster> GetListOfClusters()
        {
            return __ClusterNameClusterMap.Values.ToList();
        }

        //
        // Data Set/Object CRUD layers.
        //

        public IDataSet<T> GetDataSet<T>()
        {
            return null;
        }     

        public IDataObject<T> GetDataObject<T>()
        {
            return null;
        }

        private IProviderDataContext _GetProviderContextForEntityBasedOnType<T>()
        {
            return _GetProviderContextForEntityBasedOnType(typeof(T).FullName);
        }

        private IProviderDataContext _GetProviderContextForEntityBasedOnType(string type)
        {
            IProviderDataContext runtimeDataContext = null;

            if (type.isNotNullAndEmpty())
            {
                DataCluster cluster = __EntityTypeClusterMap[type];
                if (null != cluster)
                {
                    DataContext specdataContext = cluster.Context;
                    if (null != specdataContext)
                    {

                    }
                }
            }

            return runtimeDataContext;
        }

        //
        // Memory storage.
        //

        private IDictionary<string, DataCluster> __ClusterNameClusterMap = null;
        private IDictionary<string, DataCluster> __EntityNameClusterMap = null;
        private IDictionary<string, DataCluster> __EntityTypeClusterMap = null;
    }
}
