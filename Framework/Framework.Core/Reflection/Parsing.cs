﻿// ============================================================================
// Project: Framework
// Name/Class: Parsing
// Author: João Carreiro (joao.carreiro@cybermap.pt)
// Create date: 26/Nov/2015
// Company: Cybermap Lta.
// Description: Reflection related parsing methods.
// ============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Framework.Core.Extensions;

namespace Framework.Core.Reflection
{
    public static class Parsing
    {
        //
        // Parse the type defined as a string definition.
        // @param typeAsString The string spec for the type.
        // @return The type definition object instamce.
        //

        public static Type ParseTypeName(string typename)
        {
            //
            // Remove all whitespace characters.
            //

            string noWhiteSpace = typename.RemoveWhitespace();
            return _ParseTypeName(noWhiteSpace);
        }

        //
        // Parse the type defined as a string definition.
        // This method assumes that the type name has *NO*
        // white space characters.
        // @param typeAsString The string spec for the type.
        // @return The type definition object instamce.
        //

        private static Type _ParseTypeName(string typeAsString)
        {
            char assemblySeparatorChar = ':';
            char separatorChar = ',';
            char openGenericChar = '[';
            char closeGenericChar = ']';

            Type type = default(Type);

            string assemblyName = string.Empty;
            string typeName = string.Empty;
            List<string> listOfGenericTypeName = null;

            bool isGeneric = false;

            //
            // Find out if the type name has any generics specified.
            //

            int genericIndex = typeAsString.IndexOf(openGenericChar);

            if (-1 == genericIndex)
            {
                //
                // No generics.
                // Find if there is an assembly name.
                //

                string[] assemblySegment = typeAsString.SplitNoEmpty(assemblySeparatorChar);
                if (1 == assemblySegment.Length)
                {
                    //                    
                    // Type name.
                    //

                    typeName = assemblySegment[0];
                }
                else
                {
                    //
                    // Assembly name.
                    // Type name.
                    //

                    assemblyName = assemblySegment[0];
                    typeName = assemblySegment[1];
                }
            }
            else
            {
                //
                // Has generic specification.
                //

                isGeneric = true;
                string leftSide = typeAsString.Substring(0, genericIndex);
                string rightSide = typeAsString.Substring(genericIndex);

                //
                // Find if there is an assembly name.
                //

                string[] assemblySegment = leftSide.SplitNoEmpty(assemblySeparatorChar);
                if (1 == assemblySegment.Length)
                {
                    //                    
                    // Type name.
                    //

                    typeName = assemblySegment[0];
                }
                else
                {
                    //
                    // Assembly name.
                    // Type name.
                    //

                    assemblyName = assemblySegment[0];
                    typeName = assemblySegment[1];
                }

                //
                // Extract the generic type bits inside.
                //

                listOfGenericTypeName = new List<string>();

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
                string genericTypeName = string.Empty;

                for (int idx = 1; idx < noOpenAndCloseCharacters.Length - 1; idx++)
                {
                    char currChar = noOpenAndCloseCharacters[idx];

                    if (currChar == openGenericChar)
                    {
                        braceCount++;
                    }
                    else
                        if (currChar == closeGenericChar)
                        {
                            braceCount--;

                            if (0 == braceCount)
                            {
                                listOfGenericTypeName.Add(genericTypeName);
                                genericTypeName = string.Empty;
                            }
                        }
                        else
                            if (currChar == separatorChar)
                            {
                                if (0 == braceCount)
                                {
                                    listOfGenericTypeName.Add(genericTypeName);
                                    genericTypeName = string.Empty;
                                }
                            }
                            else
                            {
                                genericTypeName += currChar;
                            }
                }

                if (genericTypeName.isNotNullAndEmpty())
                {
                    listOfGenericTypeName.Add(genericTypeName);
                }
            }

            //
            // Load assembly if required.
            //

            Assembly typeAssembly = Assembly.GetExecutingAssembly();

            if (assemblyName.isNotNullAndEmpty())
            {
                typeAssembly = Assembly.Load(assemblyName);
            }

            //
            // After parsing everything, we need to create the actual type.
            //           

            if (isGeneric)
            {
                //
                // If we have a generic type then we need to
                // parse all the generic types into type specifications.
                //

                IList<Type> listOfType = listOfGenericTypeName.Map(new List<Type>(), _ParseTypeName);

                string genericTypeName = typeName + "`" + listOfType.Count;

                Type genericTypeBase = typeAssembly.GetType(genericTypeName, true);

                type = genericTypeBase.MakeGenericType(listOfType.ToArray());
            }
            else
            {
                type = typeAssembly.GetType(typeName, true);
            }

            //
            // Return the type definition object to caller.
            // 

            return type;
        }
    }
}