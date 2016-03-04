// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 4/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

namespace Framework.Factory.API.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ServicePropertyAttribute : System.Attribute
    {
        public string Name;
    }
}
