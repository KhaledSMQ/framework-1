// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base service for single object sources.
// ============================================================================

using Framework.Data.API;
using Framework.Factory.Patterns;
using System;
using Framework.Data.Model.Objects;

namespace Framework.Data.Patterns
{
    public abstract class ADataContext<TUser> : ACommon, IDataContext<TUser>
    {
        //
        // The data context definition.
        //

        public Context<TUser> Context { get; set; }

        //
        // IMPLEMENTATION SPECIFIC
        // To be implemented by data context providers.
        //

        public abstract IGenericDataObject<T> GetDataObject<T>();

        public abstract IGenericDataSet<T> GetDataSet<T>();

        public abstract IDynamicDataObject GetDataObject(Type type);

        public abstract IDynamicDataSet GetDataSet(Type type);

        public abstract void CreateModel();    
    }
}
