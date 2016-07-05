// ============================================================================
// Project: Framework
// Name/Class: AssemblyUtils
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Assembly related utils.
// ============================================================================

using System.IO;
using System.Reflection;

namespace Framework.Core.Reflection
{
    public class AssemblyUtils
    {
        //
        // Get the some content from the current assembly.
        // Returns the content as a string of characters.
        //

        public static string GetInternalFileContent(string assemblyFolderPath, string fileName)
        {
            Assembly current = Assembly.GetExecutingAssembly();

            Stream stream = current.GetManifestResourceStream(assemblyFolderPath + fileName);
            if (null == stream)
            {
                return string.Empty;
            }

            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            return content;
        }
    }
}
