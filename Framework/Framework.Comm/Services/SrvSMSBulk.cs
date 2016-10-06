// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 05/Apr/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Comm.Api;
using Framework.Core.Patterns;

namespace Framework.Comm.Services
{
    public class SrvSmsBulk : ACommon, ISms
    {
        //
        // Send a SMS message to a mobile number.
        // www.smsbulk.pt
        //

        public void Send(string number, string message)
        {
            throw new System.NotSupportedException();
        }
    }
}
