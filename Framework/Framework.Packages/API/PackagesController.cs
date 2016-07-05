// ============================================================================
// Project: Framework
// Name/Class: 
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 25/Mar/2016
// Company: Coop4Creativity
// Description: 
// ============================================================================

using System.Web.Http;
using Framework.Packages.API;
using Framework.Factory.Patterns;

namespace Framework.Packages.Controllers
{
    [Authorize]
    public class PackagesController : AControllerServiceWrapper<IPackages>
    {
        //
        // GET-DOCUMENT-SET-METHODS
        // Methods for getting the list of documents.
        //

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [ActionName("get-meta")]
        public IHttpActionResult GetPackageMeta(string id)
        {
            return Ok(Srv.GetPackageMeta(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("get-files")]
        public IHttpActionResult GetPackageFiles(string id)
        {
            return Ok(Srv.GetPackageFiles(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("get-deps")]
        public IHttpActionResult GetPackageDependencies(string id)
        {
            return Ok(Srv.GetPackageDependencies(id));
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [ActionName("set-meta")]
        public IHttpActionResult GetPackageSetMeta(string id = null)
        {
            return Ok(Srv.GetPackageSetMeta(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("set-files")]
        public IHttpActionResult GetPackageSetFiles(string íd = null)
        {
            return Ok(Srv.GetPackageSetFiles(íd));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("set-deps")]
        public IHttpActionResult GetPackageSetDependencies(string id = null)
        {
            return Ok(Srv.GetPackageSetDependencies(id));
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [ActionName("tree-meta")]
        public IHttpActionResult GetPackageTreeMeta(string id = null)
        {
            return Ok(Srv.GetPackageTreeMeta(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("tree-files")]
        public IHttpActionResult GetPackageTreeFiles(string id = null)
        {
            return Ok(Srv.GetPackageTreeFiles(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("tree-deps")]
        public IHttpActionResult GetPackageTreeDependencies(string id = null)
        {
            return Ok(Srv.GetPackageTreeDependencies(id));
        }

        [AllowAnonymous]
        [HttpGet]
        [ActionName("tree")]
        public IHttpActionResult GetPackageTree(string id = null)
        {
            return Ok(Srv.GetPackageTree(id));
        }
    }
}