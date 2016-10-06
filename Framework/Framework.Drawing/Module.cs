// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 06/July/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Drawing
{
    public class Module : Core.Patterns.AModule<Core.Config.ModuleConfiguration>, Core.Patterns.IModule
    {
        public Module() : base(Lib.DEFAULT_CONFIG_SECTION_NAME, System.Reflection.Assembly.GetExecutingAssembly()) { }
    }
}
