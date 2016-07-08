// ============================================================================
// Project: Framework
// Name/Class: SrvHost
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Host related properties and features.
// ============================================================================

using Framework.Factory.Patterns;
using System.Web.Hosting;

namespace Framework.Factory.API
{
    public class SrvHost : ACommon, IHost
    {
        //
        // PROPERTIES
        // Computed values.
        //

        public string PhysicalPath { get { return __GetHostPhysicalPath(); } }

        public string VirtualPath { get { return __GetHostVirtualPath(); } }

        public bool IsInDevelopmentMode { get { return __IsInDevelopmentMode(); } }    
      
        //
        // Get the complete absolute physical path for a file.
        //

        public string GetAbsolutePhysicalPath(string relPath)
        {
            return System.IO.Path.Combine(PhysicalPath, relPath);
        }    

        //
        // HELPER
        // Return the application absolute physical path.
        // The location on disk.
        //

        private string __GetHostPhysicalPath()
        {
            return HostingEnvironment.ApplicationPhysicalPath;
        }

        //
        // HELPER
        // Return the application virtual path.
        //
        private string __GetHostVirtualPath()
        {
            return HostingEnvironment.ApplicationVirtualPath;
        }

        //
        // HELPER
        // Check if we are in development mode.
        //
        private bool __IsInDevelopmentMode()
        {
            return HostingEnvironment.IsDevelopmentEnvironment;
        }
    }
}
