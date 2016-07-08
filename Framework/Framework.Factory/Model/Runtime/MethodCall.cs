// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Factory.Model.Runtime
{
    public class MethodCall
    {
        //
        // PROPERTIES
        //

        public string Service { get; set; }

        public string Method { get; set; }

        //
        // CONSTRUCTOR
        // 

        public MethodCall()
        {
            Service = string.Empty;
            Method = string.Empty; 
        }
    }
}
