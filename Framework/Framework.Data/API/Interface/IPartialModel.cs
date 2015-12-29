// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: 
// ============================================================================

using Framework.Data.Model;
using Framework.Data.Patterns;

namespace Framework.Data.API.Interface
{
    public interface IPartialModel : IWrapperDataSet<PartialModel>
    {
        PartialModel GetByName(string name);

        PartialModel GetByType(string type);
    }
}
