// ============================================================================
// Project: Framework
// Name/Class: AWrapperSourceSet
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service for object set source.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Patterns;
using Framework.Data.Patterns;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Factory.Patterns
{
    public abstract class AWrapperDataSet<TItem> : ACommon, IWrapperDataSet<TItem>
    {
        //
        // PROPERTIES
        // 

        public IConfigMap Src { get; set; }

        protected IProviderDataSet<TItem> DataLayer { get; set; }

        //
        // INIT
        //

        public override void Init(IConfigMap config)
        {
            //
            // Base initialization.
            //

            base.Init(config);

            //
            // Initialize the inner source layer.
            //

            DataLayer = Ctx.Store.GetDataSet<TItem>(Src);
        }

        //
        // CREATE
        //

        public virtual object Create(TItem item)
        {
            return DataLayer.Create(item);
        }

        public virtual IEnumerable<object> Create(IEnumerable<TItem> items)
        {
            return items.Map(new List<object>(), Create);
        }

        //
        // GET
        //

        public virtual TItem GetByID(object id)
        {
            return DataLayer.GetByID(id);
        }

        public virtual IEnumerable<TItem> GetByID(IEnumerable<object> ids)
        {
            return ids.Map(new List<TItem>(), GetByID);
        }

        public virtual TItem Get(TItem item)
        {
            return DataLayer.Get(item);
        }

        public virtual IEnumerable<TItem> Get(IEnumerable<TItem> items)
        {
            return items.Map(new List<TItem>(), Get);
        }

        //
        // QUERY
        //

        public virtual IQueryable<TItem> Queryable()
        {
            return DataLayer.Queryable();
        }

        public virtual IEnumerable<TItem> Query(object query)
        {
            return DataLayer.Query(query);
        }

        public virtual IEnumerable<TItem> Query(string query)
        {
            return DataLayer.Query(query);
        }

        //
        // UPDATE
        //

        public virtual object Update(TItem item)
        {
            return DataLayer.Update(item);
        }

        public virtual IEnumerable<object> Update(IEnumerable<TItem> items)
        {
            return items.Map(new List<object>(), Update);
        }

        //
        // DELETE
        //

        public virtual object DeleteByID(object id)
        {
            return DataLayer.DeleteByID(id);
        }

        public virtual IEnumerable<object> DeleteByID(IEnumerable<object> items)
        {
            return items.Map(new List<object>(), DeleteByID);
        }

        public virtual object Delete(TItem item)
        {
            return DataLayer.Delete(item);
        }

        public virtual IEnumerable<object> Delete(IEnumerable<TItem> items)
        {
            return items.Map(new List<object>(), Delete);
        }

        //
        // SAVE
        //

        public virtual void Save()
        {
            DataLayer.Save();
        }
    }
}
