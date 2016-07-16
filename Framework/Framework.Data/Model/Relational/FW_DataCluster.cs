// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FW_DataCluster : ABaseClassWithID<int, string>, IOwner<int>
    {
        //
        // Info
        //

        public int Owner { get; set; }

        public string Name { get; set; }

        public ICollection<FW_DataContext> Contexts { get; set; }

        public ICollection<FW_DataSetting> Settings { get; set; }     

        //
        // CONSTRUCTORS
        // 

        public FW_DataCluster()
        { 
            Owner = default(int);
            Name = default(string);
            Contexts = null;
            Settings = null;     
        }
    }
}
