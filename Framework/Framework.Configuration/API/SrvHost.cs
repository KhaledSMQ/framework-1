// ============================================================================
// Project: Framework
// Name/Class: SrvHost
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Host related properties and features.
// ============================================================================

using Framework.Configuration.Config;
using Framework.Configuration.Model;
using Framework.Factory.Patterns;
using System.Web.Hosting;

namespace Framework.Configuration.API
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

        public Meta Meta { get { return __GetMeta(); } }

        //
        // Service initialization.
        // Load configuration and boot service.
        //

        public override void Init()
        {
            base.Init();
            __LoadConfig();
        }

        //
        // Get the complete absolute physical path for a file.
        //

        public string GetAbsolutePhysicalPath(string relPath)
        {
            return System.IO.Path.Combine(PhysicalPath, relPath);
        }

        //
        // HELPER
        // Load configuration from config file.
        //

        private void __LoadConfig()
        {
            //
            // Load from configuration file the host config.
            //

            HostConfiguration config = (HostConfiguration)System.Configuration.ConfigurationManager.GetSection(_Const.SECTION_HOST);
            if (null != config)
            {
                if (null != config.Meta)
                {
                    __Meta = Transforms.ToMeta(config.Meta);
                }                
            }            
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

        //
        // HELPER
        // Return the meta information about the hosting app.
        //
        private Meta __GetMeta()
        {
            return __Meta;
        }

        //
        // InMemory storage.
        //

        private Meta __Meta = null;
    }
}
