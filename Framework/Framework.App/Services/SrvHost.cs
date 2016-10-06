// ============================================================================
// Project: Framework
// Name/Class: SrvHost
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Host related properties and features.
// ============================================================================

using Framework.Core.Api;
using Framework.Core.Patterns;
using System.Web.Hosting;

namespace Framework.App.Services
{
    public class SrvHost : ACommon, IHost
    {
        //
        // PROPERTIES
        // Computed values.
        //

        public string PhysicalPath { get { return HostingEnvironment.ApplicationPhysicalPath; } }

        public string VirtualPath { get { return HostingEnvironment.ApplicationVirtualPath; } }

        public bool IsInDevelopmentMode { get { return HostingEnvironment.IsDevelopmentEnvironment; } }    
      
        //
        // Get the complete absolute physical path for a file.
        //

        public string GetAbsolutePhysicalPath(string relPath)
        {
            return System.IO.Path.Combine(PhysicalPath, relPath);
        }    
    }
}
