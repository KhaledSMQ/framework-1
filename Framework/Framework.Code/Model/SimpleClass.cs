// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 20/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using System.Collections.Generic;

namespace Framework.Code.Model
{
    public class SimpleClass
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public string Base { get; set; }

        public IList<string> Interfaces { get; set; }

        public IList<Property> Properties { get; set; }
    }
}
