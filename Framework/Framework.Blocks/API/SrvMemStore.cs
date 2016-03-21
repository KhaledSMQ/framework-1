// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Blocks.Model.Mem;
using Framework.Core.Error;
using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Data.Model.Mem;
using Framework.Data.Model.Schema;
using Framework.Data.Patterns;
using Framework.Factory.Model;
using Framework.Factory.Patterns;
using System;
using System.Collections.Generic;
using Framework.Blocks.Model.Schema;
using Framework.Core.Patterns;

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
            __Flows = new SortedDictionary<Id, MemFlow>();
            __Blocks = new SortedDictionary<Id, MemBlock>();
        }

        //
        // DOMAINS
        //

        public void Domain_Import(BlkDomain import)
        {
            if (null != import)
            {
                Id id = new Id(import.Name);

                MemDomain memDomain = new MemDomain() { ID = id };

                __Add(__Domains, memDomain, "domain '{0}' already defined!");

                import.Modules.Apply(mod => Module_Import(id, mod));
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid domain object to import");
            }
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

        public Id Module_Import(Id parentID, BlkModule import)
        {
            Id id = default(Id);

            if (null != import)
            {
                id = parentID + import.Name;

                MemModule memModule = new MemModule() { ID = id };

                __Add(__Modules, memModule, "module '{0}' already defined!");

                import.Modules.Apply(mod => Module_Import(id, mod));
                import.Flows.Apply(flow => Flow_Import(id, flow));
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
        // FLOWS
        //

        public Id Flow_Import(Id parentID, BlkFlow import)
        {
            Id id = default(Id);

            if (null != import)
            {
                id = parentID + import.Name;

                MemFlow memFlow = new MemFlow() { ID = id };

                __Add(__Flows, memFlow, "flow '{0}' already defined!");
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid module object to import");
            }

            return id;
        }

        public MemFlow Flow_Get(Id id)
        {
            return __Get(__Flows, id, "flow '{0}' is not defined!");
        }

        public IEnumerable<MemFlow> Flow_GetList()
        {
            return __GetList(__Flows);
        }

        //
        // BLOCKS
        //

        public Id Block_Import(Id parentID, BlkBlock import)
        {
            Id id = default(Id);

            if (null != import)
            {
                id = parentID + import.Name;

                MemBlock memBlock = new MemBlock() { ID = id };

                __Add(__Blocks, memBlock, "block '{0}' already defined!");
            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "invalid module object to import");
            }

            return id;
        }

        public MemBlock Block_Get(Id id)
        {
            return __Get(__Blocks, id, "block '{0}' is not defined!");
        }

        public IEnumerable<MemBlock> Block_GetList()
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
        private IDictionary<Id, MemFlow> __Flows = null;
        private IDictionary<Id, MemBlock> __Blocks = null;
    }
}
