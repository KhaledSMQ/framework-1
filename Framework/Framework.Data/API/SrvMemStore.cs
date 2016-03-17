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
using Framework.Data.Model.Diagnostics;
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
    public class SrvMemStore : ACommon, IMemStore
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

            __Domains = new SortedDictionary<string, pDomainInfo>();
            __Clusters = new SortedDictionary<string, pClusterInfo>();
            __Contexts = new SortedDictionary<string, pContextInfo>();
            __Entities = new SortedDictionary<string, pEntityInfo>();
            __Models = new SortedDictionary<string, pModelInfo>();
        }

        //
        // DOMAINS
        //

        public void Domain_Load(DataDomain domain)
        {
            if (null != domain)
            {
                if (domain.Name.isNotNullAndEmpty())
                {
                    if (VerifyParcel(domain.Name))
                    {
                        //
                        // Build the unique cluster identifier.
                        //

                        string domainID = domain.Name;

                        if (!__Domains.ContainsKey(domainID))
                        {
                            //
                            // Build the domain runtime object.
                            //

                            pDomainInfo domainInfo = new pDomainInfo()
                            {
                                ID = domainID,
                                Original = domain,
                                Clusters = new List<pClusterInfo>()
                            };

                            //
                            // PROCESS: Domain Clusters.
                            //

                            domain.Clusters.Apply(cluster =>
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

                                            string clusterID = BuildComplexIdentifier(domainID, cluster.Name);

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

                                                            string entityID = BuildComplexIdentifier(clusterID, entity.Name);

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

                                                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity definition in cluster '{0}' is not valid, either the name or type is not defined", clusterID);
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
                                                            string modelID = BuildComplexIdentifier(clusterID, model.Name);

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

                                                        Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "model definition in cluster '{0}' is not valid, either the name or type is not defined", clusterID);
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

                                                            string contextID = BuildComplexIdentifier(clusterID, context.Name);

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
                                                                    string entityID = BuildComplexIdentifier(clusterID, entityRef.Name);

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
                                                                    string modelID = BuildComplexIdentifier(clusterID, modelRef.Name);

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

                                                //
                                                // Add the cluster info to the domain runtime info.
                                                //

                                                domainInfo.Clusters.Add(clusterInfo);
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
                            });

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

        public DataDomain Domain_Get(params string[] parcels)
        {
            return __Domain_GetInfo(parcels).Original;
        }

        public IEnumerable<string> Domain_GetListOfID()
        {
            return __Domains.Keys;
        }

        public void Domain_Init(string domainID)
        {
            pDomainInfo domain = __Domain_GetInfo(domainID);

            domain.Clusters.Apply(cluster =>
            {
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

                            context.ProviderService = Scope.Hub.New<IProviderDataContext>(context.ProviderServiceEntry);

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
            });
        }

        private pDomainInfo __Domain_GetInfo(params string[] parcels)
        {
            pDomainInfo domainInfo = default(pDomainInfo);
            string domainID = BuildComplexIdentifier(parcels);

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

        //
        // CONTEXTS
        //

        private pContextInfo __Context_GetInfo(params string[] parcels)
        {
            pContextInfo contextInfo = default(pContextInfo);
            string contextID = BuildComplexIdentifier(parcels);

            if (__Contexts.ContainsKey(contextID))
            {
                contextInfo = __Contexts[contextID];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "context with identifier '{0}' does not exist!", contextID);
            }

            return contextInfo;
        }

        //
        // ENTITIES
        //

        public DataEntity Entity_Get(params string[] parcels)
        {
            return __Entity_GetInfo(parcels).Original;
        }

        public Type Entity_GetType(params string[] parcels)
        {
            return Type.GetType(Entity_Get(parcels).TypeName);
        }

        public IProviderDataContext Entity_GetProviderDataContext(params string[] parcels)
        {
            return __Entity_GetInfo(parcels).Context.ProviderService;
        }

        private pEntityInfo __Entity_GetInfo(params string[] parcels)
        {
            pEntityInfo entityInfo = default(pEntityInfo);
            string entityID = BuildComplexIdentifier(parcels);

            if (__Entities.ContainsKey(entityID))
            {
                entityInfo = __Entities[entityID];
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "entity with identifier '{0}' does not exist!", entityID);
            }

            return entityInfo;
        }

        //
        // DIAGNOSTICS
        //

        public IEnumerable<MemDomain> Mem_GetListOfDomains()
        {
            return __Domains.Keys.Map(new List<MemDomain>(), e => { return __Converter(__Domain_GetInfo(e)); });
        }

        public IEnumerable<MemContext> Mem_GetListOfContexts()
        {
            return __Contexts.Keys.Map(new List<MemContext>(), e => { return __Converter(__Context_GetInfo(e)); });
        }

        public IEnumerable<MemEntity> Mem_GetListOfEntities()
        {
            return __Entities.Keys.Map(new List<MemEntity>(), e => { return __Converter(__Entity_GetInfo(e)); });
        }

        private MemDomain __Converter(pDomainInfo info)
        {
            return new MemDomain()
            {
                ID = info.ID,
                Name = info.Original.Name
            };
        }

        private MemContext __Converter(pContextInfo info)
        {
            return new MemContext()
            {
                ID = info.ID,
                Name = info.Original.Name
            };
        }

        private MemEntity __Converter(pEntityInfo info)
        {
            return new MemEntity()
            {
                ID = info.ID,
                Name = info.Original.Name,
                TypeName = info.Original.TypeName
            };
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

        private IDictionary<string, pDomainInfo> __Domains = null;
        private IDictionary<string, pClusterInfo> __Clusters = null;
        private IDictionary<string, pContextInfo> __Contexts = null;
        private IDictionary<string, pEntityInfo> __Entities = null;
        private IDictionary<string, pModelInfo> __Models = null;

        //
        // PRIVATE-CLASSES ----------------------------------------------------
        // Used in memory related storage operations.
        //

        //
        // Class to map information about data domains
        // This is used to map unique data domains identifier
        // to their runtime information.
        //

        private class pDomainInfo
        {
            //
            // Complete identifier.
            //

            public string ID { get; set; }

            //
            // Original context specification.
            //

            public DataDomain Original { get; set; }

            //
            // List of data contexts.
            //

            public IList<pClusterInfo> Clusters { get; set; }

            //
            // CONSTRUCTOR
            //

            public pDomainInfo()
            {
                ID = null;
                Original = null;
                Clusters = null;
            }
        }

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
