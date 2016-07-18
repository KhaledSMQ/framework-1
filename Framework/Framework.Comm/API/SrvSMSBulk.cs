// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 05/Apr/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Comm.API
{
    public class SrvSMSBulk : ACommon, ISMS
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
