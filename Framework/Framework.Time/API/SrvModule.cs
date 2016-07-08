// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Time.Model.Config;

namespace Framework.Time.API
{
    public class SrvModule : Factory.API.SrvModule<LibConfiguration>, Factory.API.IModule
    {
        //
        // CONSTRUCTOR
        //    

        public SrvModule() : base(Constants.SECTION) { }
    }
}
