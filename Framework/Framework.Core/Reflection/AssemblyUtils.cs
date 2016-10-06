// ============================================================================
// Project: Framework
// Name/Class: AssemblyUtils
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Assembly related utils.
// ============================================================================

using Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Framework.Core.Extensions;

namespace Framework.Core.Reflection
{
    public static class AssemblyUtils
    {
        //
        // Get some content from the current assembly.
        // Returns the content as a string of characters.
        //

        public static string GetInternalFileContent(string folderPath, string fileName)
        {
            return GetInternalFileContent(Assembly.GetExecutingAssembly(), folderPath, fileName);
        }

        //
        // Get the content, as a string, of an internal file of an assembly.
        // @param assembly The assembly where to get the content.
        // @param folderPath The folder path where the file is located.
        // @param fileName The name for the file.
        // @return The file content if exists, empty string otherwise.
        // 

        public static string GetInternalFileContent(this Assembly assembly, string folderPath, string fileName)
        {
            Guard.ArgumentNotNull(assembly, "assembly");

            Stream stream = assembly.GetManifestResourceStream(folderPath + fileName);
            return stream.IsNotNull() ? new StreamReader(stream).ReadToEnd() : string.Empty;
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            Guard.ArgumentNotNull(assembly, "assembly");

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t.IsNotNull());
            }
        }

        public static IEnumerable<Type> GetTypesWithInterface(this Assembly assembly, Type typeOfInterface)
        {
            Guard.ArgumentNotNull(assembly, "assembly");
            Guard.ArgumentNotNull(typeOfInterface, "typeOfInterface");

            return assembly.GetLoadableTypes().Where(typeOfInterface.IsAssignableFrom).ToList();
        }
    }
}
