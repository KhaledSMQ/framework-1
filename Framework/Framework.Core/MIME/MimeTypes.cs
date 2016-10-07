// ============================================================================
// Project: Framework
// Name/Class: MimeTypes
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: MimeTypes useful constants & methods.
// ============================================================================                    

using Framework.Core.Config;
using Framework.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Framework.Core
{
    //
    // LIST OF COMPLETE MIME TYPES:
    // http://www.freeformatter.com/mime-types-list.html
    //

    public static class MimeTypes
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
        public const string TYPE_ZIP = "application/zip";
        public const string TYPE_RAR = "application/x-rar-compressed";

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
        public const string EXT_ZIP = ".zip";
        public const string EXT_RAR = ".rar";

        //
        // Mapping between mime type and extension.
        //

        private static readonly IDictionary<string, string> MimeTypeToFileExtension = new SortedDictionary<string, string>()
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
            {TYPE_SVG, EXT_SVG},
            {TYPE_ZIP, EXT_ZIP},
            {TYPE_RAR, EXT_RAR}
        };

        //
        // Mapping between file extension and mime type.
        //

        private static readonly IDictionary<string, string> FileExtensionToMimeType = new SortedDictionary<string, string>()
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
            {EXT_JPG, TYPE_JPEG},
            {EXT_JPEG, TYPE_JPEG},
            {EXT_XSL, TYPE_XSLT},
            {EXT_XSLT, TYPE_XSLT},
            {EXT_TXT, TYPE_TXT},
            {EXT_CSV, TYPE_CSV},
            {EXT_JSON, TYPE_JSON},
            {EXT_WOFF, TYPE_WOFF},
            {EXT_EOT, TYPE_EOT},
            {EXT_TTF, TYPE_TTF},
            {EXT_SVG, TYPE_SVG},
            {EXT_ZIP, TYPE_ZIP},
            {EXT_RAR, TYPE_RAR}
        };

        //
        // Boolean constants used for API.
        // SILENT for silent operations.
        // THROW_ERROR_IF_NOT_FOUND used to singal that an error should be thrown.
        //

        public const bool SILENT = true;
        public const bool THROW_ERROR_IF_NOT_FOUND = false;

        //
        // GET-MIMETYPE-FROM-FILENAME
        // Based of the file extension return the corresponding
        // mime type. The mime type is returned in the shape of a string.
        //

        public static string GetMimeTypeFromFilename(string fileName)
        {
            return GetMimeTypeFromFilename(fileName, THROW_ERROR_IF_NOT_FOUND);
        }

        public static string GetMimeTypeFromFilename(string fileName, bool silent)
        {
            string mimeType = string.Empty;
            string fileExtension = Path.GetExtension(fileName).ToLower(CultureInfo.InvariantCulture);

            if (FileExtensionToMimeType.ContainsKey(fileExtension))
            {
                mimeType = FileExtensionToMimeType[fileExtension];
            }
            else
            {
                if (!silent)
                {
                    throw Lib.Exception(Config.Error.UNABLE_TO_DETERMINE_MIME_TYPE_FROM_FILENAME, fileName);
                }
            }

            return mimeType;
        }

        //
        // GET-MIMETYPE-FROM-FILENAME-WITH-DEFAULT
        // Based of the file extension return the corresponding
        // mime type. If the mime type is not supported, se a default 
        // mime type.
        //

        public static string GetMimeTypeFromFilenameWithDefault(string filename, string defaultMimeType)
        {            
            string fileExtension = Path.GetExtension(filename).ToLower(CultureInfo.InvariantCulture);
            return FileExtensionToMimeType.ContainsKey(fileExtension) ? FileExtensionToMimeType[fileExtension] : defaultMimeType;
        }

        //
        // GET-MIMETYPE-FROM-URL
        // Based on a url get the mime type. This implies removing
        // optional information from the url, stuff like query string
        // and anchors...
        //

        public static string GetMimeTypeFromUrl(string url)
        {
            return GetMimeTypeFromUrl(url, THROW_ERROR_IF_NOT_FOUND);
        }

        public static string GetMimeTypeFromUrl(string url, bool silent)
        {
            //
            // Trim the url from query strings and anchors.
            // Start with the original Url value.
            //

            string trimmedUrl = url;

            //
            // Remove the query string.
            // Remove anchors.
            //

            trimmedUrl = trimmedUrl.Contains("?") ? trimmedUrl.LeftOf("?") : trimmedUrl;
            trimmedUrl = trimmedUrl.Contains("#") ? trimmedUrl.LeftOf("#") : trimmedUrl;
         
            //
            // Use the standard retrieve function.
            //

            return GetMimeTypeFromFilename(trimmedUrl, silent);
        }

        //
        // GET-EXTENSOIN-FROM-MIMETYPE
        // Based of the mime type return the corresponding
        // file extension.
        //

        public static string GetFileExtensionFromMimeType(string mimeType)
        {
            return GetFileExtensionFromMimeType(mimeType, THROW_ERROR_IF_NOT_FOUND);
        }

        public static string GetFileExtensionFromMimeType(string mimeType, bool silent)
        {
            string mime = mimeType.ToLower(CultureInfo.InvariantCulture);
            string fileExtension = string.Empty;

            if (MimeTypeToFileExtension.ContainsKey(mime))
            {
                fileExtension = MimeTypeToFileExtension[mime];
            }
            else
            {
                if (!silent)
                {
                    throw Lib.Exception(Config.Error.UNABLE_TO_DETERMINE_FILE_EXTENSION_FROM_MIME_TYPE, mimeType);
                }
            }

            return fileExtension;
        }
    }
}
