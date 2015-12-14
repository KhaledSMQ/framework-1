// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================        

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IUrlResolverSet : IDictionary<string, IUrlResolver>
    {
        void Add(IUrlResolver resolver);
        string Resolve(string name, string url);
        string Resolve(string url);
    }
}
