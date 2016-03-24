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
using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using Framework.Core.Extensions;
using System.Collections.Generic;

namespace Framework.Blocks.API
{
    public class SrvEval : ACommon, IEval
    {
        //
        // Service dependencies.
        //

        protected IStore srvStore { get; set; }

        //
        // Service initialization. 
        // Boot the dependant services.
        //

        public override void Init()
        {
            //
            // Initialize base service infrastructure.
            //

            base.Init();

            //
            // Initialize dependent services.
            // NOTE: We do this here because all these services
            // do not have dependencies that are circular to this service.
            //

            srvStore = Scope.Hub.GetUnique<IStore>();
        }

        //
        // EVALUATE
        // Evaluate a block based on its unique id.
        //

        public object Eval(string blockID, object args)
        {
            return Eval(Id.FromString(blockID), args);
        }

        public object Eval(Id blockID, object args)
        {
            //
            // Default result for blobk execution.
            // Just return the default value for object type.
            //

            object output = default(object);

            //
            // First things first.. we need to get the
            // block definition, and at the same time
            // we check if the block really exists...
            //

            object blockDef = srvStore.Block_Get(blockID);

            if (null != blockDef)
            {

            }
            else
            {
                Throw.Fatal(Lib.DEFAULT_ERROR_MSG_PREFIX, "block '{0}' is not defined or simply cannot be found!", blockID);
            }

            //
            // Return the computed value to caller.
            //

            return output;
        }

        public object Eval_StageEvalBlock(string blockID, object args)
        {
            return Eval_StageEvalBlock(Id.FromString(blockID), args);
        }

        public object Eval_StageEvalBlock(Id blockID, object args)
        {
            return __TransformMemBlockDef2EvalBlock((MemBlockDef)srvStore.Block_Get(blockID));
        }

        //
        // STAGE: Transform a block definition from memory into an evaluable
        // block. All blocks here are block instances, we instantiate the main
        // and the used block references inside a given block.
        //

        private Model.Eval.Block __TransformMemBlockDef2EvalBlock(MemBlockDef memBlock)
        {
            //
            // PROPERTIES
            // 

            IDictionary<Id, Model.Eval.Property> properties = null;

            if (memBlock.Properties.NotEmpty())
            {

            }

            //
            // PORTS
            //

            IDictionary<Id, Model.Eval.Port> ports = null;

            if (memBlock.Ports.NotEmpty())
            {
                ports = new SortedDictionary<Id, Model.Eval.Port>();

                memBlock.Ports.Apply(portPair =>
                {
                    Id memPort_ID = portPair.Key;
                    MemPort memPort = portPair.Value;

                    Model.Eval.Port port = new Model.Eval.Port()
                    {
                        Kind = memPort.Kind,
                        Type = memPort.Type,
                        Required = memPort.Required
                    };

                    ports.Add(memPort_ID, port);
                });
            }

            //
            // BLOCKS
            //

            IDictionary<Id, Model.Eval.Ref> blocks = null;

            if (memBlock.Blocks.NotEmpty())
            {
                blocks = new SortedDictionary<Id, Model.Eval.Ref>();

                memBlock.Blocks.Apply(blockUsePair =>
                {
                    MemBlockUse blockUse = blockUsePair.Value;

                    //
                    // Get the block definition, will use this to 
                    // extract the port and property definitions.
                    //

                    MemBlockDef blockDef = __GetMemBlockDef(blockUse.Def);

                    //
                    // Import the port definitions from the block definition
                    // to this block instance.
                    //

                    blockDef.Ports.Apply(portPair =>
                    {
                        Id memPort_ID = blockUsePair.Key + portPair.Key;
                        MemPort memPort = portPair.Value;

                        Model.Eval.Port port = new Model.Eval.Port()
                        {
                            Kind = memPort.Kind,
                            Type = memPort.Type,
                            Required = memPort.Required
                        };

                        ports.Add(memPort_ID, port);
                    });

                    
                    blocks.Add(blockUsePair.Key, new Model.Eval.Ref() { Def = blockUse.Def, Properties = null });
                });
            }

            //
            // FLOW
            //

            IDictionary<Id, IDictionary<Id, Model.Eval.Connector>> flow = null;

            if (memBlock.Flow.NotEmpty())
            {
                flow = new SortedDictionary<Id, IDictionary<Id, Model.Eval.Connector>>();

                memBlock.Flow.Apply(sourcePair => 
                {
                    Id source_ID = sourcePair.Key;

                    flow[source_ID] = new SortedDictionary<Id, Model.Eval.Connector>();

                    sourcePair.Value.Apply(targetPair =>
                    {
                        Id target_ID = targetPair.Key;

                        Model.Eval.Connector conn = new Model.Eval.Connector()
                        {
                            Name = targetPair.Value.Name
                        };

                        flow[source_ID][target_ID] = conn;
                    });
                });
            }

            //
            // Assemble the complete eval block
            // using the computed parts.
            //

            return new Model.Eval.Block()
            {
                ID = memBlock.ID,
                Type = memBlock.Type,
                Properties = properties,
                Ports = ports,
                Blocks = blocks,
                Flow = flow
            };
        }

        //
        //
        //

        private MemBlockDef __GetMemBlockDef(Id blockID)
        {
            return (MemBlockDef) srvStore.Block_Get(blockID);
        }
    }
}
