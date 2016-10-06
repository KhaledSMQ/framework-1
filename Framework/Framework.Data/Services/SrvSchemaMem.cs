// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 16/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Data.Api;
using System;

namespace Framework.Data.Services
{
    public class SrvSchemaMem<TUser> : ASchema<TUser>
    {
        public override void Create<T>(T item)
        {
            
            throw new NotImplementedException();
        }

        public override void Delete<T>(Id id)
        {
            throw new NotImplementedException();
        }

        public override T Get<T>(Id id)
        {
            throw new NotImplementedException();
        }

        public override void Update<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}