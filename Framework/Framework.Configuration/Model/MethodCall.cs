// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

namespace Framework.Configuration.Model
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
