// ============================================================================
// Project: Framework
// Name/Class: MimeTypeHelper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: MimeType useful methods and constants.
// ============================================================================                    

using System.Collections.Generic;
using System.IO;
using Framework.Core.Error;
using Framework.Core.Extensions;

namespace Framework.Core.Helpers
{
    //
    // LIST OF COMPLETE MIME TYPES:
    // http://www.freeformatter.com/mime-types-list.html
    //

    public static class MimeTypeHelper
    {
        //
        // CONSTANTS
        // List of known mime type values.
        //

        public const string TYPE_HTML = "text/html";
        public const string TYPE_SVG = "image/svg+xml";
        public const string TYPE_PNG = "image/png";
        public const string TYPE_GIF = "image/gif";
        public const string TYPE_TIFF = "image/tiff";
        public const string TYPE_JPEG = "image/jpeg";
        public const string TYPE_BMP = "image/bmp";
        public const string TYPE_JAVASCRIPT = "application/javascript";
        public const string TYPE_JSON = "application/json";
        public const string TYPE_PDF = "application/pdf";
        public const string TYPE_TEXT_PLAIN = "text/plain";
        public const string TYPE_XAML = "application/x-ms-xbap";
        public const string TYPE_XSLT = "application/xslt+xml";
        public const string TYPE_XML = "application/xml";
        public const string TYPE_CSS = "text/css";
        public const string TYPE_DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public const string TYPE_DOC = "application/msword";
        public const string TYPE_XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public const string TYPE_XLS = "application/vnd.ms-excel";
        public const string TYPE_PPT = "application/vnd.ms-powerpoint";
        public const string TYPE_PPTX = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
        public const string TYPE_TXT = "text/plain";
        public const string TYPE_CSV = "text/csv";
        public const string TYPE_WOFF = "application/x-font-woff";
        public const string TYPE_EOT = "application/vnd.ms-fontobject";
        public const string TYPE_TTF = "application/x-font-ttf";

        //
        // CONSTANTS
        // List of file extensions.
        //

        public const string EXT_HTML = ".html";
        public const string EXT_SVG = ".svg";
        public const string EXT_PNG = ".png";
        public const string EXT_GIF = ".gif";
        public const string EXT_TIFF = ".tiff";
        public const string EXT_JPEG = ".jpeg";
        public const string EXT_JPG = ".jpg";
        public const string EXT_BMP = ".bmp";
        public const string EXT_JAVASCRIPT = ".js";
        public const string EXT_JSON = ".json";
        public const string EXT_PDF = ".pdf";
        public const string EXT_TEXT_PLAIN = ".txt";
        public const string EXT_XAML = ".xaml";
        public const string EXT_XSLT = ".xslt";
        public const string EXT_XSL = ".xsl";
        public const string EXT_XML = ".xml";
        public const string EXT_CSS = ".css";
        public const string EXT_DOCX = ".docx";
        public const string EXT_DOC = ".doc";
        public const string EXT_XLSX = ".xlsx";
        public const string EXT_XLS = "xls";
        public const string EXT_PPT = ".ppt";
        public const string EXT_PPTX = ".pptx";
        public const string EXT_TXT = ".txt";
        public const string EXT_CSV = ".csv";
        public const string EXT_WOFF = ".woff";
        public const string EXT_EOT = ".eot";
        public const string EXT_TTF = ".ttf";

        //
        // Mapping between mime type and extension.
        //

        public static IDictionary<string, string> MimeTypeToFileExtension = new SortedDictionary<string, string>() 
        {
            {TYPE_PNG, EXT_PNG},
            {TYPE_JAVASCRIPT, EXT_JAVASCRIPT},
            {TYPE_CSS, EXT_CSS},
            {TYPE_XML, EXT_XML},
            {TYPE_BMP, EXT_BMP},
            {TYPE_GIF, EXT_GIF},
            {TYPE_TIFF, EXT_TIFF},
            {TYPE_PDF, EXT_PDF},
            {TYPE_DOC, EXT_DOC},
            {TYPE_DOCX, EXT_DOCX},
            {TYPE_XLS, EXT_XLS},
            {TYPE_XLSX, EXT_XLSX},
            {TYPE_PPT, EXT_PPT},
            {TYPE_PPTX, EXT_PPTX},
            {TYPE_JPEG, EXT_JPEG},            
            {TYPE_XSLT, EXT_XSLT},
            {TYPE_TXT, EXT_TXT},
            {TYPE_CSV, EXT_CSV},
            {TYPE_JSON, EXT_JSON},
            {TYPE_WOFF, EXT_WOFF},
            {TYPE_EOT, EXT_EOT},
            {TYPE_TTF, EXT_TTF},
            {TYPE_SVG, EXT_SVG}
        };

        //
        // Mapping between file extension and mime type.
        //

        public static IDictionary<string, string> FileExtensionToMimeType = new SortedDictionary<string, string>() 
        {
            {EXT_PNG, TYPE_PNG},
            {EXT_JAVASCRIPT, TYPE_JAVASCRIPT},
            {EXT_CSS, TYPE_CSS},
            {EXT_XML, TYPE_XML},
            {EXT_BMP, TYPE_BMP},
            {EXT_GIF, TYPE_GIF},
            {EXT_TIFF, TYPE_TIFF},
            {EXT_PDF, TYPE_PDF},
            {EXT_DOC, TYPE_DOC},
            {EXT_DOCX, TYPE_DOCX},
            {EXT_XLS, TYPE_XLS},
            {EXT_XLSX, TYPE_XLSX},
            {EXT_PPT, TYPE_PPT},
            {EXT_PPTX, TYPE_PPTX},
            {EXT_JPEG, TYPE_JPEG},
            {EXT_JPG, TYPE_JPEG},
            {EXT_XSLT, TYPE_XSLT},
            {EXT_XSL, TYPE_XSLT},
            {EXT_TXT, TYPE_TXT},
            {EXT_CSV, TYPE_CSV},
            {EXT_JSON, TYPE_JSON},
            {EXT_WOFF, TYPE_WOFF},
            {EXT_EOT, TYPE_EOT},
            {EXT_TTF, TYPE_TTF},
            {EXT_SVG, TYPE_SVG}
        };

        //
        // GET-MIMETYPE-FROM-FILENAME
        // Based of the file extension return the corresponding
        // mime type. The mime type is returned in the shape of a string.
        //

        public static string GetMimeTypeFromFilename(string filename, bool silent = false)
        {
            string mime = string.Empty;
            string ext = Path.GetExtension(filename).ToLower();

            if (FileExtensionToMimeType.ContainsKey(ext))
            {
                mime = FileExtensionToMimeType[ext];
            }
            else
            {
                if (!silent)
                {
                    Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "Unable to determine mime type for filename '{0}'", filename);
                }
            }

            return mime;
        }

        //
        // GET-MIMETYPE-FROM-URL
        // Based on a url get the mime type. This implies removing
        // optional information from the url, stuff like query string
        // and anchors...
        //

        public static string GetMimeTypeFromUrl(string url, bool silent = false)
        {
            string mime = string.Empty;

            //
            // Remove the query string.
            //

            string noQS = url;

            if (noQS.Contains("?"))
            {
                noQS = noQS.LeftOf('?');
            }

            //
            // Remove anchors.
            //

            string noAnchor = noQS;

            if (noAnchor.Contains("#"))
            {
                noAnchor = noAnchor.LeftOf('#');
            }

            return GetMimeTypeFromFilename(noAnchor, silent);
        }

        //
        // GET-EXTENSOIN-FROM-MIMETYPE
        // Based of the mime type return the corresponding
        // file extension.
        //

        public static string GetFileExtensionFromMimeType(string mimetype, bool silent = false)
        {
            string mime = mimetype.ToLower();
            string ext = string.Empty;

            if (MimeTypeToFileExtension.ContainsKey(mime))
            {
                ext = MimeTypeToFileExtension[mime];
            }
            else
            {
                if (!silent)
                {
                    Throw.WithPrefix(Lib.DEFAULT_ERROR_MSG_PREFIX, "Unable to determine file extension from mime type '{0}'", mimetype);
                }
            }

            return ext;
        }
    }
}
