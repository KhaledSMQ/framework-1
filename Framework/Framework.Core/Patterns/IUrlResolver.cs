// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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
