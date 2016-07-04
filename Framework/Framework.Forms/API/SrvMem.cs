// ============================================================================
// Project: Framework
// Name/Class: SrvMem
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 10/Mar/2016
// Company: Coop4Creativity
// Description:
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Types.Specialized;
using Framework.Factory.Patterns;
using Framework.Forms.Model.Template;
using System.Collections.Generic;

namespace Framework.Forms.API
{
    public class SrvMem : ACommon, IMem
    {
        //
        // INIT/SHUTDOWN
        //

        public override void Init()
        {
            base.Init();
            _Templates = new SortedDictionary<Id, FormTemplate>();
        }

        public override void Shutdown()
        {
            base.Shutdown();
            _Templates.Clear();
        }

        //
        // TEMPLATES
        //

        public void Template_Load(IEnumerable<FormTemplate> forms)
        {
            forms.Apply(Template_Load);
        }

        public void Template_Load(FormTemplate form)
        {
            if (null != form)
            {
                if (null != form.ID)
                {
                    if (!_Templates.ContainsKey(form.ID))
                    {
                        _Templates.Add(form.ID, form);
                    }
                    else
                    {
                        Core.Error.Throw.Fatal();
                    }
                }
                else
                {
                    Core.Error.Throw.Fatal();
                }
            }
            else
            {
                Core.Error.Throw.Fatal();
            }
        }

        public FormTemplate Template_Get(Id form)
        {
            FormTemplate template = null;

            if (null != form)
            {
                if (_Templates.ContainsKey(form))
                {
                    template = _Templates[form];
                }
                else
                {
                    Core.Error.Throw.Fatal();
                }
            }
            else
            {
                Core.Error.Throw.Fatal();
            }

            return template;
        }

        public FormTemplate Template_Get(params string[] parcels)
        {
            return Template_Get(new Id(parcels));
        }

        public IEnumerable<FormTemplate> Template_GetList()
        {
            return _Templates.Values;
        }

        public void Template_Update(IEnumerable<FormTemplate> forms)
        {
            forms.Apply(Template_Update);
        }

        public void Template_Update(FormTemplate form)
        {
            if (null != form)
            {
                Template_Unload(form.ID);
                _Templates.Add(form.ID, form);
            }
            else
            {
                Core.Error.Throw.Fatal();
            }
        }

        public void Template_Unload(IEnumerable<Id> forms)
        {
            forms.Apply(Template_Unload);
        }

        public void Template_Unload(Id form)
        {
            if (null != form)
            {
                if (_Templates.ContainsKey(form))
                {
                    _Templates.Remove(form);
                }
            }
            else
            {
                Core.Error.Throw.Fatal();
            }
        }

        //
        // INTERNALS
        //

        private IDictionary<Id, FormTemplate> _Templates;
    }
}
