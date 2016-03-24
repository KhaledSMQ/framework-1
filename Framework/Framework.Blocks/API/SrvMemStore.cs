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
using System;
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
            __Blocks = new SortedDictionary<Id, MemBlockDef>();
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

        public Id Block_Import(Id parentID, FW_BlkBlockDef fwBlockDef)
        {
            Id defBlock_ID = default(Id);

            if (null != fwBlockDef)
            {
                //
                // Process: ID
                //

                defBlock_ID = parentID + fwBlockDef.Name;

                //
                // Process: TYPE
                //

                Type defBlock_Type = fwBlockDef.TypeName.isNotNullAndEmpty() ? Type.GetType(fwBlockDef.TypeName) : default(Type);

                //
                // Process: PORTS
                //

                IDictionary<Id, MemPort> defBlock_Ports = null;

                if (fwBlockDef.Ports.NotEmpty())
                {
                    defBlock_Ports = new SortedDictionary<Id, MemPort>();

                    fwBlockDef.Ports.Apply(port =>
                    {
                        //
                        // Process: ID
                        //

                        Id memPort_ID = new Id(port.Name);

                        //
                        // Process: TYPE
                        //

                        Type memPort_Type = port.TypeName.isNotNullAndEmpty() ? Type.GetType(port.TypeName) : default(Type);

                        //
                        // Put together the port definition
                        // and add it to current block 
                        // definition.
                        //

                        MemPort memPort = new MemPort()
                        {
                            Kind = port.Kind,
                            Type = memPort_Type,
                            Required = port.Required
                        };

                        defBlock_Ports.Add(memPort_ID, memPort);
                    });
                }

                //
                // Process: PROPERTIES
                //

                IDictionary<Id, MemProperty> defBlock_Properties = null;

                if (fwBlockDef.Properties.NotEmpty())
                {
                    defBlock_Properties = new SortedDictionary<Id, MemProperty>();

                    fwBlockDef.Properties.Apply(property =>
                    {
                        //
                        // Process: ID
                        //

                        Id defProperty_ID = new Id(property.Name);

                        //
                        // Process: TYPE
                        //

                        Type defProperty_Type = property.TypeName.isNotNullAndEmpty() ? Type.GetType(property.TypeName) : default(Type);

                        //
                        // Put together the property definition
                        // and add to block definition set of
                        // properties.
                        //

                        MemProperty defProperty = new MemProperty()
                        {
                            ID = defProperty_ID,
                            Type = defProperty_Type
                        };

                        defBlock_Properties.Add(defProperty_ID, defProperty);
                    });
                }

                //
                // Process: BLOCKS
                //

                IDictionary<Id, MemBlockRef> defBlock_Blocks = new SortedDictionary<Id, MemBlockRef>();

                if (fwBlockDef.Blocks.NotEmpty())
                {
                    defBlock_Blocks = new SortedDictionary<Id, MemBlockRef>();

                    fwBlockDef.Blocks.Apply(block =>
                    {
                        //
                        // Process: ID
                        //

                        Id refBlock_ID = new Id(block.Name);

                        //
                        // Process: DEF
                        //

                        Id refBlock_Def = new Id(block.Def);

                        //
                        // Process: PROPERTIES
                        //

                        IDictionary<Id, object> refBlock_Properties = null;

                        if (block.Properties.NotEmpty())
                        {
                            refBlock_Properties = new SortedDictionary<Id, object>();

                            block.Properties.Apply(property =>
                            {
                                Id propertyValueID = refBlock_ID + property.Name;
                                refBlock_Properties.Add(propertyValueID, property.Value);
                            });
                        }

                        //
                        // Put together the complete block 
                        // reference and add it to main block
                        // definition.
                        //

                        MemBlockRef refBlock = new MemBlockRef()
                        {
                            Def = refBlock_Def,
                            Properties = refBlock_Properties
                        };

                        defBlock_Blocks.Add(refBlock_ID, refBlock);
                    });
                }

                //
                // Process: CONNECTIONS
                //

                IDictionary<Id, IDictionary<Id, MemConnector>> defBlock_Connections = new SortedDictionary<Id, IDictionary<Id, MemConnector>>();

                if (fwBlockDef.Connections.NotEmpty())
                {
                    int indexConn = 0;

                    defBlock_Connections = new SortedDictionary<Id, IDictionary<Id, MemConnector>>();

                    fwBlockDef.Connections.Apply(conn =>
                    {
                        //
                        // Process: NAME
                        //

                        string conn_Name = conn.Name.isNotNullAndEmpty() ? conn.Name : "__C" + indexConn++;

                        //
                        // Process: SOURCE
                        //

                        Id conn_Source = new Id(conn.Source.Block, conn.Source.Name);

                        //
                        // Process: TARGET
                        //

                        Id conn_Target = new Id(conn.Target.Block, conn.Target.Name);

                        //
                        // Build connection object.
                        //                        

                        MemConnector memConnector = new MemConnector()
                        {
                            Name = new Id(conn_Name)
                        };

                        //
                        // Add connection obejct to block connection set.
                        //

                        if (!defBlock_Connections.ContainsKey(conn_Source))
                        {
                            defBlock_Connections.Add(conn_Source, new SortedDictionary<Id, MemConnector>());
                        }

                        defBlock_Connections[conn_Source][conn_Target] = memConnector;
                    });
                }

                //
                // Put together the complete block definition.
                // 

                MemBlockDef defBlock = new MemBlockDef()
                {
                    ID = defBlock_ID,
                    Type = defBlock_Type,
                    Properties = defBlock_Properties,
                    Ports = defBlock_Ports,
                    Blocks = defBlock_Blocks,
                    Connections = defBlock_Connections
                };

                //
                // Add it to memory store.
                //

                __Add(__Blocks, defBlock, "block '{0}' already defined!");

            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid block object to import");
            }

            return defBlock_ID;
        }

        public MemBlockDef Block_Get(Id id)
        {
            return __Get(__Blocks, id, "block '{0}' is not defined!");
        }

        public IEnumerable<MemBlockDef> Block_GetList()
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
        private IDictionary<Id, MemBlockDef> __Blocks = null;
    }
}
