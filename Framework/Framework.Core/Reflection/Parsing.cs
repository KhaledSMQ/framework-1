// ============================================================================
// Project: Framework
// Name/Class: Parsing
// Author: João Carreiro (joaopaulocarreiro@gmail.com)
// Create date: 26/Nov/2015
// Company: Coop4Creativity
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

                if (genericTypeName.IsNotNullAndEmpty())
                {
                    listOfGenericTypeName.Add(genericTypeName);
                }
            }

            //
            // Load assembly if required.
            //

            Assembly typeAssembly = Assembly.GetExecutingAssembly();

            if (assemblyName.IsNotNullAndEmpty())
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

                IList<Type> listOfType = listOfGenericTypeName.Map(_ParseTypeName);

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

        //
        // Parse from a string a type value.
        // @param type the type of the value to parse.
        // @param strValue The string value to parse
        // @return the object value parsed from string.
        //

        public static object ParseTypeValue(Type type, string strValue)
        {
            object value = default(object);

            if (type == typeof(int))
            {
                value = int.Parse(strValue);
            }
            else if (type == typeof(double))
            {
                value = double.Parse(strValue);
            }
            else if (type == typeof(long))
            {
                value = long.Parse(strValue);
            }
            else if (type == typeof(float))
            {
                value = float.Parse(strValue);
            }
            else if (type == typeof(bool))
            {
                value = bool.Parse(strValue);
            }
            else if (type == typeof(DateTime))
            {
                value = DateTime.Parse(strValue);
            }
            else if (type == typeof(string))
            {
                value = strValue;
            }
            else if (type.BaseType == typeof(Enum))
            {
                value = Enum.Parse(type, strValue, true);
            }
            else
            {
                //
                // ERROR: Type is not supported.
                // 

                throw new Exception(string.Format("{0}: ParseTypeValue does not support type '{1}'!", Config.Lib.DEFAULT_ERROR_MSG_PREFIX, type.FullName));
            }

            return value;
        }
    }
}
