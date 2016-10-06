// ============================================================================
// Project: Framework
// Name/Class: ISrvTransforms
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Data.Model.Objects;
using Framework.Data.Model.Relational;
using Framework.Core.Api;

namespace Framework.Data.Api
{
    public interface ITransform<TUser> : ICommon
    {
        //
        // OBJECT ==> RELATIONAL OBJECT
        //

        FwDataCluster Convert(Cluster<TUser> cluster);
    }
}