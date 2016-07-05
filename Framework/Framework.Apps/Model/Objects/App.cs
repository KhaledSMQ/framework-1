// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 04/Oct/2015
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using System.Collections.Generic;
using Framework.Core.Patterns;

namespace Framework.Apps.Model.Objects
{
    public class App :
        IID<int>,
        IVisible,
        ICreated<string>,
        IModified<string>,
        IRef<string>,
        IName<string>,
        IDescription<string>
    {
        //
        // PROPERTIES
        //

        public int ID { get; set; }
        public TypeOfVisibility Visibility { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string Ref { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       

        //
        // CONSTRUCTORS
        //

        public App()
        {
            //
            // Base
            //

            ID = -1;
            Visibility = TypeOfVisibility.ACTIVE;

            DateTime dateNow = DateTime.Now;
            CreatedDate = new DateTime(dateNow.Ticks);
            ModifiedDate = new DateTime(dateNow.Ticks);
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;

            //
            // Info.
            //

            Ref = string.Empty;
            Name = string.Empty;
            Description = string.Empty;         
        }
    }
}
