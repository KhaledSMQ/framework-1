// ============================================================================
// Project: Framework
// Name/Class: FileHelper
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Helper functions for files.
// ============================================================================                    

using System;
using System.Diagnostics;
using System.IO;

namespace Framework.Core.Helpers
{
    public class FileHelper
    {
        //
        // Get the number of lines in a file.
        //

        public static int GetLineCount(string path)
        {
            BinaryReader reader = new BinaryReader(File.OpenRead(path));
            int lineCount = 0;

            char lastChar = reader.ReadChar();
            char newChar = new char();

            do
            {
                newChar = reader.ReadChar();
                if (lastChar == '\r' && newChar == '\n')
                {
                    lineCount++;
                }

                lastChar = newChar;

            } while (reader.PeekChar() != -1);

            return lineCount;
        }

        //
        // Gets the orginal extension from a renamed extension. e.g. 
        // file.xml.config return .xml instead of .config. file.xml returns .xml.        
        // Returns the string with original extension.
        //

        public static string GetOriginalExtension(string path, string appendedExtension)
        {
            // 
            // Example /configfiles/users.csv.config
            //

            FileInfo file = new FileInfo(path);
            string extension = file.Extension.ToLower();

            // 
            // None supplied ?
            //

            if (string.IsNullOrEmpty(appendedExtension))
            {
                return extension;
            }

            // 
            // Now check that file ends w/ the extra extension
            //

            appendedExtension = appendedExtension.ToLower();

            if (string.Compare(extension, appendedExtension, true) != 0)
            {
                return extension;
            }

            // 
            // Get the original extension.
            //

            path = file.Name.Substring(0, file.Name.LastIndexOf(appendedExtension, StringComparison.InvariantCultureIgnoreCase));
            file = new FileInfo(path);

            return file.Extension.ToLower();
        }

        //
        // Get the file version information.
        // If file does not exist return the empty string.
        //

        public static string GetFileVersion(string path)
        {
            //
            // If file does not exist, return empty string.
            //

            if (!File.Exists(path))
            {
                return string.Empty;
            }

            // 
            // Get the file version and return it.
            //

            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(path);
            return versionInfo.FileVersion;
        }

        //
        // Get file size in bytes.
        //

        public static int GetSizeInBytes(string path)
        {
            FileInfo info = new FileInfo(path);
            return (int)info.Length;
        }

        //
        // Get file size in kilobytes.
        //

        public static int GetSizeInKilo(string path)
        {
            return (int)GetSizeInBytes(path) / 1000;
        }

        //
        // Get file size in megabytes.
        //

        public static int GetSizeInMegs(string path)
        {
            return (int)GetSizeInBytes(path) / 1000000;
        }

        //
        // Prepend some text to a file.
        //

        public static void PrependText(string path, string text)
        {
            string content = File.ReadAllText(path);
            content = text + content;
            File.WriteAllText(path, content);
        }

        //
        // Append some text to a file.
        //

        public static void AppendText(string path, string text)
        {
            string content = File.ReadAllText(path);
            content = content + text;
            File.WriteAllText(path, content);
        }
    }
}
