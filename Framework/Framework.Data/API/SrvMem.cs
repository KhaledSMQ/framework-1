// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Data.Model.Mem;
using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Framework.Data.API
{
    public class SrvMem : ACommon, IMem
    {
        //
        // INITIALIZATION
        //

        public override void Init()
        {
            //
            // Call base initializer.
            //

            base.Init();

            //
            // Initialize in-memory data structures.
            //

            __Domains = new SortedDictionary<string, MemDomain>();
            __Clusters = new SortedDictionary<string, MemCluster>();
            __Contexts = new SortedDictionary<string, MemContext>();
            __Entities = new SortedDictionary<string, MemEntity>();
            __Queries = new SortedDictionary<string, MemQuery>();
            __Models = new SortedDictionary<string, MemModel>();
        }

        //
        // DOMAINS
        //

        public void Domain_Import(FW_DataDomain domain)
        {
            string domainID = default(string);

            if (null != domain)
            {
                if (domain.Name.isNotNullAndEmpty())
                {
                    if (VerifyParcel(domain.Name))
                    {
                        //
                        // Build the unique cluster identifier.
                        //

                        domainID = domain.Name;

                        if (!__Domains.ContainsKey(domainID))
                        {
                            //
                            // Build the domain runtime object.
                            //

                            MemDomain domainInfo = new MemDomain()
                            {
                                ID = domainID,
                                Original = domain,
                                Clusters = domain.Clusters.Map(new List<string>(), cluster => { return Cluster_Import(domainID, cluster); })
                            };

                            //
                            // Add domain info to runtime.
                            //

                            __Domains.AddNonExistent(domainID, domainInfo);
                        }
                        else
                        {
                            //
                            // ERROR: Domain is not defined!
                            //

                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "domain '{0}' already defined!", domainID);
                        }
                    }
                    else
                    {
                        //
                        // ERROR: Domain is not defined!
                        //

                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "domain is invalid!");
                    }
                }
                else
                {
                    //
                    // ERROR: Domain is not defined!
                    //

                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "domain name is null or empty!");
                }
            }
            else
            {
                //
                // ERROR: Domain is not defined!
                //

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid domain instance!");
            }
        }

        public void Domain_Init(string domainID)
        {
            Domain_Init(Domain_Get(domainID));
        }

        public void Domain_Init(MemDomain domain)
        {
            domain.Clusters.Apply(clusterID =>
            {
                MemCluster cluster = Cluster_Get(clusterID);

                cluster.Contexts.Apply(contextID =>
                {
                    MemContext context = Context_Get(contextID);

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

                            context.ProviderService = Scope.Hub.New<IProviderDataContext>(context.ProviderServiceEntry);

                            if (null != context.ProviderService)
                            {
                                //
                                // Get the context entities and model definitions.
                                //

                                IEnumerable<FW_DataEntity> entities = context.Entities.Map(new List<FW_DataEntity>(), e => { return Entity_Get(e).Instance; });
                                IEnumerable<FW_DataPartialModel> models = context.Models.Map(new List<FW_DataPartialModel>(), e => { return Model_Get(e).Instance; });

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
            });
        }

        public MemDomain Domain_Get(params string[] parcels)
        {
            MemDomain domainInfo = default(MemDomain);
            string domainID = GetID(parcels);

            if (__Domains.ContainsKey(domainID))
            {
                domainInfo = __Domains[domainID];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "domain with identifier '{0}' does not exist!", domainID);
            }

            return domainInfo;
        }

        public IEnumerable<MemDomain> Domain_GetList()
        {
            return __Domains.Values;
        }

        //
        // CLUSTERS
        //

        public string Cluster_Import(string domainID, FW_DataCluster cluster)
        {
            string clusterID = default(string);

            if (null != cluster)
            {
                if (cluster.Name.isNotNullAndEmpty())
                {
                    if (VerifyParcel(cluster.Name))
                    {
                        //
                        // Build the unique cluster identifier.
                        //

                        clusterID = GetID(domainID, cluster.Name);

                        if (!__Clusters.ContainsKey(clusterID))
                        {
                            //
                            // Build the cluster runtime object.
                            //

                            MemCluster clusterInfo = new MemCluster()
                            {
                                ID = clusterID,
                                Original = cluster,

                                //
                                // NOTE: Run first the entity and model import functions and then the context
                                // This is so because the context has references to entities and models.
                                //

                                Entities = cluster.Entities.Map(new List<string>(), entity => { return Entity_Import(clusterID, entity); }),
                                Models = cluster.Models.Map(new List<string>(), model => { return Model_Import(clusterID, model); }),

                                //
                                // Always run this after importing entities and models.
                                //

                                Contexts = cluster.Contexts.Map(new List<string>(), context => { return Context_Import(clusterID, context); })
                            };

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

                            Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster '{0}' already defined!", clusterID);
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

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid cluster instance!");
            }

            return clusterID;
        }

        public MemCluster Cluster_Get(params string[] parcels)
        {
            MemCluster info = default(MemCluster);
            string id = GetID(parcels);

            if (__Clusters.ContainsKey(id))
            {
                info = __Clusters[id];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "cluster with identifier '{0}' does not exist!", id);
            }

            return info;
        }

        public IEnumerable<MemCluster> Cluster_GetList()
        {
            return __Clusters.Values;
        }

        //
        // CONTEXTS
        //

        public string Context_Import(string clusterID, FW_DataContext context)
        {
            string contextID = default(string);

            if (null != context)
            {
                if (VerifyParcel(context.Name))
                {
                    //
                    // Build the context unique identifier.
                    //

                    contextID = GetID(clusterID, context.Name);

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

                        MemContext contextInfo = new MemContext()
                        {
                            ID = contextID,
                            Original = context,
                            Provider = context.Provider,
                            ProviderServiceEntry = providerSrvEntry,
                            Entities = new List<string>(),
                            Models = new List<string>()
                        };

                        //
                        // PROCESS: Context Entity Refs.
                        //

                        context.Entities.Apply(entityRef =>
                        {
                            string entityID = GetID(clusterID, entityRef.Name);

                            if (__Entities.ContainsKey(entityID))
                            {
                                //
                                // Get the current entity mapping info.
                                //

                                MemEntity entityInfo = Entity_Get(entityID);

                                //
                                // Associate the context info with entity.
                                //

                                entityInfo.Context = contextID;

                                //
                                // Instantiate the data entity for the context.
                                //

                                entityInfo.Instance = new FW_DataEntity()
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

                                contextInfo.Entities.Add(entityID);
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
                            string modelID = GetID(clusterID, modelRef.Name);

                            if (__Models.ContainsKey(modelID))
                            {
                                //
                                // Get the current model mapping info.
                                //

                                MemModel modelInfo = Model_Get(modelID);

                                //
                                // Associate the context runtime info.
                                //

                                modelInfo.Context = contextID;

                                //
                                // Instantiate the data partial model for the context.
                                //

                                modelInfo.Instance = new FW_DataPartialModel()
                                {
                                    Name = modelInfo.Original.Name,
                                    TypeName = modelInfo.Original.TypeName,

                                    Description = modelRef.Description,
                                    Settings = modelRef.Settings
                                };

                                //
                                // Add the new model info to the context runtime.
                                //

                                contextInfo.Models.Add(modelID);
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

            return contextID;
        }

        public MemContext Context_Get(params string[] parcels)
        {
            MemContext info = default(MemContext);
            string id = GetID(parcels);

            if (__Contexts.ContainsKey(id))
            {
                info = __Contexts[id];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "context with identifier '{0}' does not exist!", id);
            }

            return info;
        }

        public IEnumerable<MemContext> Context_GetList()
        {
            return __Contexts.Values;
        }

        //
        // ENTITIES
        //

        public string Entity_Import(string clusterID, FW_DataEntity entity)
        {
            string entityID = default(string);

            if ((null != entity) && (entity.Name.isNotNullAndEmpty()) && (entity.TypeName.isNotNullAndEmpty()))
            {
                if (VerifyParcel(entity.Name))
                {
                    //
                    // Build the full entity identifier.
                    //

                    entityID = GetID(clusterID, entity.Name);

                    if (!__Entities.ContainsKey(entityID))
                    {
                        //
                        // Build the entity map runtime information.                                            
                        //

                        MemEntity entityInfo = new MemEntity()
                        {
                            ID = entityID,
                            Cluster = clusterID,
                            Type = Type.GetType(entity.TypeName),
                            Original = entity
                        };

                        //
                        // Process entity queries.
                        //

                        entity.Queries.Apply(query => Query_Import(entityID, query));

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

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity definition in cluster '{0}' is not valid, either the name or type is not defined", clusterID);
            }

            return entityID;
        }

        public MemEntity Entity_Get(params string[] parcels)
        {
            MemEntity info = default(MemEntity);
            string id = GetID(parcels);

            if (__Entities.ContainsKey(id))
            {
                info = __Entities[id];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity with identifier '{0}' does not exist!", id);
            }

            return info;
        }

        public Type Entity_GetType(params string[] parcels)
        {
            return Entity_Get(parcels).Type;
        }

        public IEnumerable<MemEntity> Entity_GetList()
        {
            return __Entities.Values;
        }

        public IProviderDataContext Entity_GetProviderDataContext(params string[] parcels)
        {
            return Context_Get(Entity_Get(parcels).Context).ProviderService;
        }

        //
        // MODELS
        //

        public string Model_Import(string clusterID, FW_DataPartialModel model)
        {
            string modelID = default(string);

            if ((null != model) && (model.Name.isNotNullAndEmpty()) && (model.TypeName.isNotNullAndEmpty()))
            {
                if (VerifyParcel(model.Name))
                {
                    modelID = GetID(clusterID, model.Name);

                    if (!__Models.ContainsKey(modelID))
                    {
                        //
                        // Build the entity map runtime information.                                            
                        //

                        MemModel modelInfo = new MemModel()
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

                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model definition in cluster '{0}' is not valid, either the name or type is not defined", clusterID);
            }

            return modelID;
        }

        public MemModel Model_Get(params string[] parcels)
        {
            MemModel info = default(MemModel);
            string id = GetID(parcels);

            if (__Models.ContainsKey(id))
            {
                info = __Models[id];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "partial model with identifier '{0}' does not exist!", id);
            }

            return info;
        }

        public IEnumerable<MemModel> Model_GetList()
        {
            return __Models.Values;
        }

        //
        // QUERIES
        //

        public string Query_Import(string entityID, FW_DataQuery query)
        {
            string queryID = default(string);

            if (null != query)
            {
                if (VerifyParcel(query.Name))
                {
                    queryID = GetID(entityID, query.Name);

                    if (!__Queries.ContainsKey(queryID))
                    {
                        //
                        // Build query info runtime.
                        //

                        MemQuery queryInfo = new MemQuery()
                        {
                            ID = queryID,
                            Original = query,
                            Kind = query.Kind,
                            Query = query.Expression,
                            Callback = query.Callback
                        };

                        //
                        // Add query to runtime.
                        //

                        __Queries.Add(queryID, queryInfo);
                    }
                    else
                    {
                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "query '{0}' was already defined!", queryID);
                    }
                }
                else
                {
                    Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid name for query '{0}' in entity '{1}'", query.Name, entityID);
                }
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid query in entity '{0}'", entityID);
            }

            return queryID;
        }

        public MemQuery Query_Get(params string[] parcels)
        {
            MemQuery info = default(MemQuery);
            string id = GetID(parcels);

            if (__Queries.ContainsKey(id))
            {
                info = __Queries[id];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "query with identifier '{0}' does not exist!", id);
            }

            return info;
        }

        public IEnumerable<MemQuery> Query_GetList()
        {
            return __Queries.Values;
        }

        //
        // HELPERS
        // Methods used in identifier checking/building.
        //        

        public string GetID(params string[] parcels)
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

        private IDictionary<string, MemDomain> __Domains = null;
        private IDictionary<string, MemCluster> __Clusters = null;
        private IDictionary<string, MemContext> __Contexts = null;
        private IDictionary<string, MemEntity> __Entities = null;
        private IDictionary<string, MemQuery> __Queries = null;
        private IDictionary<string, MemModel> __Models = null;
    }
}
