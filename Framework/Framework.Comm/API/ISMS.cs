// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 18/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Api;

namespace Framework.Comm.Api
{
    public interface ISms : ICommon
    {
        //
        // Send a SMS message to a mobile number.
        //

        void Send(string number, string message);
    }
}
