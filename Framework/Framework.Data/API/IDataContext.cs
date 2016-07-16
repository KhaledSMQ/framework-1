// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Objects;
using Framework.Factory.Patterns;
using System;

namespace Framework.Data.API
{
    public interface IDataContext<TUser> : ICommon
    {
        Context<TUser> Context { get; set; }

        void CreateModel();

        IGenericDataSet<T> GetDataSet<T>();

        IGenericDataObject<T> GetDataObject<T>();

        IDynamicDataSet GetDataSet(Type type);

        IDynamicDataObject GetDataObject(Type type);
    }
}
