﻿// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 04/Oct/2015
// Company: Cybermap Lta.
// Description:
// ============================================================================

using Framework.CMS.Api.Interface;
using Framework.CMS.Model.Views;
using Framework.Factory.Patterns;

namespace Framework.CMS.Api.Default
{
    public class SrvView : AWrapperDataSet<View>, IView { }
}