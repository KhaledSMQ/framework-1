// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

namespace Framework.Blocks.Model.Schema
{
    //
    // Block: CALL
    // These types of blocks call a method in a service somewhere.
    // The block instantiates the service and calls the specified
    // method with the block input parameters.
    //

    public class FW_BlkBlockCall : FW_BlkABlock
    {
        //
        // Name and method of service to call.
        // Service should be defined in factory store.
        //

        public string Service { get; set; }

        public string Method { get; set; }

        //
        // CONSTRUCTORS 
        //

        public FW_BlkBlockCall() : base()
        {
            Service = default(string);
            Method = default(string);
        }
    }
}
