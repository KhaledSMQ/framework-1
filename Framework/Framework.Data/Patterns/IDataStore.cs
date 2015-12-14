// ============================================================================
// Project: Framework
// Name/Class: IDataStore
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Data cluster specification contract.
// ============================================================================

using Framework.Core.Patterns;
using System.Collections.Generic;

namespace Framework.Data.Patterns
{
    public interface IDataStore<TContext, TModel, TEntity, TSetting> : 
        IID<int>, 
        IName<string>, 
        IDescription<string>, 
        ITypeName<string>, 
        IAuditable<string>,  
        IConfigList<TSetting>
        where TContext : IDataContext<TSetting>
        where TModel : IDataModel<TSetting>
        where TEntity : IDataEntity<TSetting>
        where TSetting : IConfigSetting<int, string, string, string>
    {
        //
        // PROPERTIES
        //
    }
}
