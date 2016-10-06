// ============================================================================
// Project: Framework
// Name/Class: IDynamicDataSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 14/Mar/2016
// Company: Coop4Creativity
// Description: Dynamic object data source.
// ============================================================================

using Framework.Core.Api;
using System;
using System.Linq;

namespace Framework.Data.Api
{
    public interface IDynamicDataSet : ICommon
    {
        //
        // PROPERTIES
        //

        Type Entity { get; set; }

        //
        // API
        //

        object Create(object item);

        IQueryable Queryable();

        object Query(string name, params object[] args);

        object Update(object item);

        object Delete(object item);

        void Save();
    }
}
