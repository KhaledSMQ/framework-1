// ============================================================================
// Project: Toolkit Apps
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Toolkit.Apps.Web.Framework.Services.Default;
using Framework.CMS1.Api.Interface;
using Framework.CMS1.Model.Views;

namespace Framework.CMS1.Api.Default
{
    public class SrvView : AContextObjectSourceWrapper<View, int>, IView
    {
    }
}
