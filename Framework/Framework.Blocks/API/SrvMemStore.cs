// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Mem;
using Framework.Blocks.Model.Schema;
using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using System.Collections.Generic;

namespace Framework.Blocks.API
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

            __Domains = new SortedDictionary<Id, MemDomain>();
            __Modules = new SortedDictionary<Id, MemModule>();
            __Blocks = new SortedDictionary<Id, MemBlockTemplate>();
        }

        //
        // DOMAINS
        //

        public Id Domain_Import(FW_BlkDomainDef import)
        {
            Id id = default(Id);

            if (null != import)
            {
                id = new Id(import.Name);

                MemDomain memDomain = new MemDomain() { ID = id };

                __Add(__Domains, memDomain, "domain '{0}' already defined!");

                import.Modules.Apply(mod => Module_Import(id, mod));
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid domain object to import");
            }

            return id;
        }

        public MemDomain Domain_Get(Id id)
        {
            return __Get(__Domains, id, "domain '{0}' is not defined!");
        }

        public IEnumerable<MemDomain> Domain_GetList()
        {
            return __GetList(__Domains);
        }

        //
        // MODULES
        //

        public Id Module_Import(Id parentID, FW_BlkModuleDef import)
        {
            Id id = default(Id);

            if (null != import)
            {
                id = parentID + import.Name;

                MemModule memModule = new MemModule() { ID = id };

                __Add(__Modules, memModule, "module '{0}' already defined!");

                import.Modules.Apply(mod => Module_Import(id, mod));

                import.Blocks.Apply(block => Block_Import(id, block));
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid module object to import");
            }

            return id;
        }

        public MemModule Module_Get(Id id)
        {
            return __Get(__Modules, id, "module '{0}' is not defined!");
        }

        public IEnumerable<MemModule> Module_GetList()
        {
            return __GetList(__Modules);
        }

        //
        // BLOCK
        //

        public Id Block_Import(Id parentID, FW_BlkBlockDef import)
        {
            Id memBlockTemplateID = default(Id);

            if (null != import)
            {
                memBlockTemplateID = parentID + import.Name;

                MemBlockTemplate memBlockTemplate = new MemBlockTemplate()
                {
                    ID = memBlockTemplateID,
                    Description = import.Description,
                    TypeName = import.TypeName
                };

                __Add(__Blocks, memBlockTemplate, "block '{0}' already defined!");

                //
                // PORTS
                //

                if (import.Ports.NotEmpty())
                {
                    memBlockTemplate.Ports = new SortedDictionary<Id, MemPort>();

                    import.Ports.Apply(port =>
                    {
                        Id memPortID = new Id(port.Name);

                        MemPort memPort = new MemPort()
                        {
                            ID = memPortID,
                            Type = port.Type,
                            Required = port.Required
                        };

                        memBlockTemplate.Ports.Add(memPortID, memPort);
                    });
                }

                //
                // PROPERTIES
                //

                if (import.Properties.NotEmpty())
                {
                    memBlockTemplate.Properties = new SortedDictionary<Id, MemProperty>();

                    import.Properties.Apply(property =>
                    {
                        Id memPropertyID = new Id(property.Name);

                        MemProperty memProperty = new MemProperty()
                        {
                            ID = memPropertyID,
                            Description = property.Description,
                            Type = property.Type
                        };

                        __Add(memBlockTemplate.Properties, memProperty, "property '{0}' already defined!");
                    });
                }

                //
                // GRAPH: NODES/BLOCKS
                //

                if (import.BlockRefs.NotEmpty())
                {
                    memBlockTemplate.Blocks = new SortedDictionary<Id, MemBlock>();

                    import.BlockRefs.Apply(blockRef =>
                    {
                        Id memBlockRefID = new Id(blockRef.Name);
                        Id memBlockRefDefID = new Id(blockRef.Def);

                        MemBlock memBlock = new MemBlock()
                        {
                            ID = memBlockRefID,
                            Def = memBlockRefDefID
                        };

                        //
                        // PORTS
                        //

                        if (blockRef.Ports.NotEmpty())
                        {
                            memBlock.Ports = new SortedDictionary<Id, MemPort>();

                            blockRef.Ports.Apply(port => 
                            {
                                Id memPortID = memBlockRefID + port.Name;

                                MemPort memPort = new MemPort()
                                {
                                    ID = memPortID,
                                    Type = port.Type,
                                    Required = port.Required
                                };

                                memBlock.Ports.Add(memPortID, memPort);
                            });
                        }

                        //
                        // PROPERTIES
                        //

                        if (blockRef.Properties.NotEmpty())
                        {
                            memBlock.Properties = new SortedDictionary<Id, string>();

                            blockRef.Properties.Apply(property =>
                            {
                                Id propertyValueID = memBlockRefID + property.Name;
                                memBlock.Properties.Add(propertyValueID, property.Value);
                            });
                        }

                        __Add(memBlockTemplate.Blocks, memBlock, "block reference already defined '{0}'");
                    });
                }

                //
                // GRAPH: EDGES/CONNECTIONS/FLOW
                //

                if (import.Connections.NotEmpty())
                {
                    int indexConn = 0;

                    memBlockTemplate.Connections = new SortedDictionary<Id, IList<MemConnector>>();

                    import.Connections.Apply(conn =>
                    {
                        //
                        // Process: NAME
                        //

                        string connName = conn.Name.isNotNullAndEmpty() ? conn.Name : "__C" + ++indexConn;

                        //
                        // Process: SOURCE
                        //

                        Id sourcePortID = new Id(conn.Source.BlockRef, conn.Source.Name);

                        //
                        // Process: TARGET
                        //

                        Id targetPortID = new Id(conn.Target.BlockRef, conn.Target.Name);

                        //
                        // Build connection object.
                        //                        

                        MemConnector memConnector = new MemConnector()
                        {
                            Name = new Id(connName),
                            Target = targetPortID
                        };

                        //
                        // Add connection obejct to block connection set.
                        //

                        if (!memBlockTemplate.Connections.ContainsKey(sourcePortID))
                        {
                            memBlockTemplate.Connections.Add(sourcePortID, new List<MemConnector>());
                        }

                        memBlockTemplate.Connections[sourcePortID].Add(memConnector);
                    });
                }
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid block object to import");
            }

            return memBlockTemplateID;
        }

        public MemBlockTemplate Block_Get(Id id)
        {
            return __Get(__Blocks, id, "block '{0}' is not defined!");
        }

        public IEnumerable<MemBlockTemplate> Block_GetList()
        {
            return __GetList(__Blocks);
        }

        //
        // HELPERS
        //

        private void __Add<T>(IDictionary<Id, T> repo, T value, string errMsg) where T : IID<Id>
        {
            if (!repo.ContainsKey(value.ID))
            {
                repo.Add(value.ID, value);
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, errMsg, value.ID.ToString());
            }
        }

        private T __Get<T>(IDictionary<Id, T> repo, Id id, string errMsg)
        {
            T val = repo[id];

            if (null == val)
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, errMsg, id.ToString());
            }

            return val;
        }

        private IEnumerable<T> __GetList<T>(IDictionary<Id, T> repo)
        {
            return repo.Values;
        }

        //
        // Memory storage.
        //

        private IDictionary<Id, MemDomain> __Domains = null;
        private IDictionary<Id, MemModule> __Modules = null;
        private IDictionary<Id, MemBlockTemplate> __Blocks = null;
    }
}
