// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 13/Jul/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Data.Model.Objects;
using Framework.Core.Api;
using System;

namespace Framework.Data.Api
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
