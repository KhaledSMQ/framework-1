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
    public interface IDataScope : ICommon
    {
        //
        // Data Set/Object CRUD layers.
        //

        IDataSet<T> GetDataSet<T>();        

        IDataObject<T> GetDataObject<T>();
    }
}
