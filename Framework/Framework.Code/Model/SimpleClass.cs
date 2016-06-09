// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using System.Collections.Generic;

namespace Framework.Code.Model
{
    public class SimpleClass
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public Type Base { get; set; }

        public IList<Type> Interfaces { get; set; }

        public IList<Property> Properties { get; set; }
    }
}
