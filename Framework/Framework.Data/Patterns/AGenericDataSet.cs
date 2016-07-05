// ============================================================================
// Project: Framework
// Name/Class: AGenericDataSet
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 14/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Patterns;
using System.Linq;

namespace Framework.Data.Patterns
{
    public abstract class AGenericDataSet<TItem> : ACommon, IGenericDataSet<TItem>
    {
        public abstract object Create(TItem item);

        public abstract IQueryable<TItem> Queryable();

        public abstract object Query(string name, params object[] args);

        public abstract object Update(TItem item);

        public abstract object Delete(TItem item);

        public abstract void Save();
    }
}
