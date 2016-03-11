// ============================================================================
// Project: Framework
// Name/Class: IHost
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 07/Mar/2016
// Company: Cybermap Lta.
// Description: Host related properties and features.
// ============================================================================

using Framework.Configuration.Model;
using Framework.Factory.Patterns;

namespace Framework.Configuration.API
{
    public interface IHost : ICommon
    {   
        //
        // Application physical path.
        //

        string PhysicalPath { get; }

        //
        // Application virtual path.
        //

        string VirtualPath { get; }

        //
        // Check if application is in development mode or not.
        //

        bool IsInDevelopmentMode { get; }

        //
        // Application related information.
        //

        Meta Meta { get; }

        //
        // Method to return the complete absolute physical
        // file path. Takes a relative path and returns the
        // complete file path. Useful for getting application
        // related files.
        //

        string GetAbsolutePhysicalPath(string relPath);        
    }
}
