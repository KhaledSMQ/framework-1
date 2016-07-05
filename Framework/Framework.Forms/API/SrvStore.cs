// ============================================================================
// Project: Framework
// Name/Class:
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using Framework.Forms.Model.Template;
using System.Collections.Generic;
using Framework.Core.Extensions;

namespace Framework.Forms.API
{
    public class SrvStore : ACommon, IStore
    {
        //
        // INIT/SHUTDOWN
        //

        public override void Init()
        {
            base.Init();

            //
            // Bootup dependent services.
            // Note that we only initialize theses services here
            // because they do not have circular dependencies.
            //

            _SrvMem = Scope.Hub.GetUnique<IMem>();
        }

        //
        // TEMPLATES
        //


        public IEnumerable<Id> Template_Import(IEnumerable<FormTemplate> forms)
        {
            return forms.Map(new List<Id>(), form => { return Template_Import(form); });
        }

        public Id Template_Import(FormTemplate form)
        {
            _SrvMem.Template_Load(form);
            return form.ID;
        }

        public Id Template_Import(string form)
        {
            FormTemplate template = Core.Helpers.JSONHelper.ReadJSONObjectFromString<FormTemplate>(form);
            return Template_Import(template);
        }

        public FormTemplate Template_Get(string form)
        {
            return Template_Get(Id.FromString(form));
        }

        public FormTemplate Template_Get(Id form)
        {
            return _SrvMem.Template_Get(form);
        }

        public IEnumerable<FormTemplate> Template_GetList()
        {
            return _SrvMem.Template_GetList();
        }

        public IEnumerable<Id> Template_Update(IEnumerable<FormTemplate> forms)
        {
            return forms.Map(new List<Id>(), form => { return Template_Update(form); });
        }

        public Id Template_Update(FormTemplate form)
        {
            _SrvMem.Template_Update(form);
            return form.ID;
        }

        public Id Template_Update(string form)
        {
            FormTemplate template = Core.Helpers.JSONHelper.ReadJSONObjectFromString<FormTemplate>(form);
            return Template_Update(template);
        }

        public Id Template_Delete(string form)
        {
            return Template_Delete(new Id(form));
        }

        public Id Template_Delete(Id form)
        {
            _SrvMem.Template_Unload(form);
            return form;
        }

        //
        // DIAGNOSTICS
        // Memory & Performance.
        //

        public object Mem_Dump()
        {
            return new { Templates = Mem_GetTemplates() };
        }

        public object Mem_GetTemplates()
        {
            return _SrvMem.Template_GetList();
        }

        //
        // Dependent services.
        //

        private IMem _SrvMem;
    }
}
