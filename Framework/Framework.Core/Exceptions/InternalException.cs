// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 13/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================                    

namespace Framework.Core.Exceptions
{
    public class InternalException : System.Exception
    {
        public InternalException() { }
        public InternalException(string message) : base(message) { }
        public InternalException(string message, System.Exception inner) : base(message, inner) { }
    }
}
