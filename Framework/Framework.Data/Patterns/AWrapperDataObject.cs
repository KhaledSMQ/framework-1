﻿// ============================================================================
// Project: Framework
// Name/Class: AWrapperDataObject
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Base service for single object sources.
// ============================================================================

using Framework.Core.Patterns;
using Framework.Data.API;
using Framework.Factory.Patterns;

namespace Framework.Data.Patterns
{
    public abstract class AWrapperDataObject<TItem> : ACommon, IWrapperDataObject<TItem>
    {
        //
        // PROPERTIES
        // 

        protected IDataObject<TItem> DataLayer { get; set; }

        //
        // INIT
        //

        public override void Init()
        {
            //
            // Base initialization.
            //

            base.Init();

            //
            // Initialize the inner source layer.
            //

            DataLayer = Scope.Hub.GetUnique<IStore>().GetDataObject<TItem>();
        }

        //
        // SET
        //

        public virtual void Set(TItem item)
        {
            DataLayer.Set(item);
        }

        //
        // GET
        //

        public virtual TItem Get()
        {
            return DataLayer.Get();
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
