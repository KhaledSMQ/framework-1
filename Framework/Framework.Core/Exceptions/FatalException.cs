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
    public class FatalException : System.Exception
    {
        public FatalException() { }
        public FatalException(string message) : base(message) { }
        public FatalException(string message, System.Exception inner) : base(message, inner) { }
    }
}
