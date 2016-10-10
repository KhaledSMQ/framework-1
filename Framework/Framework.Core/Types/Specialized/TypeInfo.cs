// ============================================================================
// Project: Framework
// Name/Class: TypeInfo
// Author: João Carreiro (joao.carreiro@coop4creativity.com)
// Create date: 9/Oct/2016
// Company: Coop4Creativity
// Description: Type information class.
// ============================================================================

using System.Collections.Generic;
using Framework.Core.Extensions;
using System.Text;

namespace Framework.Core.Types.Specialized
{
    public class TypeInfo
    {       
        //
        // PROPERTIES
        //

        public AssemblyInfo Assembly { get; set; }

        public string Name { get; set; }

        public bool IsGeneric { get; set; }

        public IEnumerable<TypeInfo> Args { get; set; }

        //
        // CONSTRUCTOR
        //

        public TypeInfo()
        {
            Assembly = null;
            Name = string.Empty;
            IsGeneric = false;
            Args = null;
        }

        //
        // Parse a type info definition for this instance.
        // @param typeAsString The type definition to parse.
        // @return this object.
        //

        public TypeInfo Parse(string typeInfoAsString)
        {
            return Parse(typeInfoAsString, TypeInfoParsingOptions.DEFAULT);
        }

        public TypeInfo Parse(string typeInfoAsString, TypeInfoParsingOptions options)
        {
            //
            // Initialize the type info object,
            // apply basic default values.
            //

            Assembly = new AssemblyInfo();
            Name = string.Empty;
            IsGeneric = false;
            Args = null;

            List<string> argLst = null;

            //
            // Find out if the type name has any generics specified.
            //

            int genericIndex = typeInfoAsString.IndexOf(options.OpenGenericChar);

            if (-1 == genericIndex)
            {
                //
                // No generics.
                // Find if there is an assembly name.
                //

                string[] assemblySegment = typeInfoAsString.SplitNoEmpty(options.AssemblySeparatorChar);
                if (1 == assemblySegment.Length)
                {
                    //                    
                    // Type name.
                    //

                    Name = assemblySegment[0];
                }
                else
                {
                    //
                    // Assembly name.
                    // Type name.
                    //

                    Assembly.Name = assemblySegment[0];
                    Name = assemblySegment[1];
                }
            }
            else
            {
                //
                // Has generic specification.
                //

                IsGeneric = true;
                string leftSide = typeInfoAsString.Substring(0, genericIndex);
                string rightSide = typeInfoAsString.Substring(genericIndex);

                //
                // Find if there is an assembly name.
                //

                string[] assemblySegment = leftSide.SplitNoEmpty(options.AssemblySeparatorChar);
                if (1 == assemblySegment.Length)
                {
                    //                    
                    // Type name.
                    //

                    Name = assemblySegment[0];
                }
                else
                {
                    //
                    // Assembly name.
                    // Type name.
                    //

                    Assembly.Name = assemblySegment[0];
                    Name = assemblySegment[1];
                }

                //
                // Extract the generic type bits inside.
                //

                argLst = new List<string>();

                //
                // Remove the surrounding open and close 
                // characters.
                //

                string noOpenAndCloseCharacters = rightSide;

                //
                // Extract the main generic type definition inside
                // the main type definition.
                //

                int braceCount = 0;
                StringBuilder fullTypeName = new StringBuilder();

                for (int idx = 1; idx < noOpenAndCloseCharacters.Length - 1; idx++)
                {
                    char currChar = noOpenAndCloseCharacters[idx];

                    if (currChar == options.OpenGenericChar)
                    {
                        braceCount++;
                    }
                    else
                        if (currChar == options.CloseGenericChar)
                    {
                        braceCount--;

                        if (0 == braceCount)
                        {
                            argLst.Add(fullTypeName.ToString());
                            fullTypeName.Clear();
                        }
                    }
                    else
                            if (currChar == options.SeparatorChar)
                    {
                        if (0 == braceCount)
                        {
                            argLst.Add(fullTypeName.ToString());
                            fullTypeName.Clear();
                        }
                    }
                    else
                    {
                        fullTypeName.Append(currChar);
                    }
                }

                if (fullTypeName.Length > 0)
                {
                    argLst.Add(fullTypeName.ToString());
                }
            }

            //
            // After parsing everything, we need to create the actual type.
            //           

            if (IsGeneric)
            {
                //
                // If we have a generic type then we need to
                // parse all the generic types into type specifications.
                //

                Args = argLst.Map(typeAsString => { return ParseType(typeAsString, options); });
            }

            return this;
        }

        public string Unparse()
        {
            StringBuilder output = new StringBuilder();
            return output.ToString();
        }

        //
        // Parse from a string value and return a new type info object.
        // @param typeInfoAsString The type definition to parse.
        // @return The type info instance object.
        //

        public static TypeInfo ParseType(string typeInfoAsString)
        {
            return new TypeInfo().Parse(typeInfoAsString);
        }

        public static TypeInfo ParseType(string typeInfoAsString, TypeInfoParsingOptions options)
        {
            return new TypeInfo().Parse(typeInfoAsString, options);
        }

        //
        // Unparse a type definition object to string.
        // @param typeInfo The type info object to unparse.
        // @return The string representation.
        //

        public static string UnparseType(TypeInfo typeInfo)
        {
            return typeInfo.Unparse();
        }
    }
}
