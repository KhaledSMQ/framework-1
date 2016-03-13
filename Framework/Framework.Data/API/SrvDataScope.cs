// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Patterns;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public class SrvDataScope : ACommon, IDataScope
    {
        //
        // INIT
        //

        public override void Init()
        {
            base.Init();
       }

        //
        // Data Set/Object CRUD layers.
        //

        public IDataSet<T> GetDataSet<T>()
        {
            return null;
        }     

        public IDataObject<T> GetDataObject<T>()
        {
            return null;
        }
    }
}
