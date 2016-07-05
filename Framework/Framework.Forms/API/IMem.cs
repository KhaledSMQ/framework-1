// ============================================================================
// Project: Framework
// Name/Class: IMem
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 06/Jul/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using Framework.Forms.Model.Template;
using System.Collections.Generic;

namespace Framework.Forms.API
{
    public interface IMem : ICommon
    {
        //
        // TEMPLATES
        //

        void Template_Load(IEnumerable<FormTemplate> forms);

        void Template_Load(FormTemplate form);

        FormTemplate Template_Get(Id form);

        FormTemplate Template_Get(params string[] parcels);

        IEnumerable<FormTemplate> Template_GetList();

        void Template_Update(IEnumerable<FormTemplate> forms);

        void Template_Update(FormTemplate form);

        void Template_Unload(IEnumerable<Id> forms);

        void Template_Unload(Id form);
    }
}
