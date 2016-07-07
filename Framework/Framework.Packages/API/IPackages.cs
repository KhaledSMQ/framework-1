// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Factory.Patterns;
using Framework.Packages.Model.Objects;

namespace Framework.Packages.API
{
    public interface IPackages : ICommon
    {
        //
        // GET-DOCUMENT-SET-METHODS
        // Methods for getting the list of documents.
        //

        DocumentSet GetDocumentsFromPackageNames(string names, string mimeType);

        //
        // GET-FILE-SET-METHODS
        // Methods for getting the list of files.
        //

        FileSet GetFilesFromPackageNames(string names, string mimeType);

        //
        // GET-URL-SET-METHODS
        // Methods for getting the list of urls.
        //

        UrlSet GetUrlsFromPackageNames(string names, string mimeType);

        //
        // GET-PACKAGE-METHODS
        // Methods for getting package information and definition.
        //        

        Package GetPackageMeta(string name);

        Package GetPackageFiles(string name);

        Package GetPackageDependencies(string name);

        Package GetPackage(string name);

        //
        // GET-PACKAGE-SET-METHODS
        // Methods for getting package set information and definition.
        //  

        PackageSet GetPackageSetMeta(string name);

        PackageSet GetPackageSetFiles(string name);

        PackageSet GetPackageSetDependencies(string name);

        PackageSet GetPackageSet(string name);

        //
        // GET-PACKAGE-TREE-METHODS
        // Methods for getting package tree information and definition.
        //  

        PackageSet GetPackageTreeMeta(string name);

        PackageSet GetPackageTreeFiles(string name);

        PackageSet GetPackageTreeDependencies(string name);

        PackageSet GetPackageTree(string name);
    }
}
