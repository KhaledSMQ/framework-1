// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Fev/2016
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.Patterns;
using System;

namespace Framework.Data.EntityFramework.Objects
{
    public abstract class ADataSetWithKey<TItem, TID> : 
        AGenericDataSet<TItem>, 
        IGenericDataSet<TItem> 
        where TItem : class, IID<TID>
    {    
        //
        // CRUDs
        //   

        public override object Update(TItem item)
        {
            throw new NotImplementedException();
        }
    }
}
