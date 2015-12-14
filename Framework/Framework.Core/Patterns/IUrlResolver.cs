// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================        

using System;

namespace Framework.Core.Patterns
{
    public interface IUrlResolver
    {
        string BaseUrl { get; set; }

        string Resolve(string uri);
    }
}
