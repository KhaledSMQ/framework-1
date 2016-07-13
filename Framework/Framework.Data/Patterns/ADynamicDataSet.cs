// ============================================================================
// Project: Framework
// Name/Class: ADynamicDataSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 14/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.API;
using Framework.Factory.Patterns;
using System;
using System.Linq;

namespace Framework.Data.Patterns
{
    public abstract class ADynamicDataSet : ACommon, IDynamicDataSet
    {
        //
        // PROPERTIES
        //

        public Type Entity { get; set; }

        //
        // API
        //

        public abstract object Create(object item);

        public abstract IQueryable Queryable();

        public abstract object Query(string name, params object[] args);

        public abstract object Update(object item);

        public abstract object Delete(object item);

        public abstract void Save();
    }
}
