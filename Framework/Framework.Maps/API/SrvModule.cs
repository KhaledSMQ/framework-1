// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Maps.Model.Config;

namespace Framework.Maps.API
{
    public class SrvModule : Factory.API.SrvModule<LibConfiguration>, Factory.API.IModule
    {
        //
        // CONSTRUCTOR
        //    

        public SrvModule() : base(Constants.SECTION) { }
    }
}
