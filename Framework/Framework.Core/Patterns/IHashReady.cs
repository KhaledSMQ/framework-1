// ============================================================================
// Project: Framework
// Name/Class: IHashReady
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Pattern for classes that implement parse and unparse from Hash.
// ============================================================================                    

using System.Collections.Generic;

namespace Framework.Core.Patterns
{
    public interface IHashReady
    {
        void ParseFromHash(IDictionary<string, object> hash);

        IDictionary<string, object> UnparseToHash();
    }
}
