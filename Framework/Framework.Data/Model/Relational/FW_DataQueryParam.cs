// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 03/Aug/2015
// Company: Coop4Creativity
// Description: Service specification class.
// ============================================================================

using Framework.Core.Patterns;

namespace Framework.Data.Model.Relational
{
    public class FW_DataQueryParam :
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

        public string TypeName { get; set; }

        public bool Required { get; set; }

        public string Default { get; set; }

        //
        // CONSTRUCTORS
        // 

        public FW_DataQueryParam()
        {
            //
            // INFO
            //

            ID = -1;
            Name = default(string);
            Description = default(string);
            TypeName = default(string);
            Required = false;
            Default = default(string);        
        }
    }
}
