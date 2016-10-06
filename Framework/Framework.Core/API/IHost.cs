// ============================================================================
// Project: Framework
// Name/Class: IHost
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 07/Mar/2016
// Company: Coop4Creativity
// Description: Host related properties and features.
// ============================================================================

namespace Framework.Core.Api
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
        // Method to return the complete absolute physical
        // file path. Takes a relative path and returns the
        // complete file path. Useful for getting application
        // related files.
        //

        string GetAbsolutePhysicalPath(string relPath);        
    }
}
