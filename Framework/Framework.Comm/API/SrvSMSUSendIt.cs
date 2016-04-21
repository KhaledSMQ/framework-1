﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 05/Apr/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Factory.Patterns;

namespace Framework.Comm.API
{
    public class SrvSMSUSendIt : ACommon, ISMS
    {
        //
        // Send a SMS message to a mobile number.
        // usendit.pt
        //

        public void Send(string number, string message)
        {
        }
    }
}