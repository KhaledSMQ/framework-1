// ============================================================================
// Project: Framework
// Name/Class: DataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Data.Config;
using Framework.Data.Model;
using Framework.Data.Patterns;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
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
            __Clusters = new SortedDictionary<string, pClusterInfo>();
            __Contexts = new SortedDictionary<string, pContextInfo>();
            __Entities = new SortedDictionary<string, pEntityInfo>();
            __Models = new SortedDictionary<string, pModelInfo>();
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
                config.Clusters
                    .Map<ClusterElement, DataCluster>(new List<DataCluster>(), Transforms.Converter)
                    .Apply(Load);
            }
        }

        //
        // CLUSTERS
        //

        public void Load(DataCluster cluster)
        {
            if (null != cluster)
            {
                if (cluster.Name.isNotNullAndEmpty())
                {
                    if (VerifyParcel(cluster.Name))
                    {
                        //
                        // Build the unique cluster identifier.
                        //

                        string clusterID = cluster.Name;

                        if (!__Clusters.ContainsKey(clusterID))
                        {
                            //
                            // Build the cluster runtime object.
                            //

                            pClusterInfo clusterInfo = new pClusterInfo()
                            {
                                ID = clusterID,
                                Original = cluster,
                                Contexts = new List<pContextInfo>()
                            };

                            //
                            // PROCESS: Cluster Entities.
                            //

                            cluster.Entities.Apply(entity =>
                            {
                                if ((null != entity) && (entity.Name.isNotNullAndEmpty()) && (entity.TypeName.isNotNullAndEmpty()))
                                {
                                    if (VerifyParcel(entity.Name))
                                    {
                                        //
                                        // Build the full entity identifier.
                                        //

                                        string entityID = BuildComplexIdentifier(cluster.Name, entity.Name);

                                        if (!__Entities.ContainsKey(entityID))
                                        {
                                            //
                                            // Build the entity map runtime information.                                            
                                            //

                                            pEntityInfo entityInfo = new pEntityInfo()
                                            {
                                                ID = entityID,
                                                Original = entity
                                            };

                                            //
                                            // Add entity to runtime.
                                            //

                                            __Entities.AddNonExistent(entityID, entityInfo);
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
                            // PROCESS: Cluster Partial Models.
                            //

                            cluster.Models.Apply(model =>
                            {
                                if ((null != model) && (model.Name.isNotNullAndEmpty()) && (model.TypeName.isNotNullAndEmpty()))
                                {
                                    if (VerifyParcel(model.Name))
                                    {
                                        string modelID = BuildComplexIdentifier(cluster.Name, model.Name);

                                        if (!__Models.ContainsKey(modelID))
                                        {
                                            //
                                            // Build the entity map runtime information.                                            
                                            //

                                            pModelInfo modelInfo = new pModelInfo()
                                            {
                                                ID = modelID,
                                                Original = model
                                            };

                                            //
                                            // Add model to runtime.
                                            //

                                            __Models.AddNonExistent(modelID, modelInfo);
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
                            // PROCESS: Cluster Contexts.
                            //

                            cluster.Contexts.Apply(context =>
                            {
                                if (null != context)
                                {
                                    if (VerifyParcel(context.Name))
                                    {
                                        //
                                        // Build the context unique identifier.
                                        //

                                        string contextID = BuildComplexIdentifier(cluster.Name, context.Name);

                                        if (!__Contexts.ContainsKey(contextID))
                                        {
                                            //
                                            // Setup the provider service.
                                            //

                                            ServiceEntry providerSrvEntry = new ServiceEntry()
                                            {
                                                Name = string.Empty,
                                                Contract = typeof(IProviderDataContext).FullName,
                                                TypeName = context.Provider.TypeName,
                                                Settings = context.Provider.Settings
                                            };

                                            //
                                            // Setup the data context mapping info.
                                            //

                                            pContextInfo contextInfo = new pContextInfo()
                                            {
                                                ID = contextID,
                                                Original = context,
                                                Provider = context.Provider,
                                                ProviderServiceEntry = providerSrvEntry,
                                                Entities = new List<pEntityInfo>(),
                                                Models = new List<pModelInfo>()
                                            };

                                            //
                                            // PROCESS: Context Entity Refs.
                                            //

                                            context.Entities.Apply(entityRef =>
                                            {
                                                string entityID = BuildComplexIdentifier(cluster.Name, entityRef.Name);

                                                if (__Entities.ContainsKey(entityID))
                                                {
                                                    //
                                                    // Get the current entity mapping info.
                                                    //

                                                    pEntityInfo entityInfo = __Entities[entityID];

                                                    //
                                                    // Associate the context info with entity.
                                                    //

                                                    entityInfo.Context = contextInfo;

                                                    //
                                                    // Instantiate the data entity for the context.
                                                    //

                                                    entityInfo.Instance = new DataEntity()
                                                    {
                                                        Name = entityInfo.Original.Name,
                                                        Kind = entityInfo.Original.Kind,
                                                        TypeName = entityInfo.Original.TypeName,

                                                        Description = entityRef.Description,
                                                        Settings = entityRef.Settings
                                                    };

                                                    //
                                                    // Add the new entity info to the context runtime.
                                                    //

                                                    contextInfo.Entities.Add(entityInfo);
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
                                            // PROCESS: Context Model Refs.
                                            //

                                            context.Models.Apply(modelRef =>
                                            {
                                                string modelID = BuildComplexIdentifier(cluster.Name, modelRef.Name);

                                                if (__Models.ContainsKey(modelID))
                                                {
                                                    //
                                                    // Get the current model mapping info.
                                                    //

                                                    pModelInfo modelInfo = __Models[modelID];

                                                    //
                                                    // Associate the context runtime info.
                                                    //

                                                    modelInfo.Context = contextInfo;

                                                    //
                                                    // Instantiate the data partial model for the context.
                                                    //

                                                    modelInfo.Instance = new DataPartialModel()
                                                    {
                                                        Name = modelInfo.Original.Name,
                                                        TypeName = modelInfo.Original.TypeName,

                                                        Description = modelRef.Description,
                                                        Settings = modelRef.Settings
                                                    };

                                                    //
                                                    // Add the new model info to the context runtime.
                                                    //

                                                    contextInfo.Models.Add(modelInfo);
                                                }
                                                else
                                                {
                                                    //
                                                    // ERROR: Model reference is invalid, no entity exists with that name.
                                                    //

                                                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model reference '{0}' is not defined, cannot add it to data context ('{1}')", modelRef.Name, modelID);
                                                }
                                            });

                                            //
                                            // Load the context into memory.
                                            //

                                            __Contexts.AddNonExistent(contextID, contextInfo);

                                            //
                                            // Associate the context info with the cluster info.
                                            //

                                            clusterInfo.Contexts.Add(contextInfo);
                                        }
                                        else
                                        {
                                            //
                                            // ERROR: Entity name is not valid.
                                            //

                                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "context name '{0}' was already defined! ({1})", context.Name, contextID);
                                        }
                                    }
                                    else
                                    {
                                        //
                                        // ERROR: Entity name is not valid.
                                        //

                                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "context name '{0}' is not valid", context.Name);
                                    }
                                }
                            });

                            //
                            // Add the cluster to the runtime.
                            //

                            __Clusters.AddNonExistent(clusterID, clusterInfo);
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

                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster name is null or empty");
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

        public void Init(string clusterID)
        {
            //
            // Get a loaded cluster runtime info object.
            //

            pClusterInfo cluster = __Clusters[clusterID];

            //
            // Initialize all the data contexts found
            // in the cluster definition.
            //

            cluster.Contexts.Apply(context =>
            {
                if (null != context)
                {
                    //
                    // Initialize data context provider. This means load the service 
                    // provider, initialize it and create the model.
                    //

                    if (null != context.Provider)
                    {
                        //
                        // Try to get the instance.
                        // 

                        context.ProviderService = Scope.Hub.Get<IProviderDataContext>(context.ProviderServiceEntry);

                        if (null != context.ProviderService)
                        {
                            //
                            // Get the context entities and model definitions.
                            //

                            IEnumerable<DataEntity> entities = context.Entities.Map(new List<DataEntity>(), e => { return e.Instance; });
                            IEnumerable<DataPartialModel> models = context.Models.Map(new List<DataPartialModel>(), e => { return e.Instance; });                          

                            //
                            // Load the entities and partial models in data context provider.
                            //

                            context.ProviderService.Load(entities);
                            context.ProviderService.Load(models);

                            //
                            // Use the data context handler to create/setup the required 
                            // data model specification.
                            //

                            context.ProviderService.CreateModel();
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

        public void InitClusters()
        {
            __Clusters.Keys.Apply(Init);
        }

        //
        // ENTITIES
        //

        public DataEntity GetEntity(string entityID)
        {
            return __Entities[entityID].Original;
        }

        public DataEntity GetEntity(string cluster, string entity)
        {
            return GetEntity(BuildComplexIdentifier(cluster, entity));
        }

        public Type GetEntityType(string entityID)
        {
            DataEntity entityDef = GetEntity(entityID);
            return null != entityDef ? Type.GetType(entityDef.TypeName) : default(Type);
        }

        public Type GetEntityType(string cluster, string entity)
        {
            return GetEntityType(BuildComplexIdentifier(cluster, entity));
        }

        public IProviderDataContext GetEntityDataProviderContext(string entityID)
        {
            return __Entities[entityID].Context.ProviderService;
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

        private IDictionary<string, pClusterInfo> __Clusters = null;
        private IDictionary<string, pContextInfo> __Contexts = null;
        private IDictionary<string, pEntityInfo> __Entities = null;
        private IDictionary<string, pModelInfo> __Models = null;

        //
        // PRIVATE-CLASSES ----------------------------------------------------
        // Used in memory related store operations.
        //

        //
        // Class to map information about data clusters.
        // This is used to map unique data cluster identifier
        // to their runtime information.
        //

        private class pClusterInfo
        {
            //
            // Complete identifier.
            //

            public string ID { get; set; }

            //
            // Original context specification.
            //

            public DataCluster Original { get; set; }

            //
            // List of data contexts.
            //

            public IList<pContextInfo> Contexts { get; set; }

            //
            // CONSTRUCTOR
            //

            public pClusterInfo()
            {
                ID = null;
                Original = null;
                Contexts = null;
            }
        }

        //
        // Class to map information about data contexts.
        // This is used to map unique data context identifier
        // to their runtime information.
        //

        private class pContextInfo
        {
            //
            // Complete identifier, includes
            // cluster name.
            //

            public string ID { get; set; }

            //
            // Original context specification.
            //

            public DataContext Original { get; set; }

            //
            // Provider related info.
            //

            public DataProvider Provider { get; set; }

            public ServiceEntry ProviderServiceEntry { get; set; }

            public IProviderDataContext ProviderService { get; set; }

            //
            // List of context runtime entities.
            //

            public IList<pEntityInfo> Entities { get; set; }

            //
            // List of context runtime partial models.
            //

            public IList<pModelInfo> Models { get; set; }

            //
            // CONSTRUCTOR
            //

            public pContextInfo()
            {
                ID = null;
                Original = null;
                Provider = null;
                ProviderServiceEntry = null;
                ProviderService = null;
                Entities = null;
                Models = null;
            }
        }

        //
        // Class to map information about data entities.
        // Used to map unique entity identifiers to their
        // runtime information.
        //

        private class pEntityInfo
        {
            //
            // Complete identifier, includes
            // cluster name.
            //

            public string ID { get; set; }

            //
            // Original entity specification.
            //

            public DataEntity Original { get; set; }

            //
            // Entity definition used in context.
            //

            public DataEntity Instance { get; set; }

            //
            // The data context runtime mapping information.
            //
            public pContextInfo Context { get; set; }

            //
            // CONSTRUCTOR
            //

            public pEntityInfo()
            {
                ID = null;
                Original = null;
                Instance = null;
                Context = null;
            }
        }

        //
        // Class to map information about data models.
        // Used to map unique model identifiers to their
        // runtime information.
        //

        private class pModelInfo
        {
            //
            // Complete identifier, includes cluster name.
            //

            public string ID { get; set; }

            //
            // Original model specification.
            //

            public DataPartialModel Original { get; set; }

            //
            // The partial model seen by a data context.
            //

            public DataPartialModel Instance { get; set; }

            //
            // The data context runtime mapping information.
            //

            public pContextInfo Context { get; set; }

            //
            // CONSTRUCTOR
            //

            public pModelInfo()
            {
                ID = null;
                Original = null;
                Instance = null;
                Context = null;
            }
        }
    }
}
