// ============================================================================
// Project: Framework
// Name/Class: ISrvTransforms
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Transform configuration objects into runtime objects.
// ============================================================================

using Framework.Data.Model.Config;
using Framework.Data.Model.Import;
using Framework.Data.Model.Schema;
using Framework.Factory.Patterns;

namespace Framework.Data.API
{
    public interface ITransform : ICommon
    {
        //
        // CONFIGURATION OBJECT ==> SCHEMA OBJECT
        //

        FW_DataCluster Convert(ConfigCluster cluster);

        //
        // IMPORT OBJECT ==> SCHEMA OBJECT
        //

        FW_DataCluster Convert(ImportCluster cluster);

    }
}