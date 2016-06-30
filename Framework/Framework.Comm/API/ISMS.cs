// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 18/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Comm.API
{
    public interface ISMS : ICommon
    {
        //
        // Send a SMS message to a mobile number.
        //

        void Send(string number, string message);
    }
}
