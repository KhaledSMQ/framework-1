// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 03/Aug/2015
// Company: Cybermap Lta.
// Description: Service specification class.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Model.Schema
{
    public class DataQueryParam :
        IID<int>,
        IName<string>,
        IDescription<string>
    {
        //
        // INFO
        //

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        //
        // CONSTRUCTORS
        // 

        public DataQueryParam()
        {
            //
            // INFO
            //

            ID = -1;
            Name = string.Empty;
            Description = string.Empty;
            Type = string.Empty;          
        }
    }
}
