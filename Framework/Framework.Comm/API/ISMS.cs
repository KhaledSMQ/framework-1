// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 18/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.API;

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
