// ============================================================================
// Project: FRamework
// Name/Class: Page
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Base page definition.
// ============================================================================

using Framework.Core.Api;
using System;

namespace Framework.Web.Controls
{
    public class Page : System.Web.UI.Page
    {
        //
        // PROPERTIES
        // Control properties for subclasses.
        //

        public IContainer Container { get; set; } 
    }
}
