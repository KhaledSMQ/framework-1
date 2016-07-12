﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System;
using Framework.Core.Patterns;
using Framework.Core.Extensions;
using Framework.Server.Model.Objects;
using Framework.Client.Model.Objects;
using System.Collections.Generic;
using Framework.Data.Patterns;

namespace Framework.Apps.Model.Objects
{
    public class App : ABaseEntityWithID<int, string>,
        IOwner<int>,
        IRef<string>
    {
        //
        // PROPERTIES
        //

        public int Owner { get; set; }

        //
        // REF/NAME/DESCRIPTION
        //

        public string Ref { get; set; }


        public Meta Meta { get; set; }

        //
        //   
        //

        public ICollection<Backend> Servers { get; set; }

        public ICollection<Frontend> Clients { get; set; }

        //
        // CONSTRUCTORS
        //

        public App() 
        {
            //
            // Base
            //

            Owner = default(int);

            //
            // Ref/Name/Description
            //

            Ref = default(string);
            Meta = default(Meta);
        }
    }
}
