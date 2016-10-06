// ============================================================================
// Project: Framework
// Name/Class: FileHelper
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Helper functions for directories
// ============================================================================                    

using System.Collections.Generic;
using System.IO;
using Framework.Core.Extensions;

namespace Framework.Core.Helpers
{
    public class DirectoryHelper
    {
        //
        // Get the list of files that have a certain name pattern, allowing us to
        // search inside sub directories.
        //

        public static IList<string> GetFiles(string path, string pattern, bool recursive = true)
        {
            List<string> output = new List<string>(Directory.GetFiles(path, pattern));

            if (recursive)
            {
                Directory.GetDirectories(path).Apply(dir => output.AddRange(GetFiles(dir, pattern, recursive)));
            }

            return output;
        }

        //
        // Get directory size in bytes.
        //

        public static int GetSizeInBytes(string path, string pattern, bool recursive = true)
        {
            return GetFiles(path, pattern, recursive).Catamorphism(0, (file, size) => { return FileHelper.GetSizeInBytes(file) + size; });
        }

        //
        // Get directory size in kilobytes.
        //

        public static int GetSizeInKilo(string path, string pattern, bool recursive = true)
        {
            return GetFiles(path, pattern, recursive).Catamorphism(0, (file, size) => { return FileHelper.GetSizeInKilo(file) + size; });
        }

        //
        // Get directory size in megabytes.
        //

        public static int GetSizeInMegs(string path, string pattern, bool recursive = true)
        {
            return GetFiles(path, pattern, recursive).Catamorphism(0, (file, size) => { return FileHelper.GetSizeInMegs(file) + size; });
        }
    }
}
