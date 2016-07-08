// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Storage.Model.Config;

namespace Framework.Storage.API
{
    public class SrvModule : Factory.API.SrvModuleProtocol<LibConfiguration>, Factory.API.IModuleProtocol
    {
        //
        // CONSTRUCTOR
        //    

        public SrvModule() : base(Constants.SECTION, System.Reflection.Assembly.GetExecutingAssembly()) { }
    }
}
