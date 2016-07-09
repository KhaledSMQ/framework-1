// ============================================================================
// Project: Framework
// Name/Class: AssemblyUtils
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
// Description: Assembly related utils.
// ============================================================================

using Framework.Core.Extensions;
using Framework.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Framework.Core.Reflection
{
    public static class AssemblyUtils
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

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            Guard.IsNotNull(assembly);

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static IEnumerable<Type> GetTypesWithInterface(this Assembly assembly, Type typeOfInterface)
        {
            Guard.IsNotNull(assembly);

            return assembly.GetLoadableTypes().Where(typeOfInterface.IsAssignableFrom).ToList();
        }
    }
}
