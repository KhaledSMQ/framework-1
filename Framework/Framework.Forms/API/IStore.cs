// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Core.Api;
using Framework.Forms.Model.Template;
using System.Collections.Generic;

namespace Framework.Forms.Api
{
    public interface IStore : ICommon
    {
        //
        // TEMPLATES
        //


        IEnumerable<Id> Template_Import(IEnumerable<FormTemplate> forms);

        Id Template_Import(FormTemplate form);

        Id Template_Import(string form);

        FormTemplate Template_Get(string form);

        FormTemplate Template_Get(Id form);

        IEnumerable<FormTemplate> Template_GetList();

        IEnumerable<Id> Template_Update(IEnumerable<FormTemplate> forms);

        Id Template_Update(FormTemplate form);

        Id Template_Update(string form);

        Id Template_Delete(string form);

        Id Template_Delete(Id form);

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        object Mem_Dump();

        object Mem_GetTemplates();
    }
}
