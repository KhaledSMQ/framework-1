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
using Framework.Core.Error;
using System.Text.RegularExpressions;

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
            LoadConfig();
        }

        private void __InitInMemoryStorage()
        {
            __ClusterMap = new SortedDictionary<string, DataCluster>();
            __EntityMap = new SortedDictionary<string, DataEntity>();
            __ModelMap = new SortedDictionary<string, DataPartialModel>();
            __EntityContextMap = new SortedDictionary<string, DataContext>();
            __ModelContextMap = new SortedDictionary<string, DataContext>();
        }

        public void LoadConfig()
        {
            //
            // Load from the system configuration spec
            // the data store elements.
            //

            ManagerConfiguration config = (ManagerConfiguration)System.Configuration.ConfigurationManager.GetSection(Constants.SECTION);

            //
            // Load the configuration clusters from config store 
            // and load them into the runtime store service.
            //

            if (null != config)
            {
                config.Clusters.Map<ClusterElement, DataCluster>(new List<DataCluster>(), Transforms.Converter).Apply(Add);
            }
        }

        //
        // CLUSTERS
        //

        public void Add(DataCluster cluster)
        {
            if (null != cluster)
            {
                if (cluster.Name.isNotNullAndEmpty())
                {
                    if (VerifyParcel(cluster.Name))
                    {
                        if (!__ClusterMap.ContainsKey(cluster.Name))
                        {
                            //
                            // Add the cluster to map.
                            // No duplicate names are allowed.
                            //

                            __ClusterMap.AddNonExistent(cluster.Name, cluster);

                            //
                            // Load the entities from the cluster definition 
                            // create the mapping between the full entity name 
                            // its definition. Take the oportunity to check if 
                            // cluster has entities with the same unique name,
                            // but also check if entity naem is valid.
                            //

                            cluster.Entities.Apply(entity =>
                            {
                                if ((null != entity) && (entity.Name.isNotNullAndEmpty()) && (entity.TypeName.isNotNullAndEmpty()))
                                {
                                    if (VerifyParcel(entity.Name))
                                    {
                                        string entityID = BuildComplexIdentifier(cluster.Name, entity.Name);

                                        if (!__EntityMap.ContainsKey(entityID))
                                        {
                                            __EntityMap.AddNonExistent(entityID, entity);
                                        }
                                        else
                                        {
                                            //
                                            // ERROR: Entity name is not valid.
                                            //

                                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity name '{0}' was already defined! ({1})", entity.Name, entityID);
                                        }
                                    }
                                    else
                                    {
                                        //
                                        // ERROR: Entity name is not valid.
                                        //

                                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity name '{0}' is not valid", entity.Name);
                                    }
                                }
                                else
                                {
                                    //
                                    // ERROR: Entity definition is not valid, either the name or type is not defined!
                                    //

                                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity definition in cluster '{0}' is not valid, either the name or type is not defined", cluster.Name);
                                }
                            });

                            //
                            // Process all partial data models.
                            //

                            cluster.Models.Apply(model => 
                            {
                                if ((null != model) && (model.Name.isNotNullAndEmpty()) && (model.TypeName.isNotNullAndEmpty()))
                                {
                                    if (VerifyParcel(model.Name))
                                    {
                                        string modelID = BuildComplexIdentifier(cluster.Name, model.Name);

                                        if (!__ModelMap.ContainsKey(modelID))
                                        {
                                            __ModelMap.AddNonExistent(modelID, model);
                                        }
                                        else
                                        {
                                            //
                                            // ERROR: Partial model name is not valid.
                                            //

                                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model name '{0}' was already defined! ({1})", model.Name, modelID);
                                        }
                                    }
                                    else
                                    {
                                        //
                                        // ERROR: Partial model name is not valid.
                                        //

                                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model name '{0}' is not valid", model.Name);
                                    }
                                }
                                else
                                {
                                    //
                                    // ERROR: Partial model definition is not valid, either the name or type is not defined!
                                    //

                                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model definition in cluster '{0}' is not valid, either the name or type is not defined", cluster.Name);
                                }
                            });

                            //
                            // Process the list of data contexts.
                            // Create the map between the entity and 
                            // the data context definition.
                            //

                            cluster.Contexts.Apply(context =>
                            {
                                if (null != context)
                                {
                                    //
                                    // Process context entity references.
                                    //

                                    context.Entities.Apply(entityRef =>
                                    {
                                        string entityID = BuildComplexIdentifier(cluster.Name, entityRef.Name);

                                        if (__EntityMap.ContainsKey(entityID))
                                        {
                                            if (!__EntityContextMap.ContainsKey(entityID))
                                            {
                                                __EntityContextMap.Add(entityID, context);
                                            }
                                            else
                                            {
                                                //
                                                // ERROR: Entity identifierwas already mapped for the context.
                                                //

                                                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity reference '{0}' was already defined for this context ('{1}')", entityRef.Name, entityID);
                                            }
                                        }
                                        else
                                        {
                                            //
                                            // ERROR: Entity reference is invalid, no entity exists with that name.
                                            //

                                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity reference '{0}' is not defined, cannot add it to data context ('{1}')", entityRef.Name, entityID);
                                        }
                                    });

                                    //
                                    // Process context model references.
                                    //
                                }
                                else
                                {
                                    //
                                    // ERROR: Invalid data context for cluster.
                                    //

                                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "Invalid data context for cluster '{0}'", cluster.Name);
                                }
                            });
                        }
                        else
                        {
                            //
                            // ERROR: Cluster name is not valid.
                            //

                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster '{0}' already defined!", cluster.Name);
                        }
                    }
                    else
                    {
                        //
                        // ERROR: Cluster name is not valid.
                        //

                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster name '{0}' is not valid", cluster.Name);
                    }
                }
                else
                {
                    //
                    // ERROR: Cluster name null or empty
                    //

                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster name null or empty");
                }
            }
            else
            {
                //
                // ERROR: Cluster is not defined!
                //

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid cluster!");
            }
        }

        public void Init(DataCluster cluster)
        {
            //
            // Initialize all the data contexts found
            // in the cluster definition.
            //

            cluster.Contexts.Apply(context =>
            {
                if (null != context)
                {
                    //
                    // Initialize data context provider.
                    // This means load the service provider, initialize it
                    // and create the model.
                    //

                    string serviceName = context.Provider.Name;

                    if (serviceName.isNotNullAndEmpty())
                    {
                        IProviderDataContext srvProviderDataContext = Scope.Hub.Get<IProviderDataContext>(context.Provider);

                        if (null != srvProviderDataContext)
                        {
                            //
                            // Get all the entities specs that are from this 
                            // data context, i.e. Transform an entity reference
                            // into an entity definition.
                            //

                            IEnumerable<DataEntity> entities = context.Entities.Map(new List<DataEntity>(), entityRef =>
                            {
                                return __EntityMap[BuildComplexIdentifier(cluster.Name, entityRef.Name)];
                            });

                            //
                            // Get all the models that are part of the
                            // current data context.
                            //

                            IEnumerable<DataPartialModel> models = context.Models.Map(new List<DataPartialModel>(), modelRef =>
                            {
                                return __ModelMap[BuildComplexIdentifier(cluster.Name, modelRef.Name)];
                            });

                            //
                            // Load the entities and partial models in data context provider.
                            //

                            srvProviderDataContext.Load(entities);
                            srvProviderDataContext.Load(models);

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

                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "Could not load data context provider service");
                        }
                    }
                    else
                    {
                        //
                        // ERROR: Invalid service name for data cluster provider.
                        //

                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "Invalid service name for data cluster provider");
                    }
                }
                else
                {
                    //
                    // ERROR: Data context provider specification for cluster is invalid!
                    //

                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "Data context provider specification for cluster is invalid!");
                }
            });
        }

        public DataCluster GetCluster(string name)
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

        public void InitClusters()
        {
            GetListOfClusters().Apply(Init);
        }

        //
        // ENTITIES
        //

        public DataEntity GetEntity(string fullname)
        {
            return __EntityMap[fullname];
        }

        public DataEntity GetEntity(string cluster, string entity)
        {
            return GetEntity(BuildComplexIdentifier(cluster, entity));
        }

        public Type GetEntityType(string fullname)
        {
            DataEntity entityDef = GetEntity(fullname);
            return null != entityDef ? Type.GetType(entityDef.TypeName) : default(Type);
        }

        public Type GetEntityType(string cluster, string entity)
        {
            return GetEntityType(BuildComplexIdentifier(cluster, entity));
        }

        public IProviderDataContext GetEntityDataProviderContext(string entityID)
        {
            //
            // Default value for data context provider service instance.
            //

            IProviderDataContext dataContextProvider = null;

            //
            // Get the data context definition that is associated with the entity.
            //

            DataContext dataContextForEntity = __EntityContextMap[entityID];

            if (null != dataContextForEntity)
            {
                if (dataContextForEntity.Provider.Name.isNotNullAndEmpty())
                {
                    //
                    // found the service name, now we need to check
                    // if this service already has an instance
                    // and return it.
                    //

                    dataContextProvider = Scope.Hub.Get<IProviderDataContext>(dataContextForEntity.Provider);
                }
                else
                {
                    Throw.Internal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity with fullname '{0}' does not define a valid data context service provider name", entityID);
                }
            }
            else
            {
                Throw.Internal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity with fullname '{0}' is not associated with any data context definition", entityID);
            }

            //
            // Return the data context provider 
            // service instance to caller.
            //

            return dataContextProvider;
        }

        public IProviderDataContext GetEntityDataProviderContext(string cluster, string entity)
        {
            return GetEntityDataProviderContext(BuildComplexIdentifier(cluster, entity));
        }

        //
        // HELPERS
        // Methods used in identifier checking/building.
        //        

        public string BuildComplexIdentifier(params string[] parcels)
        {
            return parcels.Join(".");
        }

        public bool VerifyParcel(string value)
        {
            return new Regex(@"[a-zA-Z][a-zA-Z0-9_]*", RegexOptions.Compiled).IsMatch(value);
        }

        //
        // Memory storage.
        //

        private IDictionary<string, DataCluster> __ClusterMap = null;
        private IDictionary<string, DataPartialModel> __ModelMap = null;
        private IDictionary<string, DataEntity> __EntityMap = null;
        private IDictionary<string, DataContext> __EntityContextMap = null;
        private IDictionary<string, DataContext> __ModelContextMap = null;
    }
}
