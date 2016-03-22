﻿// ============================================================================
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
    // Block: NATIVE
    // These types of blocks execute a static function found
    // somewhere in the server referenced assemblies.
    //

    public class FW_BlkBlockNative : FW_BlkABlock
    {
        //
        // Method to call, full location: assembly, namespace and name.
        //

        public string Method { get; set; }

        //
        // CONSTRUCTORS 
        //

        public FW_BlkBlockNative() : base()
        {
            Method = default(string);
        }
    }
}
