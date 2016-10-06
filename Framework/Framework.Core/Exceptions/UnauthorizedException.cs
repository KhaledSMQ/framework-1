// ============================================================================
// Project: Framework
// Name/Class: UnauthorizedException
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 13/Mar/2016
// Company: Coop4Creativity
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
