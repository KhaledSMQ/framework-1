// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
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
using System.Linq;

namespace Framework.Blocks.API
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

            __Domains = new SortedDictionary<Id, MemCluster>();
            __Modules = new SortedDictionary<Id, MemModule>();
            __Blocks = new SortedDictionary<Id, MemBlockDef>();
        }

        //
        // STORE
        //

        public object Dump()
        {
            return new
            {
                Domains = Cluster_GetList(),
                Modules = Module_GetList(),
                Blocks = Block_GetList()
            };
        }

        public object Clear()
        {
            return Cluster_Clear();
        }

        //
        // DOMAINS
        //

        public Id Cluster_Import(FW_BlkClusterDef fwDomainDef)
        {
            Id domain_ID = default(Id);

            if (null != fwDomainDef)
            {
                domain_ID = new Id(fwDomainDef.Name);

                IList<Id> domain_Modules = fwDomainDef.Modules.Map(new List<Id>(), mod => { return Module_Import(domain_ID, mod); });

                MemCluster domain = new MemCluster()
                {
                    ID = domain_ID,
                    Modules = domain_Modules
                };

                __Add(__Domains, domain, "domain '{0}' already defined!");

            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid domain object to import");
            }

            return domain_ID;
        }

        public MemCluster Cluster_Get(Id id)
        {
            return __Get(__Domains, id, "domain '{0}' is not defined!");
        }

        public bool Cluster_Exists(Id id)
        {
            return __Exists(__Domains, id);
        }

        public IEnumerable<MemCluster> Cluster_GetList()
        {
            return __GetList(__Domains);
        }

        public void Cluster_Unload(MemCluster domain)
        {
            Cluster_Unload(domain.ID);
        }

        public void Cluster_Unload(string domainID)
        {
            Cluster_Unload(new Id(domainID));
        }

        public void Cluster_Unload(Id domainID)
        {
            MemCluster domain = Cluster_Get(domainID);
            domain.Modules.Apply(Module_Unload);
            __Delete(__Domains, domainID);
        }

        public int Cluster_Clear()
        {
            IEnumerable<MemCluster> listOfDomains = Cluster_GetList();
            int numOfDomains = listOfDomains.Count();
            listOfDomains.Apply(Cluster_Unload);
            return numOfDomains;
        }

        //
        // MODULES
        //

        public Id Module_Import(Id parentID, FW_BlkModuleDef fwModuleDef)
        {
            Id module_ID = default(Id);

            if (null != fwModuleDef)
            {
                module_ID = parentID + fwModuleDef.Name;                           

                IList<Id> module_Blocks = fwModuleDef.Blocks.Map(new List<Id>(), childFwBlockDef => { return Block_Import(module_ID, childFwBlockDef); });

                MemModule module = new MemModule()
                {
                    ID = module_ID,
                    Blocks = module_Blocks
                };

                __Add(__Modules, module, "module '{0}' already defined!");

                fwModuleDef.Modules.Apply(childFwModuleDef => Module_Import(module_ID, childFwModuleDef));
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid module object to import");
            }

            return module_ID;
        }

        public MemModule Module_Get(Id id)
        {
            return __Get(__Modules, id, "module '{0}' is not defined!");
        }

        public bool Module_Exists(Id id)
        {
            return __Exists(__Modules, id);
        }

        public IEnumerable<MemModule> Module_GetList()
        {
            return __GetList(__Modules);
        }

        public void Module_Unload(MemModule module)
        {
            Module_Unload(module.ID);
        }

        public void Module_Unload(Id moduleID)
        {
            MemModule module = Module_Get(moduleID);
            module.Blocks.Apply(Block_Unload);
            __Delete(__Modules, moduleID);
        }

        //
        // BLOCK
        //

        public Id Block_Import(Id moduleID, FW_BlkBlockDef fwBlockDef)
        {
            Id defBlock_ID = default(Id);

            if (null != fwBlockDef)
            {
                //
                // Process: ID
                //

                defBlock_ID = moduleID + fwBlockDef.Name;

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
                        // Put together the port definition and add 
                        // it to current block definition.
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

                IDictionary<Id, MemBlockUse> defBlock_Blocks = null;

                if (fwBlockDef.Blocks.NotEmpty())
                {
                    defBlock_Blocks = new SortedDictionary<Id, MemBlockUse>();

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
                                refBlock_Properties.Add(new Id(property.Name), property.Value);
                            });
                        }

                        //
                        // Put together the complete block 
                        // reference and add it to main block
                        // definition.
                        //

                        MemBlockUse refBlock = new MemBlockUse()
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

                IDictionary<Id, IDictionary<Id, MemConnector>> defBlock_Connections = null;

                if (fwBlockDef.Connections.NotEmpty())
                {
                    int idxGeneratedConnName = 0;

                    defBlock_Connections = new SortedDictionary<Id, IDictionary<Id, MemConnector>>();

                    fwBlockDef.Connections.Apply(conn =>
                    {
                        //
                        // Process: NAME
                        //

                        Id conn_Name = new Id(conn.Name.isNotNullAndEmpty() ? conn.Name : "__C" + idxGeneratedConnName++);

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
                            Name = conn_Name
                        };

                        //
                        // Add connection object to set of connections
                        // of the block definition.
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
                    Flow = defBlock_Connections
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

        public bool Block_Exists(Id id)
        {
            return __Exists(__Blocks, id);
        }

        public IEnumerable<MemBlockDef> Block_GetList()
        {
            return __GetList(__Blocks);
        }

        public void Block_Unload(MemBlockDef block)
        {
            Block_Unload(block.ID);
        }

        public void Block_Unload(Id blockID)
        {
            __Delete(__Blocks, blockID);
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

        private bool __Exists<T>(IDictionary<Id, T> repo, Id id)
        {
            return repo.ContainsKey(id);
        }

        private IEnumerable<T> __GetList<T>(IDictionary<Id, T> repo)
        {
            return repo.Values.ToList();
        }

        private void __Delete<T>(IDictionary<Id, T> repo, Id id)
        {
            if (repo.ContainsKey(id))
            {
                repo.Remove(id);
            }
        }

        //
        // Memory storage.
        //

        private IDictionary<Id, MemCluster> __Domains = null;
        private IDictionary<Id, MemModule> __Modules = null;
        private IDictionary<Id, MemBlockDef> __Blocks = null;
    }
}
