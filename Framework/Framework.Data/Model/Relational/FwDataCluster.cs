// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Model.Relational
{
    public class FwDataCluster : ABaseClassWithID<int, string>, IOwner<int>
    {
        //
        // Info
        //

        public int Owner { get; set; }

        public string Name { get; set; }

        public ICollection<FwDataContext> Contexts { get; set; }

        public ICollection<FwDataSetting> Settings { get; set; }     

        //
        // CONSTRUCTORS
        // 

        public FwDataCluster()
        { 
            Owner = default(int);
            Name = default(string);
            Contexts = null;
            Settings = null;     
        }
    }
}
