// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.App.Model.Relational
{
    public class App : ABaseClassWithID<string, string>, IOwner<string>
    {
        //
        // PROPERTIES
        //

        public string Owner { get; set; }

        public Meta Meta { get; set; }

        public ICollection<Server.Model.Relational.FwServServer> Servers { get; set; }

        public ICollection<Client.Model.Relational.Client> Clients { get; set; }

        //
        // CONSTRUCTORS
        //

        public App() 
        {
            Owner = default(string);
            Meta = default(Meta);
            Servers = default(ICollection<Server.Model.Relational.FwServServer>);
            Clients = default(ICollection<Client.Model.Relational.Client>);
        }
    }
}
