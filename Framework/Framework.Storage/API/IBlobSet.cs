// ============================================================================
// Project: Framework
// Name/Class: IContextBlobSource
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Generic blob data source.
// ============================================================================

using Framework.Core.API;
using Framework.Core.Patterns;
using Framework.Storage.Patterns;
using System.Collections.Generic;

namespace Framework.Storage.API
{
    public interface IBlobSourceContext : ICommon, IID<string>, IStringReady, IXmlReadyParameterized, IXmlReady
    {
        //
        // FOLDERS ------------------------------------------------------------
        //

        //
        // Create a new folder in this blob source.
        //

        IFolder CreateFolder(IFolder folder, object ctx);

        IFolder CreateFolder(string path, object ctx);

        //
        // Create a list of folder in this blob storage.
        //

        IEnumerable<IFolder> CreateFolder(IEnumerable<IFolder> items, object ctx);

        //
        // Get a folder form blob storage.
        //

        IFolder GetFolder(string path, object ctx);

        //
        // Get folder from blob storage.
        //

        IFolder GetFolder(IFolder folder, object ctx);

        //
        // Update an item in the blob data source.
        //

        IFolder UpdateFolder(IFolder folder, object ctx);

        //
        // Update a list of folders in the data source.
        //

        IEnumerable<IFolder> UpdateFolder(IEnumerable<IFolder> items, object ctx);

        //
        // Delete a specific fodler from the blob data source.
        // Based on the path.
        //

        IFolder DeleteFolder(string path, object ctx);

        //
        // Delete a specific blob from the blob data source.
        //

        IFolder DeleteFolder(IFolder folder, object ctx);

        //
        // Delete a list of folders from the blob data source.
        //

        IEnumerable<IFolder> Delete(IEnumerable<IFolder> items, object ctx);

        //
        // BLOBS --------------------------------------------------------------
        //

        //
        // Create a new blob in this blob datasource.
        //

        IBlob Create(IBlob item, object ctx);

        //
        // Create in the blob data source a list of blobs.
        //

        IEnumerable<IBlob> Create(IEnumerable<IBlob> items, object ctx);

        //
        // Get blob by path and filename.
        //

        IBlob Get(string path, string filename, object ctx);

        //
        // Get blob by unique identifier.
        //

        IBlob GetWithContent(string path, string filename, object ctx);

        //
        // Get blob by blob reference.
        //

        IBlob Get(IBlob item, object ctx);

        //
        // Get blob by blob reference.
        //

        IBlob GetWithContent(IBlob item, object ctx);

        //
        // Update an item in the blob data source.
        //

        IBlob Update(IBlob item, object ctx);

        //
        // Update a list of blobs in the data source.
        //

        IEnumerable<IBlob> Update(IEnumerable<IBlob> items, object ctx);

        //
        // Delete a specific blob from the blob data source.
        // Based on the unique identifier.
        //

        IBlob Delete(string path, string filename, object ctx);

        //
        // Delete a specific blob from the blob data source.
        //

        IBlob Delete(IBlob item, object ctx);

        //
        // Delete a list of blob from the blob data source.
        //

        IEnumerable<IBlob> Delete(IEnumerable<IBlob> items, object ctx);

        //
        // QUERY --------------------------------------------------------------
        //

        //
        // Query the blob data source.
        // The query is given by a string value.
        //

        IEnumerable<IBlob> Query(string query, object ctx);

        //
        // Query the blob data source.
        // The query is a native to the blob source
        // implementation.
        //

        IEnumerable<IBlob> Query(object query, object ctx);

        //
        // Get the file tree structure for a specific folder.
        //

        IFolder GetFileTree(string path, bool recursive, object ctx);

        IFolder GetFileTree(IFolder folder, bool recursive, object ctx);
    }
}
