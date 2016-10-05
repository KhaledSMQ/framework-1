// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using Framework.Core.Patterns;
using Framework.Packages.API;
using System.Web.Http;

namespace Framework.Packages.Patterns
{
    public abstract class AController : AControllerServiceWrapper<IPackages>
    {
        //
        // GET-DOCUMENT-SET-METHODS
        // Methods for getting the list of documents.
        //

        [HttpGet]
        [ActionName("docs")]
        public IHttpActionResult GetDocumentsFromPackageNames(string names = null, string mimeType = null)
        {
            return Ok(Srv.GetDocumentsFromPackageNames(names, mimeType));
        }

        //
        // GET-FILE-SET-METHODS
        // Methods for getting the list of files.
        //

        [HttpGet]
        [ActionName("files")]
        public IHttpActionResult GetFilesFromPackageNames(string names = null, string mimeType = null)
        {
            return Ok(Srv.GetFilesFromPackageNames(names, mimeType));
        }

        //
        // GET-URL-SET-METHODS
        // Methods for getting the list of files.
        //

        [HttpGet]
        [ActionName("urls")]
        public IHttpActionResult GetUrlsFromPackageNames(string names = null, string mimeType = null)
        {
            return Ok(Srv.GetUrlsFromPackageNames(names, mimeType));
        }

        //
        // GET-PACKAGE-METHODS
        // Methods for getting package information and definition.
        //

        [HttpGet]
        [ActionName("get-meta")]
        public IHttpActionResult GetPackageMeta(string id)
        {
            return Ok(Srv.GetPackageMeta(id));
        }

        [HttpGet]
        [ActionName("get-files")]
        public IHttpActionResult GetPackageFiles(string id)
        {
            return Ok(Srv.GetPackageFiles(id));
        }

        [HttpGet]
        [ActionName("get-deps")]
        public IHttpActionResult GetPackageDependencies(string id)
        {
            return Ok(Srv.GetPackageDependencies(id));
        }

        [HttpGet]
        [ActionName("get")]
        public IHttpActionResult GetPackage(string id)
        {
            return Ok(Srv.GetPackage(id));
        }

        //
        // GET-PACKAGE-SET-METHODS
        // Methods for getting package set information and definition.
        //

        [HttpGet]
        [ActionName("set-meta")]
        public IHttpActionResult GetPackageSetMeta(string id = null)
        {
            return Ok(Srv.GetPackageSetMeta(id));
        }

        [HttpGet]
        [ActionName("set-files")]
        public IHttpActionResult GetPackageSetFiles(string id = null)
        {
            return Ok(Srv.GetPackageSetFiles(id));
        }
        
        [HttpGet]
        [ActionName("set-deps")]
        public IHttpActionResult GetPackageSetDependencies(string id = null)
        {
            return Ok(Srv.GetPackageSetDependencies(id));
        }

        [HttpGet]
        [ActionName("set")]
        public IHttpActionResult GetPackageSet(string id = null)
        {
            return Ok(Srv.GetPackageSet(id));
        }

        //
        // GET-PACKAGE-TREE-METHODS
        // Methods for getting package tree information and definition.
        //

        [HttpGet]
        [ActionName("tree-meta")]
        public IHttpActionResult GetPackageTreeMeta(string id = null)
        {
            return Ok(Srv.GetPackageTreeMeta(id));
        }

        [HttpGet]
        [ActionName("tree-files")]
        public IHttpActionResult GetPackageTreeFiles(string id = null)
        {
            return Ok(Srv.GetPackageTreeFiles(id));
        }

        [HttpGet]
        [ActionName("tree-deps")]
        public IHttpActionResult GetPackageTreeDependencies(string id = null)
        {
            return Ok(Srv.GetPackageTreeDependencies(id));
        }

        [HttpGet]
        [ActionName("tree")]
        public IHttpActionResult GetPackageTree(string id = null)
        {
            return Ok(Srv.GetPackageTree(id));
        }
    }
}