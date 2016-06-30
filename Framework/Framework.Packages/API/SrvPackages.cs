// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Configuration.API;
using Framework.Core.Extensions;
using Framework.Factory.Patterns;
using Framework.Packages.Model;
using Framework.Web.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Framework.Packages.API
{
    public class SrvPackages : ACommon, IPackages
    {
        //
        // Config information.
        //

        private string PACKAGE_LIST_NAME_SEPARATOR = ",";
        private string PACKAGE_NAME_SEPARATOR = ":";
        private string PACKAGE_FOLDER_IGNORE = "_";
        private string PACKAGE_FOLDER_BASE = "packages";
        private string PACKAGE_DESCENDANTS = "*";
        private string PACKAGE_DESCENDANTS_AND_SELF = "+";

        private const string PACKAGE_FILE_NAME_DESCRIPTION = "_description.txt";
        private const string PACKAGE_FILE_NAME_EXTERNALS = "_external.json";

        private string[] PACKAGE_RESERVED_FILE_NAMES = { 
            PACKAGE_FILE_NAME_DESCRIPTION, 
            PACKAGE_FILE_NAME_EXTERNALS 
        };

        //
        // Type of information to extract for package.
        //

        public enum TypeOfPackageInfo
        {
            NONE = 0,           // 0000 -> 0
            DOCUMENTS = 1,      // 0001 -> 2^0 = 1 
            DEPENDENCIES = 2,   // 0010 -> 2^1 = 2
            DESCRIPTION = 4,    // 0100 -> 2^2 = 4 
            COMPLETE = 15,      // 1111 -> 2^0 (1) + 2^1 (2) + 2^2 (4) + 2^3 (8) = 15
        }

        //
        // GET-DCCUMENT-SET-METHODS
        // Methods for getting the list of documents.
        //

        public DocumentSet GetDocumentsFromPackageNames(string names, string mimeType)
        {
            DocumentSet set = new DocumentSet();

            if (names.isNotNullAndEmpty())
            {
                //
                // Get the package names from argument.
                //

                string[] packages = names.SplitNoEmpty(PACKAGE_LIST_NAME_SEPARATOR);

                //
                // now, fetch the list of documents from each package.
                //

                packages.Apply(name =>
                {
                    //
                    // BAsed on name, get the package information.
                    //

                    Package package = _GetPackageFromName(name, TypeOfPackageInfo.DOCUMENTS, mimeType);

                    //
                    // Only add to return set if pakacge is valid.
                    //

                    if (null != package)
                    {
                        set.AddRange(package.Documents);
                    }
                });
            }

            return set;
        }

        //
        // GET-FILE-SET-METHODS
        // Methods for getting the list of files.
        //

        public FileSet GetFilesFromPackageNames(string names, string mimeType)
        {
            return GetDocumentsFromPackageNames(names, mimeType).Files;
        }

        //
        // GET-URL-SET-METHODS
        // Methods for getting the list of urls.
        //

        public UrlSet GetUrlsFromPackageNames(string names, string MimeType)
        {
            return GetFilesFromPackageNames(names, MimeType).AbsoluteUrls;
        }

        //
        // GET-PACKAGE-METHODS
        // Methods for getting package information and definition.
        //  

        public Package GetPackageMeta(string name)
        {
            return _GetPackageFromName(name, TypeOfPackageInfo.NONE, null);
        }

        public Package GetPackageFiles(string name)
        {
            return _GetPackageFromName(name, TypeOfPackageInfo.DOCUMENTS, null);
        }

        public Package GetPackageDependencies(string name)
        {
            return _GetPackageFromName(name, TypeOfPackageInfo.NONE, null);
        }

        public Package GetPackage(string name)
        {
            return _GetPackageFromName(name, TypeOfPackageInfo.COMPLETE, null);
        }

        //
        // GET-PACKAGE-SET-METHODS
        // Methods for getting package set information and definition.
        //  

        public PackageSet GetPackageSetMeta(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.NONE);
        }

        public PackageSet GetPackageSetFiles(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.DOCUMENTS);
        }

        public PackageSet GetPackageSetDependencies(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.NONE);
        }

        public PackageSet GetPackageSet(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.COMPLETE);
        }

        //
        // GET-PACKAGE-TREE-METHODS
        // Methods for getting package tree information and definition.
        //  

        public PackageSet GetPackageTreeMeta(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.NONE);
        }

        public PackageSet GetPackageTreeFiles(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.DOCUMENTS);
        }

        public PackageSet GetPackageTreeDependencies(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.NONE);
        }

        public PackageSet GetPackageTree(string name)
        {
            return _GetPackageSet(name, TypeOfPackageInfo.COMPLETE);
        }

        //
        // HELPERS: Get package set information methods.
        //

        private PackageSet _GetPackageSet(string name, TypeOfPackageInfo info)
        {
            PackageSet set = new PackageSet();

            string safeName = name.isNullOrEmpty() ? string.Empty : name;

            string absPath = _GetPackagePathFromName(safeName);

            System.IO.Directory.EnumerateDirectories(absPath).Apply(dirFullPath =>
            {
                string dirName = System.IO.Path.GetFileName(dirFullPath);

                if (!dirName.StartsWith(PACKAGE_FOLDER_IGNORE))
                {
                    if (dirName.isNotNullAndEmpty())
                    {
                        //
                        // Add the package to set.
                        // Only add valid packages.
                        //

                        Package package = _GetPackageFromPath(dirFullPath, info, null);

                        if (null != package)
                        {
                            set.Add(package);
                        }
                    }
                }
            });

            return set;
        }

        //
        // HELPERS: Get package information methods.
        //

        private Package _GetPackageFromName(string name, TypeOfPackageInfo info, string mimeType)
        {
            return _GetPackageFromPath(_GetPackagePathFromName(name), info, mimeType);
        }

        private Package _GetPackageFromPath(string absPath, TypeOfPackageInfo info, string mimeType)
        {
            //
            // By default, we return a null package reference.
            //

            Package package = null;

            //
            // Verifiy if folder exists.
            //

            if (System.IO.Directory.Exists(absPath))
            {
                //
                // Extract package name and other information.
                //

                string name = _GetPackageNameFromPath(absPath);

                package = new Package();
                package.ID = name;
                package.BaseVirtualPath = _GetPackageBaseUrlFromName(name);
                package.Description = (TypeOfPackageInfo.DESCRIPTION & info) > 0 ? _GetPackageDescriptionFromPath(absPath) : null;
                package.Dependencies = (TypeOfPackageInfo.DEPENDENCIES & info) > 0 ? _GetPackageDependenciesFromPath(absPath) : null;
                package.Documents = (TypeOfPackageInfo.DOCUMENTS & info) > 0 ? _GetPackageDocumentsFromPath(absPath, mimeType) : null;
            }

            return package;
        }

        private string _GetPackageDescriptionFromPath(string absPath)
        {
            string description = string.Empty;
            return description;
        }

        private DocumentSet _GetPackageDocumentsFromPath(string absPath, string mimeType)
        {
            //
            // Document set to return.
            //

            DocumentSet docSet = new DocumentSet();

            //
            // Mapping for building the documents out of files.
            //

            IDictionary<string, Document> docMap = new SortedDictionary<string, Document>();

            //
            // Get the package name from the path.
            //

            string packageName = _GetPackageNameFromPath(absPath);

            //
            // Compute the base urls.
            //

            string relBaseUrl = _GetPackageBaseUrlFromName(packageName);
            string absBaseUrl = _GetPackageAbsoluteBaseUrlFromName(packageName);

            //
            // Extract the simple filename list from directory.
            //

            List<string> lstOfFiles = System.IO.Directory.EnumerateFiles(absPath).ToList();

            //
            // Order list alphabetically.
            //

            lstOfFiles.Sort();

            //
            // Prepare the mime type match regular expression.
            //

            string mimeTypeRegex = mimeType.isNullOrEmpty() ? @".*" : mimeType.Trim();

            //
            // Extract the documents. documents are sets
            // of file that have the same name, but different 
            // extensions.
            //

            lstOfFiles.Apply(absFilePath =>
            {
                string filename = System.IO.Path.GetFileName(absFilePath);
                string simpleName = System.IO.Path.GetFileNameWithoutExtension(absFilePath);
                string extension = System.IO.Path.GetExtension(absFilePath);
                bool mimeTypeMatchs = true;

                //
                // Extract the file mime type, this is used for 
                // filtering the supplied mime type.
                //

                string fileMimeType = Framework.Core.MimeTypes.TYPE_TXT;

                try
                {
                    fileMimeType = Framework.Core.MimeTypes.GetMimeTypeFromFilename(filename);
                }
                catch (Exception) { }

                //
                // Check if the file mime type matchs with the supplied mimeType.
                //

                mimeTypeMatchs = Regex.IsMatch(fileMimeType, mimeTypeRegex);

                //
                // If filename if not a reserved filename, then check
                // if the mime type matchs.
                //

                if (!PACKAGE_RESERVED_FILE_NAMES.Contains(filename) && mimeTypeMatchs)
                {

                    File file = new File();
                    file.ID = filename;
                    file.Name = filename;
                    file.RelativePath = _GetRelativePathFromFile(absFilePath);
                    file.RelativeUrl = Scope.Hub.Get<IResolver>().ResolveWithBaseUrl(relBaseUrl, filename);
                    file.AbsoluteUrl = Scope.Hub.Get<IResolver>().ResolveWithBaseUrl(absBaseUrl, filename);

                    try
                    {
                        file.MimeType = Framework.Core.MimeTypes.GetMimeTypeFromFilename(filename);
                    }
                    catch (Exception)
                    {
                        file.MimeType = Framework.Core.MimeTypes.TYPE_TXT;
                    }

                    Document doc = null;

                    if (docMap.ContainsKey(simpleName))
                    {
                        doc = docMap[simpleName];
                    }
                    else
                    {
                        doc = new Document();
                        doc.Files = new FileSet();
                        doc.ID = simpleName;

                        docMap.Add(simpleName, doc);
                    }

                    doc.Files.Add(file);

                }
                else
                    if (filename == PACKAGE_FILE_NAME_EXTERNALS)
                    {
                        //
                        // This is a file that contains external references for package.
                        //

                        string content = System.IO.File.ReadAllText(absFilePath);
                        IList<Document> tempSet = Core.Helpers.JSONHelper.ReadListOfJSONObjectsFromString<Document>(content);

                        //
                        // Filter by the supplied mime type mimetype.
                        //

                        tempSet.Apply(doc =>
                        {
                            FileSet newFileSet = new FileSet();

                            doc.Files.Apply(file =>
                            {
                                string currFileMimeType = file.MimeType.isNullOrEmpty() ? Framework.Core.MimeTypes.TYPE_TXT : file.MimeType.Trim();
                                bool currMimeTypeMatchs = Regex.IsMatch(currFileMimeType, mimeTypeRegex);
                                if (currMimeTypeMatchs)
                                {
                                    newFileSet.Add(file);
                                }
                            });

                            if (newFileSet.Count > 0)
                            {
                                Document newDoc = new Document();
                                newDoc.ID = doc.ID;
                                newDoc.Files = newFileSet;

                                docSet.Add(newDoc);
                            }
                        });
                    }
            });

            docSet.AddRange(docMap.Values);

            return docSet;
        }

        private DependencySet _GetPackageDependenciesFromPath(string absPath)
        {
            DependencySet set = new DependencySet();
            return set;
        }

        //
        // CONVERSION: Name ==> Path
        //             Path ==> Name
        //

        private string _GetPackagePathFromName(string name)
        {
            return System.IO.Path.Combine(Scope.Hub.Get<IHost>().PhysicalPath, PACKAGE_FOLDER_BASE, name.Trim().Replace(PACKAGE_NAME_SEPARATOR, "\\"));
        }

        private string _GetPackageNameFromPath(string path)
        {
            string absBasePath = System.IO.Path.Combine(Scope.Hub.Get<IHost>().PhysicalPath, PACKAGE_FOLDER_BASE);
            string name = path.Trim();
            name = name.StartsWith(absBasePath) ? name.ChopStart(absBasePath.Length) : name;
            name = _GetNormalizedPath(name).Replace("\\", PACKAGE_NAME_SEPARATOR).Replace("/", PACKAGE_NAME_SEPARATOR);
            return name;
        }

        //
        // CONVERSION: Name    ==> BaseUrl (Relative)
        //             BaseUrl ==> Name
        //

        private string _GetPackageBaseUrlFromName(string name)
        {
            return "~/" + PACKAGE_FOLDER_BASE + "/" + name.Trim().Replace(PACKAGE_NAME_SEPARATOR, "/");
        }

        private string _GetPackageNameFromBaseUrl(string baseUrl)
        {
            string name = baseUrl.Trim();
            name = name.StartsWith("~/") ? name.ChopStart(2) : name;
            name = _GetNormalizedPath(name);
            name = name.Replace("/", PACKAGE_NAME_SEPARATOR);
            return name;
        }

        //
        // CONVERSION: Name ==> Absolute Base Url
        //

        private string _GetPackageAbsoluteBaseUrlFromName(string name)
        {
            string relBaseUrl = _GetPackageBaseUrlFromName(name);
            return Scope.Hub.Get<IResolver>().ResolveWithBaseUrl(Scope.Hub.Get<IResolver>().ApplicationPath, relBaseUrl);
        }

        //
        // Normalize a path, either virtual or physical.
        //

        private string _GetNormalizedPath(string path)
        {
            string normalized = path.isNullOrEmpty() ? string.Empty : path.Trim();
            normalized = normalized.StartsWith("/") || normalized.StartsWith("\\") ? normalized.ChopStart(1) : normalized;
            normalized = normalized.EndsWith("/") || normalized.EndsWith("\\") ? normalized.ChopEnd(1) : normalized;
            return normalized;
        }

        //
        // Return the relative path for a file.
        //

        private string _GetRelativePathFromFile(string absFilePath)
        {
            string absBasePath = System.IO.Path.Combine(Scope.Hub.Get<IHost>().PhysicalPath, PACKAGE_FOLDER_BASE);
            string relativeFilePath = absFilePath;
            if (absFilePath.StartsWith(absBasePath))
            {
                relativeFilePath = relativeFilePath.Substring(absFilePath.Length);
            }
            return relativeFilePath;
        }
    }
}
