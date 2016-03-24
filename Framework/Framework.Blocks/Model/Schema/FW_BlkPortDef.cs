// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 20/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Blocks.Model.Schema
{
    public class FW_BlkPortDef : IID<int>
    {
        //
        // Numeric identifier for parameter/property.
        //

        public int ID { get; set; }

        //
        // Name for port.
        // 

        public string Name { get; set; }

        //
        // Kind of port. Ports can be of type IN or OUT.
        //

        public TypeOfPort Kind { get; set; }

        //
        // Type for port.
        //

        public string TypeName { get; set; }

        //
        // States if port value is required or not.
        //

        public bool Required { get; set; }

        //
        // CONSTRUCTORS
        //

        public FW_BlkPortDef()
        {
            ID = default(int);
            Name = default(string);
            Kind = TypeOfPort.UNKNOWN;
            TypeName = default(string);       
            Required = default(bool);   
        }
    }
}
