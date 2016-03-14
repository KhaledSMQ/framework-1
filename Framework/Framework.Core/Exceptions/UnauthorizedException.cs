// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 13/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================                    

namespace Framework.Core.Exceptions
{
    public class UnauthorizedException : System.Exception
    {
        public UnauthorizedException() { }
        public UnauthorizedException(string message) : base(message) { }
        public UnauthorizedException(string message, System.Exception inner) : base(message, inner) { }
    }
}
